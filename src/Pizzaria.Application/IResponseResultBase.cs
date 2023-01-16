namespace Pizzaria.Application;

public interface IResponseResultBase
{
    public bool Success { get; set; }
    public string[]? MessageError { get; set; }
}
