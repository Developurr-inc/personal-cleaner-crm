using Orderly.Domain.Product.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Product;

public interface IProductRepository : IRepository<Product, ProductId> { }
