using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Customer.CreateCustomer;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.CreateCustomer;

public static class CreateCustomerFixture
{
    public static CreateCustomerUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var input = CreateInput();

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(VendorFixture.CreateVendor());

        return new CreateCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
    }

    public static CreateCustomerInput CreateInput()
    {
        return new CreateCustomerInput(
            Constants.VendorId.Id.ToString(),
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
            Constants.VendorId.Id.ToString(),
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            "a@a.",
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );
    }
}
