using BookTrack.Application.Abstractions.Messaging;
using BookTrack.Domain.Repositories;
using BookTrack.Domain.Shared;
using System.Security.Cryptography.X509Certificates;

namespace BookTrack.Application.Commands.Authors.Delete;
internal class DeleteAuthorCommandHandler : ICommandHandler<DeleteAuthorCommand>
{
  private readonly IAuthorRepository _repository;
  private readonly IUnitOfWork _unitOfWork;

  public DeleteAuthorCommandHandler(IAuthorRepository repository, IUnitOfWork unitOfWork)
  {
    _repository = repository;
    _unitOfWork = unitOfWork;
  }

  public async Task<Result> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
  {
    await _repository.DeleteAsync(request.Id).ConfigureAwait(false);

    await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }
}
