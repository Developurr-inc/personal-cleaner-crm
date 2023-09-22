using Orderly.Domain.Customer.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Customer;

public interface ICustomerRepository : IRepository<Customer, CustomerId> { }
