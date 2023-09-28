using Moq;
using Orderly.Application.UseCase;
using Orderly.Application.UseCase.Customer.CreateCustomer;
using Orderly.Domain.Customer;
using Orderly.Domain.SalesConsultant;

namespace Orderly.Application.UnitTests.TestUtils.CreateCustomer;

public static class CreateCustomerFixture
{
    public static CreateCustomerUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();

        return new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
    }
}
