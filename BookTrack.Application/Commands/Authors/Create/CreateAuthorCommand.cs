using BookTrack.Application.Abstractions.Messaging;

namespace BookTrack.Application.Commands.Authors.Create;
public sealed record CreateAuthorCommand(
  string Name,
  string Nationality,
  DateTime BirthDate
  ) : ICommand<Guid>;
