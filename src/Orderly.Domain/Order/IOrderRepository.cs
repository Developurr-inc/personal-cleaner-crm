using Orderly.Domain.Order.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order;

public interface IOrderRepository : IRepository<Order, OrderId> { }
