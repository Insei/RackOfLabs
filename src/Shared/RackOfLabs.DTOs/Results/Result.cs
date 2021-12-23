namespace RackOfLabs.DTOs.Results;

public class ResultStatus
{
    public bool Succeeded { get; set; }
    public List<string> Messages { get; set; }

    public ResultStatus()
    {
        Succeeded = true;
        Messages = new List<string>();
    }
}

public class Result
{
    public ResultStatus Status { get; set; }

    public Result()
    {
        Status = new ResultStatus();
    }
}

public class Result<T>
{
    public ResultStatus Status { get; set; }
    public T? Data { get; set; }
    
    public Result()
    {
        Status = new ResultStatus();
    }
}