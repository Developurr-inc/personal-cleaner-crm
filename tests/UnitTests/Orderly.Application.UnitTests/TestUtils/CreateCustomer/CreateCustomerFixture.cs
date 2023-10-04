using Moq;
using Orderly.Application.UseCase;
using Orderly.Application.UseCase.Customer.CreateCustomer;
using Orderly.Domain.Customer;
using Orderly.Domain.SalesConsultant;
using Orderly.Domain.UnitTests.TestUtils.Constants;

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
    
    public static CreateCustomerInput CreateInput()
    {
        return new CreateCustomerInput(
            Constants.SalesConsultantId.Id.Format(),
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );
    }
}
