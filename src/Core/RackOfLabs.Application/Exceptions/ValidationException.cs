namespace RackOfLabs.Application.Exceptions;

public class ValidationException : CustomException
{
    public ValidationException(List<string>? errors = default)
        : base("Validation Failures Occured.", errors, 400)
    {
    }
}