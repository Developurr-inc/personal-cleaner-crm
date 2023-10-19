using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Vendor.CreateVendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.CreateVendor;

public static class CreateVendorFixture
{
    public static CreateVendorUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var input = CreateInput();

        return new CreateVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
    }
    
    public static CreateVendorInput CreateInput()
    {
        return new CreateVendorInput(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );
    }
    
    public static CreateVendorInput CreateInvalidInput()
    {
        return new CreateVendorInput(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );
    }
}