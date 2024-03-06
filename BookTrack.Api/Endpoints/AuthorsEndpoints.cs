using BookTrack.Application.Commands.Authors.Create;
using BookTrack.Application.Commands.Authors.Delete;
using BookTrack.Application.Commands.Authors.Update;
using BookTrack.Application.Queries.Authors.GetById;
using MediatR;

namespace BookTrack.Api.Endpoints;

public static class AuthorsEndpoints
{
  public static void MapAuthorEndpoints(this IEndpointRouteBuilder app)
  {
    var group = app.MapGroup("api/authors").WithTags(nameof(AuthorsEndpoints)).WithOpenApi();

    group.MapGet("{id:guid}", GetById).WithName(nameof(GetById));
    group.MapPost("", CreateAuthor).WithName(nameof(CreateAuthor));
    group.MapPut("{id:guid}", UpdateAuthor).WithName(nameof(UpdateAuthor));
    group.MapDelete("{id:guid}", DeleteAuthor).WithName(nameof(DeleteAuthor));
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

  public static async Task<IResult> DeleteAuthor(Guid id, ISender sender)
  {
    var command = new DeleteAuthorCommand(id);

    var response = await sender.Send(command).ConfigureAwait(false);

    return response.IsSuccess ? Results.NoContent() : Results.BadRequest();
  }

  public static async Task<IResult> UpdateAuthor(Guid id, UpdateAuthorRequest request, ISender sender)
  {
    var command = new UpdateAuthorCommand(id, request.Name, request.Nationality, request.BirthDate);

    var response = await sender.Send(command).ConfigureAwait(false);

    return response.IsSuccess ? Results.NoContent() : Results.BadRequest();
  }
}
