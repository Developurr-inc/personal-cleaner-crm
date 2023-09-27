using Orderly.Domain.Manager;
using Orderly.Domain.Manager.ValueObjects;

namespace Orderly.Application.UseCase.Manager.GetManager;

public class GetManagerUseCase : IUseCase<GetManagerInput, GetManagerOutput>
{
    private readonly IManagerRepository _managerRepository;

    public GetManagerUseCase(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }

    public async Task<GetManagerOutput> Execute(
        GetManagerInput input,
        CancellationToken cancellationToken
    )
    {
        var manager = await _managerRepository.GetByIdAsync(input.ManagerId, cancellationToken);

        return new GetManagerOutput(
            manager.Cpf.Format(),
            manager.Address.ToString(),
            manager.Name,
            manager.Email.Format(),
            manager.Landline?.Value ?? "",
            manager.Mobile?.Value ?? ""
        );
    }
}
