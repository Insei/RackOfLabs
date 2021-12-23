using System.Linq.Expressions;
using RackOfLabs.Domain.Base;
using RackOfLabs.DTOs.Sorts;

namespace RackOfLabs.Application.Interfaces.Generic;

public interface IGenericRepositoryAsync
{
    /// <summary>
    /// Get Entity List
    /// </summary>
    /// <param name="expression">Filter</param>
    /// <param name="orderBy">Sorting</param>
    /// <param name="includes">Includes</param>
    /// <param name="page">Current page</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>List of Entities</returns>
    Task<IEnumerable<TEntity>> GetAsync<TEntity>(
        Expression<Func<TEntity, bool>>? expression = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null,
        int page = 0, int pageSize = 0, CancellationToken cancellationToken = default)
        where TEntity : BaseEntity;
    /// <summary>
    /// Get Entity List (search in all fields)
    /// </summary>
    /// <param name="search">Search string</param>
    /// <param name="orderBy">Sorting</param>
    /// <param name="direction">Sorting direction</param>
    /// <param name="page">Current page</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>List of Entities</returns>
    Task<IEnumerable<TEntity>> GetAsync<TEntity>(string? search = "", string? orderBy = "", SortDirection direction = SortDirection.Asc,
        int page = 0, int pageSize = 0, CancellationToken cancellationToken = default)
        where TEntity : BaseEntity;
    /// <summary>
    /// Count Elements with specified filter
    /// </summary>
    /// <param name="filter">Filter</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Count</returns>
    Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default)
        where TEntity : BaseEntity;
    /// <summary>
    /// Count Elements with search string (search in all fields)
    /// </summary>
    /// <param name="search">Search string</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Count</returns>
    Task<int> CountAsync<TEntity>(string? search, CancellationToken cancellationToken = default)
        where TEntity : BaseEntity;
    /// <summary>
    /// Get Entity by ID
    /// </summary>
    /// <param name="id">Entity ID</param>
    /// <param name="includes">Includes</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Nullable Entity</returns>
    Task<TEntity?> GetByIdAsync<TEntity>(Guid id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null,
        CancellationToken cancellationToken = default)
        where TEntity : BaseEntity;
    /// <summary>
    /// Check that entity Exist
    /// </summary>
    /// <param name="expression">Filter</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        where TEntity : BaseEntity;
    /// <summary>
    /// Get First Entity
    /// </summary>
    /// <param name="expression">Filters</param>
    /// <param name="includes">Includes</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    Task<TEntity?> FirstAsync<TEntity>(Expression<Func<TEntity, bool>>? expression, 
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null, 
        CancellationToken cancellationToken = default)
        where TEntity : BaseEntity;
    /// <summary>
    /// Add new Entity
    /// </summary>
    /// <param name="entity">Entity for Add</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Created Entity</returns>
    Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : BaseEntity;
    /// <summary>
    /// Mark that entity has changes
    /// </summary>
    /// <param name="entity">Entity that modified</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    void Update<TEntity>(TEntity entity)
        where TEntity : BaseEntity;
    /// <summary>
    /// Delete Entity (Mark that entity has been deleted)
    /// </summary>
    /// <param name="entity"></param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    void Delete<TEntity>(TEntity entity)
        where TEntity : BaseEntity;
    /// <summary>
    /// Save changes
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}