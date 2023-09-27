using Orderly.Domain.SeedWork;
using Orderly.Domain.Shipping.ValueObjects;

namespace Orderly.Domain.Shipping;

public interface IShippingRepository : IRepository<Shipping, ShippingId> { }
