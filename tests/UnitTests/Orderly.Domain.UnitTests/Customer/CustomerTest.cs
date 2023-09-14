using Orderly.Domain.UnitTests.TestUtils.Customer;

namespace Orderly.Domain.UnitTests.Customer;

public sealed class CustomerTest
{
    [Theory]
    [MemberData(
        nameof(CustomerGenerator.CreateCustomers),
        MemberType = typeof(CustomerGenerator)
    )]
    public void WhenCreatingCustomer_GivenValidInputs_ShouldInstantiateCustomer(
        Domain.Customer.Customer customer
    )
    {
        // Arrange
        //var salesConsultantId = customer.SalesConsultant;
        var cnpj = customer.Cnpj;
        var corporateName = customer.CorporateName;
        var taxId = customer.TaxId;
        var tradeName = customer.TradeName;
        var segment = customer.Segment;
        var billingEmail = customer.BillingEmail;
        var nfeEmail = customer.NfeEmail;
        var landline = customer.Landline;
        var mobile = customer.Mobile;
        var observation = customer.Observation;

        // Act
        var newCustomer = Domain.Customer.Customer.Create(
            // salesConsultant,
            cnpj,
            corporateName,
            taxId,
            tradeName,
            segment,
            billingEmail,
            nfeEmail,
            landline,
            mobile,
            observation
        );

        // Assert
        CustomerAssertion.AssertCustomer(customer, newCustomer);
    }



    [Theory]
    [MemberData(
        nameof(CustomerGenerator.CreateInvalidCorporateNames),
        MemberType = typeof(CustomerGenerator)
    )]
    public void WhenCreatingCustomer_GivenInvalidCorporateName_ShouldThrowException(
        string invalidCorporateName
    )
    {
        // Arrange
        var customer = CustomerFixture.CreateCustomer();

        //var salesConsultantId = customer.SalesConsultant;
        var cnpj = customer.Cnpj;
        var corporateName = invalidCorporateName;
        var taxId = customer.TaxId;
        var tradeName = customer.TradeName;
        var segment = customer.Segment;
        var billingEmail = customer.BillingEmail;
        var nfeEmail = customer.NfeEmail;
        var landline = customer.Landline;
        var mobile = customer.Mobile;
        var observation = customer.Observation;

        void Action()
        {
            _ = Domain.Customer.Customer.Create(
                // salesConsultant,
                cnpj,
                corporateName,
                taxId,
                tradeName,
                segment,
                billingEmail,
                nfeEmail,
                landline,
                mobile,
                observation
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception);
    }


    [Theory]
    [MemberData(
        nameof(CustomerGenerator.CreateInvalidTaxIds),
        MemberType = typeof(CustomerGenerator)
    )]
    public void WhenCreatingCustomer_GivenInvalidTaxId_ShouldThrowException(
        string invalidTaxId
    )
    {
        // Arrange
        var customer = CustomerFixture.CreateCustomer();

        //var salesConsultantId = customer.SalesConsultant;
        var cnpj = customer.Cnpj;
        var corporateName = customer.CorporateName;
        var taxId = invalidTaxId;
        var tradeName = customer.TradeName;
        var segment = customer.Segment;
        var billingEmail = customer.BillingEmail;
        var nfeEmail = customer.NfeEmail;
        var landline = customer.Landline;
        var mobile = customer.Mobile;
        var observation = customer.Observation;

        void Action()
        {
            _ = Domain.Customer.Customer.Create(
                // salesConsultant,
                cnpj,
                corporateName,
                taxId,
                tradeName,
                segment,
                billingEmail,
                nfeEmail,
                landline,
                mobile,
                observation
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception);
    }


    [Theory]
    [MemberData(
        nameof(CustomerGenerator.CreateInvalidTradeNames),
        MemberType = typeof(CustomerGenerator)
    )]
    public void WhenCreatingCustomer_GivenInvalidTradeName_ShouldThrowException(
        string invalidTradeName
    )
    {
        // Arrange
        var customer = CustomerFixture.CreateCustomer();

        //var salesConsultantId = customer.SalesConsultant;
        var cnpj = customer.Cnpj;
        var corporateName = customer.CorporateName;
        var taxId = customer.TaxId;
        var tradeName = invalidTradeName;
        var segment = customer.Segment;
        var billingEmail = customer.BillingEmail;
        var nfeEmail = customer.NfeEmail;
        var landline = customer.Landline;
        var mobile = customer.Mobile;
        var observation = customer.Observation;

        void Action()
        {
            _ = Domain.Customer.Customer.Create(
                // salesConsultant,
                cnpj,
                corporateName,
                taxId,
                tradeName,
                segment,
                billingEmail,
                nfeEmail,
                landline,
                mobile,
                observation
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception);
    }


    [Theory]
    [MemberData(
        nameof(CustomerGenerator.CreateInvalidSegments),
        MemberType = typeof(CustomerGenerator)
    )]
    public void WhenCreatingCustomer_GivenInvalidSegment_ShouldThrowException(
        string invalidSegment
    )
    {
        // Arrange
        var customer = CustomerFixture.CreateCustomer();

        //var salesConsultantId = customer.SalesConsultant;
        var cnpj = customer.Cnpj;
        var corporateName = customer.CorporateName;
        var taxId = customer.TaxId;
        var tradeName = customer.TradeName;
        var segment = invalidSegment;
        var billingEmail = customer.BillingEmail;
        var nfeEmail = customer.NfeEmail;
        var landline = customer.Landline;
        var mobile = customer.Mobile;
        var observation = customer.Observation;

        void Action()
        {
            _ = Domain.Customer.Customer.Create(
                // salesConsultant,
                cnpj,
                corporateName,
                taxId,
                tradeName,
                segment,
                billingEmail,
                nfeEmail,
                landline,
                mobile,
                observation
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception);
    }


    [Theory]
    [MemberData(
        nameof(CustomerGenerator.CreateInvalidObservations),
        MemberType = typeof(CustomerGenerator)
    )]
    public void WhenCreatingCustomer_GivenInvalidObservation_ShouldThrowException(
        string invalidObservation
    )
    {
        // Arrange
        var customer = CustomerFixture.CreateCustomer();

        //var salesConsultantId = customer.SalesConsultant;
        var cnpj = customer.Cnpj;
        var corporateName = customer.CorporateName;
        var taxId = customer.TaxId;
        var tradeName = customer.TradeName;
        var segment = customer.Segment;
        var billingEmail = customer.BillingEmail;
        var nfeEmail = customer.NfeEmail;
        var landline = customer.Landline;
        var mobile = customer.Mobile;
        var observation = invalidObservation;

        void Action()
        {
            _ = Domain.Customer.Customer.Create(
                // salesConsultant,
                cnpj,
                corporateName,
                taxId,
                tradeName,
                segment,
                billingEmail,
                nfeEmail,
                landline,
                mobile,
                observation
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CustomerAssertion.AssertCustomerException(exception);
    }
}