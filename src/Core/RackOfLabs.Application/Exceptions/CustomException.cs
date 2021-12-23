namespace RackOfLabs.Application.Exceptions;

public class CustomException : Exception
{
    public List<string> ErrorMessages { get; } = new ();
    public int StatusCode { get; }
    public CustomException(string message, List<string>? errors = null, int statusCode = 500)
        : base(message)
    {
        if(errors != null)
            ErrorMessages = errors;
        StatusCode = statusCode;
    }
}