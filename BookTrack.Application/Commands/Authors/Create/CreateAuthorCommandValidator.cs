using BookTrack.Domain.Repositories;
using FluentValidation;
using System.Xml.Linq;

namespace BookTrack.Application.Commands.Authors.Create;
public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
  public CreateAuthorCommandValidator(IAuthorRepository repository)
  {
    RuleFor(x => x.Nationality)
      .MaximumLength(2)
      .NotEmpty();

    RuleFor(x => x.Name)
      .MaximumLength(255)
      .NotEmpty();

    RuleFor(x => x.BirthDate)
      .LessThan(x => DateTime.Now)
    .NotEmpty();

    RuleFor(x => x.Name).MustAsync(
      async (name, _) => await repository.IsNameUniqueAsync(name)
                                          .ConfigureAwait(false)
      ).WithMessage("The name must be unique");
  }
}
