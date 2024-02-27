using BookTrack.Application.Commands.Authors.Create;
using MediatR;

namespace BookTrack.Api.Endpoints;

public static class AuthorsEndpoints
{
  public static void MapAuthorEndpoints(this IEndpointRouteBuilder app)
  {
    var group = app.MapGroup("api/authors").WithTags(nameof(AuthorsEndpoints)).WithOpenApi();

    group.MapPost("", CreateAuthor).WithName(nameof(CreateAuthor));
  }

  public static async Task<IResult> CreateAuthor(CreateAuthorCommand request, ISender sender)
  {
    var response = await sender.Send(request).ConfigureAwait(true);

    return response.IsSuccess ? Results.Ok() : Results.BadRequest();
  }
}
