namespace RackOfLabs.Application.Exceptions;

public class EntityAlreadyExistsException : CustomException
{
    public EntityAlreadyExistsException(string message)
        : base(message)
    {
    }
}