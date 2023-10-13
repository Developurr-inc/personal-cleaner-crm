using Developurr.Orderly.Domain.Customer.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Customer;

public interface ICustomerRepository : IRepository<Customer, CustomerId> { }
