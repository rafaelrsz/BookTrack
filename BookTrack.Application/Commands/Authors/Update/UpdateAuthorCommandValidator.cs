using BookTrack.Domain.Repositories;
using FluentValidation;

namespace BookTrack.Application.Commands.Authors.Update;
public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
  public UpdateAuthorCommandValidator(IAuthorRepository repository)
  {
    RuleFor(x => x.Id)
      .NotEmpty()
      .NotEqual(Guid.NewGuid())
      .MustAsync(
      async (id, _) => await repository.GetByIdAsync(id).ConfigureAwait(false) is not null
      )
      .WithMessage("Author not found!");

    RuleFor(x => x.Nationality)
  .MaximumLength(2)
  .NotEmpty();

    RuleFor(x => x.Name)
      .MaximumLength(255)
      .NotEmpty();

    RuleFor(x => x.BirthDate)
      .LessThan(x => DateTime.Now)
    .NotEmpty();
  }
}
