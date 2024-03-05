using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookTrack.Application.Middlewares;
public class ValidationMappingMiddleware : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    try
    {
      await next(context).ConfigureAwait(false);
    }
    catch (ValidationException ex) {
      context.Response.StatusCode = StatusCodes.Status400BadRequest;

      await context.Response.WriteAsJsonAsync(ex.Errors.Select(p => new { p.PropertyName, p.ErrorMessage }))
                            .ConfigureAwait(false);
    }
  }
}
