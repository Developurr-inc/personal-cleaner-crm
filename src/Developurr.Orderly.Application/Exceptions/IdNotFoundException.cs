namespace Developurr.Orderly.Application.Exceptions;

public sealed class IdNotFoundException : ArgumentException
{
    public IdNotFoundException(string idName)
        : base("Id not found.", idName) { }
}
