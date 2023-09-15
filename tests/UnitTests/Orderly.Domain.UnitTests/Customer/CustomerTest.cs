using Orderly.Domain.UnitTests.TestUtils.Customer;

namespace Orderly.Domain.UnitTests.Customer;

public sealed class CustomerTest
{
    [Theory]
    [MemberData(nameof(CustomerGenerator.CreateCustomers), MemberType = typeof(CustomerGenerator))]
    public void GivenValidInputs_WhenCreatingCustomer_ThenShouldInstantiateCustomer(
        Domain.Customer.Customer customer
    )
    {
        // Act
        var newCustomer = CustomerFixture.CreateCustomer(customer: customer);

        // Assert
        CustomerAssertion.AssertCustomer(customer, newCustomer);
    }
    

    [Theory]
    [MemberData(nameof(CustomerGenerator.CreateInvalidCorporateNames), MemberType = typeof(CustomerGenerator))]
    public void GivenInvalidCorporateName_WhenCreatingCustomer_ThenShouldThrowException(
        string invalidCorporateName
    )
    {
        // Arrange
        void Action()
        {
            _ = CustomerFixture.CreateCustomer(
                corporateName: invalidCorporateName
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception!);
    }


    [Theory]
    [MemberData(nameof(CustomerGenerator.CreateInvalidTaxIds), MemberType = typeof(CustomerGenerator))]
    public void GivenInvalidTaxId_WhenCreatingCustomer_ThenShouldThrowException(
        string invalidTaxId
    )
    {
        // Arrange
        void Action()
        {
            _ = CustomerFixture.CreateCustomer(taxId: invalidTaxId);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception!);
    }


    [Theory]
    [MemberData(nameof(CustomerGenerator.CreateInvalidTradeNames), MemberType = typeof(CustomerGenerator))]
    public void GivenInvalidTradeName_WhenCreatingCustomer_ThenShouldThrowException(
        string invalidTradeName
    )
    {
        // Arrange
        void Action()
        {
            _ = CustomerFixture.CreateCustomer(tradeName: invalidTradeName);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception!);
    }


    [Theory]
    [MemberData(nameof(CustomerGenerator.CreateInvalidSegments), MemberType = typeof(CustomerGenerator))]
    public void GivenInvalidSegment_WhenCreatingCustomer_ThenShouldThrowException(
        string invalidSegment
    )
    {
        // Arrange
        void Action()
        {
            _ = CustomerFixture.CreateCustomer(segment: invalidSegment);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception!);
    }


    [Theory]
    [MemberData(nameof(CustomerGenerator.CreateInvalidObservations), MemberType = typeof(CustomerGenerator))]
    public void GivenInvalidObservation_WhenCreatingCustomer_ThenShouldThrowException(
        string invalidObservation
    )
    {
        // Arrange
        void Action()
        {
            _ = CustomerFixture.CreateCustomer(observation: invalidObservation);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception!);
    }
}