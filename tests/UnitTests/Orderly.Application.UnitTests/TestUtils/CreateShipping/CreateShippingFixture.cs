using Moq;
using Orderly.Application.UseCase;
using Orderly.Application.UseCase.Shipping.CreateShipping;
using Orderly.Domain.Shipping;
using Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Orderly.Application.UnitTests.TestUtils.CreateShipping;

public static class CreateShippingFixture
{
    public static CreateShippingUseCase CreateUseCase()
    {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var shippingRepositoryMock = new Mock<IShippingRepository>();

            return new CreateShippingUseCase(unitOfWorkMock.Object, shippingRepositoryMock.Object);
           
    }
    
    public static CreateShippingInput CreateInput()
    {
        return new CreateShippingInput(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );
    }
    
    public static CreateShippingInput CreateInvalidInput()
    {
        return new CreateShippingInput(
            "12312381731238127312",
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );
    }
}