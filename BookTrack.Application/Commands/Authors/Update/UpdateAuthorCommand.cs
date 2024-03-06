using BookTrack.Application.Abstractions.Messaging;

namespace BookTrack.Application.Commands.Authors.Update;
public sealed record UpdateAuthorCommand
(
  Guid Id,
  string Name,
  string Nationality,
  DateTime BirthDate
) : ICommand;