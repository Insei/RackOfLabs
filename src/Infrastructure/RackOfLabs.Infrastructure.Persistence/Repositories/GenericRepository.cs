using System.Linq.Expressions;
using RackOfLabs.Application.Interfaces.Generic;
using RackOfLabs.Application.Persistence;
using RackOfLabs.Domain.Base;
using RackOfLabs.DTOs.Sorts;
using RackOfLabs.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace RackOfLabs.Infrastructure.Persistence.Repositories;

public sealed class GenericRepository : IGenericRepositoryAsync
{
    private readonly DataDbContext _dbContext;
    public GenericRepository(DataDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>>? expression = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null, int page = 0,
        int pageSize = 0, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
        
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();
        if (expression != null)
            query = query.Where(expression);
        if (includes != null)
            query = includes(query);
        
        if (orderBy != null)
            query = orderBy(query);

        if (page > 0 && pageSize > 0)
            query = query.Skip(pageSize * (page - 1)).Take(pageSize);
        
        return await  query.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(string? search = "", string? orderBy = "", SortDirection direction = SortDirection.Asc,
        int page = 0, int pageSize = 0, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
            var pageContext = page < 1 ? 0 : page;
            var pageSizeContext = pageSize < 1 ? 0 : pageSize;
            Expression<Func<TEntity, bool>>? filterExpression = null;
            Expression<Func<TEntity, object>>? orderExpression = null;

            if (!string.IsNullOrEmpty(search))
            {
                filterExpression = PredicateBuilder.PredicateSearchInAllFields<TEntity>(search);
            }

            IEnumerable<TEntity>? entities = null;
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderExpression = PredicateBuilder.ToLambda<TEntity>(orderBy);
            }

            if (orderExpression != null)
            {
                entities = direction switch
                {
                    SortDirection.Asc => await GetAsync(filterExpression, c => c.OrderBy(orderExpression), null,
                        pageContext, pageSizeContext, cancellationToken),
                    SortDirection.Desc => await GetAsync(filterExpression, c => c.OrderByDescending(orderExpression),
                        null, pageSizeContext, pageSize, cancellationToken),
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };
            }

            return entities ?? await GetAsync(filterExpression, null, null, page, pageSize, cancellationToken);
    }

    public async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
        if (filter != null)
            return await _dbContext.Set<TEntity>().Where(filter).CountAsync(cancellationToken: cancellationToken);
        
        return await _dbContext.Set<TEntity>().CountAsync(cancellationToken: cancellationToken);
    }

    public async Task<int> CountAsync<TEntity>(string? search, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
        Expression<Func<TEntity, bool>>? filterExpression = null;
        
        if (!string.IsNullOrEmpty(search))
        {
            filterExpression = PredicateBuilder.PredicateSearchInAllFields<TEntity>(search);
        }
        return await CountAsync(filterExpression, cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync<TEntity>(Guid id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
        if(includes != null)
            return await includes(_dbContext.Set<TEntity>()).FirstAsync(e => e.Id == id, cancellationToken);
        
        return await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public async Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
        return await _dbContext.Set<TEntity>().AnyAsync(expression, cancellationToken);
    }

    public async Task<TEntity?> FirstAsync<TEntity>(Expression<Func<TEntity, bool>>? expression, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
        if(expression != null)
            return await _dbContext.Set<TEntity>().FirstAsync(expression, cancellationToken);
        
        return await _dbContext.Set<TEntity>().FirstAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        _dbContext.Entry(entity).State = EntityState.Added;
        return entity;
    }

    public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        entity.Removed = true;
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}