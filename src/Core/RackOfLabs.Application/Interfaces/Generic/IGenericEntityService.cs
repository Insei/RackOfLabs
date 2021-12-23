using RackOfLabs.Domain.Base;
using RackOfLabs.DTOs.Interfaces;
using RackOfLabs.DTOs.List;
using RackOfLabs.DTOs.Results;

namespace RackOfLabs.Application.Interfaces.Generic;

public interface IGenericEntityService
{
    /// <summary>
    /// Get paginated result
    /// </summary>
    /// <param name="request">Universal paginated list request</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDto">Entity DTO</typeparam>
    /// <returns>List of Entities in DTO</returns>
    Task<PaginatedResult<List<TDto>>> GetAsync<TDto, TEntity>(PaginatedListRequest request)
        where TEntity : BaseEntity;
    /// <summary>
    /// Get by id
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDto">Entity DTO</typeparam>
    /// <returns>Entity DTO</returns>
    Task<Result<TDto>> GetAsync<TDto, TEntity>(Guid id)
        where TEntity : BaseEntity;

    /// <summary>
    /// Create new Entity
    /// </summary>
    /// <param name="request">CreateDTO for entity</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDto">Entity DTO</typeparam>
    /// <typeparam name="TCreateReq">Entity Create request DTO</typeparam>
    /// <returns></returns>
    Task<Result<TDto>> CreateAsync<TDto, TEntity, TCreateReq>(TCreateReq request) where TEntity : BaseEntity;
    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="request">UpdateDTO for entity</param>
    /// <param name="id">Id of the entity</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDto">Entity DTO</typeparam>
    /// <typeparam name="TUpdateReq">Entity update request DTO</typeparam>
    /// <returns></returns>
    Task<Result<TDto>> UpdateAsync<TDto, TEntity, TUpdateReq>(TUpdateReq request, Guid id) 
        where TEntity : BaseEntity
        where TUpdateReq : IRequest;
    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns></returns>
    Task<Result> DeleteAsync<TEntity>(Guid id) where TEntity : BaseEntity;
}