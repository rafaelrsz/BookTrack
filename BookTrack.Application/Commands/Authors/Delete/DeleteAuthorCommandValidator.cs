using BookTrack.Application.Commands.Authors.Delete;
using BookTrack.Domain.Repositories;
using FluentValidation;

namespace BookTrack.Application.Commands.Authors.Delete;
public class DeleteAuthorCommandValidator: AbstractValidator<DeleteAuthorCommand>
{
  public DeleteAuthorCommandValidator(IAuthorRepository repository)
  {
    RuleFor(x => x.Id)
      .NotEmpty()
      .MustAsync(
      async (id, _) => await repository.GetByIdAsync(id)
                                       .ConfigureAwait(false) is not null)
      .WithMessage("Author not found!");
  }
}
