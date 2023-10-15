using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Domain.Manager.Repositories;

namespace Developurr.Orderly.Application.UseCase.Manager.CreateManager;

public sealed class CreateManagerUseCase : IUseCase<CreateManagerInput, CreateManagerOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IManagerRepository _managerRepository;

    public CreateManagerUseCase(IUnitOfWork unitOfWork, IManagerRepository managerRepository)
    {
        _unitOfWork = unitOfWork;
        _managerRepository = managerRepository;
    }

    public async Task<CreateManagerOutput> Handle(
        CreateManagerInput input,
        CancellationToken cancellationToken
    )
    {
        var manager = Domain.Manager.Manager.Create(
            input.Cpf,
            input.Street,
            input.Number,
            input.Complement,
            input.ZipCode,
            input.Neighborhood,
            input.City,
            input.State,
            input.Country,
            input.Name,
            input.NfeEmail,
            input.Landline,
            input.Mobile
        );

        await _managerRepository.InsertAsync(manager, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateManagerOutput(manager.Id.Format());
    }
}
