using BookTrack.Application.Abstractions.Messaging;
using BookTrack.Domain.Entities;
using BookTrack.Domain.Repositories;
using BookTrack.Domain.Shared;

namespace BookTrack.Application.Commands.Authors.Create;
internal sealed class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand>
{
  private readonly IAuthorRepository _repository;
  private readonly IUnitOfWork _unitOfWork;
  public CreateAuthorCommandHandler(IAuthorRepository repository, IUnitOfWork unitOfWork)
  {
    _repository = repository;
    _unitOfWork = unitOfWork; 
  }


  public async Task<Result> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
  {
    var author = new Author(request.name,
                    request.nationality,
                    request.birthDate);

    _repository.Add(author);

    await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }
}
