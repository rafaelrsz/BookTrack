using BookTrack.Application.Abstractions.Messaging;

namespace BookTrack.Application.Commands.Authors.Delete;
public sealed record DeleteAuthorCommand 
(
Guid Id  
) : ICommand;