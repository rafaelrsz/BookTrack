using BookTrack.Application.Abstractions.Messaging;

namespace BookTrack.Application.Commands.Authors.Create;
public sealed record CreateAuthorCommand(
  string name,
  string nationality,
  DateTime birthDate
  ) : ICommand;
