using BookTrack.Application.Abstractions.Messaging;
using BookTrack.Domain.Entities;
using BookTrack.Domain.Repositories;
using BookTrack.Domain.Shared;

namespace BookTrack.Application.Commands.Authors.Create;
internal sealed class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand, Guid>
{
  private readonly IAuthorRepository _repository;
  private readonly IUnitOfWork _unitOfWork;
  public CreateAuthorCommandHandler(IAuthorRepository repository, IUnitOfWork unitOfWork)
  {
    _repository = repository;
    _unitOfWork = unitOfWork; 
  }


  public async Task<Result<Guid>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
  {
    var author = new Author(request.Name,
                    request.Nationality,
                    request.BirthDate);

    _repository.Add(author);

    await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return Result.Success(author.Id);
  }
}
