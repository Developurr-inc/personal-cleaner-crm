namespace Orderly.Application.UseCase.SalesConsultant.CreateSalesConsultant;

public record CreateSalesConsultantInput(
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
