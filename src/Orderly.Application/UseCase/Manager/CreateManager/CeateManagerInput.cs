namespace Orderly.Application.UseCase.Manager.CreateManager;

public record CreateManagerInput(
    string Cpf,
    string Street,
    int  Number,
    string Complement,
    string ZipCode,
    string Neighborhood,
    string City,
    string State,
    string Country,
    string Name,
    string NfeEmail,
    string? Landline,
    string? Mobile
);