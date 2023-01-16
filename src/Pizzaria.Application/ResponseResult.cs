namespace Pizzaria.Application;

public class ResponseResult<T> : IResponseResult<T>
{
    public bool Success { get; set; }
    public string[]? MessageError { get; set; }
    public T? Payload { get; set; }
}

public class ResponseResult : IResponseResult
{
    public bool Success { get; set; }
    public string[]? MessageError { get; set; }
}
