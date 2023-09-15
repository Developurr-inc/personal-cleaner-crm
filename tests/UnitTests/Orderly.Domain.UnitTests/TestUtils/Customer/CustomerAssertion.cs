using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Customer;

public static class CustomerAssertion
{
    public static void AssertCustomer(
        Domain.Customer.Customer expected,
        Domain.Customer.Customer actual
    )
    {
        Assert.NotNull(actual);
        Assert.NotNull(actual.Id);
        Assert.NotEqual(actual.Id.Value, default);
        // Assert.Equal(expected.Orders, actual.Orders);
        // Assert.Equal(expected.Seller, actual.Seller);
        Assert.Equal(expected.Cnpj, actual.Cnpj);
        Assert.Equal(expected.CorporateName, actual.CorporateName);
        Assert.Equal(expected.TaxId, actual.TaxId);
        Assert.Equal(expected.TradeName, actual.TradeName);
        Assert.Equal(expected.Segment, actual.Segment);
        Assert.Equal(expected.BillingEmail, actual.BillingEmail);
        Assert.Equal(expected.NfeEmail, actual.NfeEmail);
        Assert.Equal(expected.Landline, actual.Landline);
        Assert.Equal(expected.Mobile, actual.Mobile);
        Assert.Equal(expected.Observation, actual.Observation);
        Assert.NotEqual(actual.CreatedAt, default);
    }


    public static void AssertCustomerException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);

        var entityValidationException = (EntityValidationException)exception;

        Assert.NotEmpty(entityValidationException.Errors);
    }
}