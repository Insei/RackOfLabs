namespace RackOfLabs.Application.Interfaces.Services;

public interface IAuthenticatedUserService
{
    /// <summary>
    /// Authenticated User ID
    /// </summary>
    Guid UserId { get; }
}