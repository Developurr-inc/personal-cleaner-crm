namespace Developurr.Orderly.Application.UseCase.Order.CreateOrder;

public record CreateOrderInput(
    string CustomerId,
    string SalesConsultantId,
    string ShippingId,
    string Price
);