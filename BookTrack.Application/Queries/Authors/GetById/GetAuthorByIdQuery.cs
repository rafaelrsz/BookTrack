using BookTrack.Application.Abstractions.Messaging;
using BookTrack.Domain.Entities;
using BookTrack.Domain.Shared;

namespace BookTrack.Application.Queries.Authors.GetById;

public record GetAuthorByIdQuery(
  Guid Id
  ) : IQuery<Author>;
