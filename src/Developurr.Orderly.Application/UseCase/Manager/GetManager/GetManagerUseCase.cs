using Developurr.Orderly.Domain.Manager.Repositories;

namespace Developurr.Orderly.Application.UseCase.Manager.GetManager;

public class GetManagerUseCase : IUseCase<GetManagerInput, GetManagerOutput>
{
    private readonly IManagerRepository _managerRepository;

    public GetManagerUseCase(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }

    public async Task<GetManagerOutput> Handle(
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
