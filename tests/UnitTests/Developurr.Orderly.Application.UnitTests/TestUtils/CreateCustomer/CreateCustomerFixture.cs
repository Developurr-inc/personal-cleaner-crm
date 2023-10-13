using Developurr.Orderly.Application.UseCase;
using Developurr.Orderly.Application.UseCase.Customer.CreateCustomer;
using Developurr.Orderly.Domain.Customer;
using Developurr.Orderly.Domain.SalesConsultant;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.SalesConsultant;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.CreateCustomer;

public static class CreateCustomerFixture
{
    public static CreateCustomerUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        
        salesConsultantRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(SalesConsultantFixture.CreateSalesConsultant());

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
    
    public static CreateCustomerInput CreateInvalidInput()
    {
        return new CreateCustomerInput(
            Constants.SalesConsultantId.Id.Format(),
            "12312381731238127312",
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
