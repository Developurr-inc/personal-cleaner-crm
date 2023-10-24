namespace Developurr.Orderly.Application.Exceptions;

public sealed class NotFoundException : ApplicationException
{
    public NotFoundException(string message)
        : base(message)
    {
    }

    public static void ThrowIfNull(object? obj, string idName)
    {
        if (obj is null)
            throw new NotFoundException(idName);
    }
}