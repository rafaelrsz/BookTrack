using BookTrack.Application.Commands.Authors.Create;
using BookTrack.Application.Queries.Authors.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookTrack.Api.Endpoints;

public static class AuthorsEndpoints
{
  public static void MapAuthorEndpoints(this IEndpointRouteBuilder app)
  {
    var group = app.MapGroup("api/authors").WithTags(nameof(AuthorsEndpoints)).WithOpenApi();

    group.MapGet("{id:guid}", GetById).WithName(nameof(GetById));
    group.MapPost("", CreateAuthor).WithName(nameof(CreateAuthor));
  }

  public static async Task<IResult> GetById(Guid id, ISender sender)
  {
    var query = new GetAuthorByIdQuery(id);
    var response = await sender.Send(query).ConfigureAwait(false);

    return Results.Ok(response.Value);
  }

  public static async Task<IResult> CreateAuthor(CreateAuthorCommand request, ISender sender)
  {
    var response = await sender.Send(request).ConfigureAwait(true);

    return response.IsSuccess ? Results.CreatedAtRoute(nameof(GetById),
                                                       new { id = response.Value },
                                                       response.Value) : Results.BadRequest();
  }
}
