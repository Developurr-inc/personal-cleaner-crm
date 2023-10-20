namespace Developurr.Orderly.Application.Exceptions;

public sealed class NotFoundException : ArgumentException
{
    public NotFoundException(string message, string name) : base(message, name) { }
}
