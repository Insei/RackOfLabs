using AutoMapper;
using RackOfLabs.Application.Exceptions;
using RackOfLabs.Application.Interfaces.Generic;
using RackOfLabs.Domain.Base;
using RackOfLabs.DTOs.Interfaces;
using RackOfLabs.DTOs.List;
using RackOfLabs.DTOs.Results;

namespace RackOfLabs.Application.Services;

public class GenericEntityService : IGenericEntityService
{
    internal readonly IGenericRepositoryAsync Repository;
    private readonly IMapper _mapper;

    public GenericEntityService(IGenericRepositoryAsync repository, IMapper mapper)
    {
        Repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<PaginatedResult<List<TDto>>> GetAsync<TDto, TEntity>(PaginatedListRequest request) where TEntity : BaseEntity
    {
        var pagination = Pagination.Generate(request, await Repository.CountAsync<TEntity>(request.Search));
        var entities = await Repository.GetAsync<TEntity>(request.Search, request.Sort.FieldName, request.Sort.Direction, 
            pagination.CurrentPage, pagination.PageSize);
        
        var result = new PaginatedResult<List<TDto>>
        {
            Pagination = pagination,
            Data = _mapper.Map<List<TDto>>(entities)
        };
        return result;
    }

    public virtual async Task<Result<TDto>> GetAsync<TDto, TEntity>(Guid id) where TEntity : BaseEntity
    {
        var entity = await Repository.GetByIdAsync<TEntity>(id);
        if (entity == null) throw new EntityNotFoundException();
        var result = new Result<TDto>
        {
            Data = _mapper.Map<TDto>(entity)
        };
        return result;
    }

    public virtual async Task<Result<TDto>> CreateAsync<TDto, TEntity, TCreateReq>(TCreateReq request) where TEntity : BaseEntity
    {
        var entityToCreate = _mapper.Map<TEntity>(request);
        var entity = await Repository.AddAsync(entityToCreate);
        await Repository.SaveChangesAsync();
        var result = new Result<TDto>
        {
            Data = _mapper.Map<TDto>(entity)
        };
        return result;
    }

    protected virtual Task ValidateUpdateRequestAsync<TUpdateReq>(TUpdateReq request, Guid id)
        where TUpdateReq : IRequest
    {
        return Task.CompletedTask;
    }

    public virtual async Task<Result<TDto>> UpdateAsync<TDto, TEntity, TUpdateReq>(TUpdateReq request, Guid id) 
        where TEntity : BaseEntity
        where TUpdateReq : IRequest
    {
        await ValidateUpdateRequestAsync(request, id);
        var entity = await Repository.GetByIdAsync<TEntity>(id);
        if (entity == null) throw new EntityNotFoundException();
        _mapper.Map(request, entity);
        Repository.Update(entity);
        await Repository.SaveChangesAsync();
        var result = new Result<TDto>
        {
            Data = _mapper.Map<TDto>(entity)
        };
        return result;
    }

    public virtual async Task<Result> DeleteAsync<TEntity>(Guid id) where TEntity : BaseEntity
    {
        var entity = await Repository.GetByIdAsync<TEntity>(id);
        if (entity == null) throw new EntityNotFoundException();
        Repository.Delete(entity);
        await Repository.SaveChangesAsync();
        return new Result();
    }
}