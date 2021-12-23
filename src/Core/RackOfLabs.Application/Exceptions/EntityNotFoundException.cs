using System.Net;

namespace RackOfLabs.Application.Exceptions;

public class EntityNotFoundException : CustomException
{
    public EntityNotFoundException(string message = "Entity not found")
        : base(message, null, 404)
    {
    }
}