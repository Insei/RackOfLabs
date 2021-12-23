namespace RackOfLabs.Application.Exceptions;

public class NothingToUpdateException : CustomException
{
    public NothingToUpdateException()
        : base("There are no new changes to update for this Entity.", null, 406)
    {
    }
}