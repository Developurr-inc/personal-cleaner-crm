namespace Developurr.Orderly.Application.Command.Vendor.CreateVendor;

public record CreateVendorInput(
    string Cpf,
    string Street,
    int Number,
    string Complement,
    string ZipCode,
    string Neighborhood,
    string City,
    string State,
    string Country,
    string Name,
    string Email,
    string? Landline,
    string? Mobile
);
