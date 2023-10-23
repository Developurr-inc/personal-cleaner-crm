using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Domain.Manager.Repositories;

namespace Developurr.Orderly.Application.UseCase.Manager.DeleteManager;

public class DeleteManagerUseCase : IUseCase<DeleteManagerInput, DeleteManagerOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IManagerRepository _managerRepository;

    public DeleteManagerUseCase(IUnitOfWork unitOfWork, IManagerRepository managerRepository)
    {
        _unitOfWork = unitOfWork;
        _managerRepository = managerRepository;
    }

    public async Task<DeleteManagerOutput> Handle(
        DeleteManagerInput input,
        CancellationToken cancellationToken
    )
    {
        var manager = await _managerRepository.GetByIdAsync(input.ManagerId, cancellationToken);

        if (manager is null)
            throw new IdNotFoundException(input.ManagerId);

        await _managerRepository.RemoveAsync(manager, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteManagerOutput(manager.Id.ToString());
    }
}
