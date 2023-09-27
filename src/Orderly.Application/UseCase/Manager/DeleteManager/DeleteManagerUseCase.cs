using Orderly.Domain.Manager;

namespace Orderly.Application.UseCase.Manager.DeleteManager;

public class DeleteManagerUseCase : IUseCase<DeleteManagerInput, DeleteManagerOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IManagerRepository _managerRepository;

    public DeleteManagerUseCase(IUnitOfWork unitOfWork, IManagerRepository managerRepository)
    {
        _unitOfWork = unitOfWork;
        _managerRepository = managerRepository;
    }

    public async Task<DeleteManagerOutput> Execute(
        DeleteManagerInput input,
        CancellationToken cancellationToken
    )
    {
        var manager = await _managerRepository.GetByIdAsync(input.ManagerId, cancellationToken);
        await _managerRepository.RemoveAsync(manager, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteManagerOutput(manager.Id.Format());
    }
}
