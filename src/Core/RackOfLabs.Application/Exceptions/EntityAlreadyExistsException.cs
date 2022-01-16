namespace RackOfLabs.Application.Exceptions;

public class EntityAlreadyExistsException : CustomException
{
    public EntityAlreadyExistsException(string message = "Entity already exist")
        : base(message)
    {
    }
}