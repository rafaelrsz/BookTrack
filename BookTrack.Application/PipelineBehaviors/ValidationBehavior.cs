using FluentValidation;
using MediatR;

namespace BookTrack.Application.PipelineBehaviors;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  where TRequest : IRequest<TResponse>
{
  private readonly IEnumerable<IValidator<TRequest>> _validations;

  public ValidationBehavior(IEnumerable<IValidator<TRequest>> validations)
  {
    _validations = validations;
  }

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    var context = new ValidationContext<TRequest>(request);

    var failures = (await Task.WhenAll(_validations
      .Select(async x => await x.ValidateAsync(context).ConfigureAwait(false))).ConfigureAwait(false))
      .SelectMany(x => x.Errors)
      .Where(x => x != null);

    if (failures.Any())
      throw new ValidationException(failures);

    return await next().ConfigureAwait(false);
  }
}
