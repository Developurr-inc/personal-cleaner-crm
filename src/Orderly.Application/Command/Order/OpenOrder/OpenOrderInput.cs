namespace Orderly.Application.Command.Order.OpenOrder;

public record OpenOrderInput
(
    string CustomerId,
    string SalesConsultantId,
    string ShippingId,
    string Price
);