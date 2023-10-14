using Developurr.Orderly.Domain.Order.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Order;

public interface IOrderRepository : IRepository<Order, OrderId> { }
