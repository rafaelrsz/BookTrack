using BookTrack.Domain.Shared;
using MediatR;

namespace BookTrack.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}