using BookTrack.Application.Abstractions.Messaging;
using BookTrack.Domain.Entities;
using BookTrack.Domain.Repositories;
using BookTrack.Domain.Shared;

namespace BookTrack.Application.Commands.Authors.Update;
internal sealed class UpdateAuthorCommandHandler : ICommandHandler<UpdateAuthorCommand>
{
  public readonly IAuthorRepository _repository;
  public readonly IUnitOfWork _unitOfWork;

  public UpdateAuthorCommandHandler(IAuthorRepository repository, IUnitOfWork unitOfWork)
  {
    _repository = repository;
    _unitOfWork = unitOfWork;
  }

  public async Task<Result> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
  {
    var oldAuthor = await _repository.GetByIdAsyncAsNoTracking(request.Id).ConfigureAwait(false);

    var updatedAuthor = new Author(request.Name, request.Nationality, request.BirthDate, oldAuthor.Id);

    _repository.Update(updatedAuthor);

    await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }
}
