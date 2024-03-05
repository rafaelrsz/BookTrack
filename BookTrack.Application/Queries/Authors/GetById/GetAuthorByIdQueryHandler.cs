using BookTrack.Application.Abstractions.Messaging;
using BookTrack.Domain.Entities;
using BookTrack.Domain.Repositories;
using BookTrack.Domain.Shared;

namespace BookTrack.Application.Queries.Authors.GetById;
internal sealed class GetAuthorByIdQueryHandler : IQueryHandler<GetAuthorByIdQuery, Author>
{
  public IAuthorRepository _repository;

  public GetAuthorByIdQueryHandler(IAuthorRepository repository)
  {
    _repository = repository;
  }

  public async Task<Result<Author>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
  {
    return await _repository.GetByIdAsync(request.Id).ConfigureAwait(false);
  }
}
