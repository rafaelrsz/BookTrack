using BookTrack.Domain.Shared;
using MediatR;

namespace BookTrack.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}