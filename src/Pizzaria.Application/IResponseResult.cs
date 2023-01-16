namespace Pizzaria.Application;

public interface IResponseResult<T> : IResponseResultBase
{
    public T? Payload { get; set; }
}

public interface IResponseResult : IResponseResultBase { }
