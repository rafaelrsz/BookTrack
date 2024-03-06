namespace BookTrack.Application.Commands.Authors.Update;
public sealed record UpdateAuthorRequest
(
  string Name,
  string Nationality,
  DateTime BirthDate
);
