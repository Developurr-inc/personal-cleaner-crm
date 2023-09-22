namespace Orderly.Domain.Order;

public enum Status
{
    Draft,
    Credit,
    OutOfStock,
    DiscountNotAllowed,
    Closed,
    Cancelled,
    Processing
}
