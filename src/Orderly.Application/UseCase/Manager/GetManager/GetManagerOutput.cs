namespace Orderly.Application.UseCase.Manager.GetManager;

public record GetManagerOutput(
    string Cpf,
    string Address,
    string Name,
    string Email,
    string? Landline,
    string? Mobile
);