using BookStore.Api.DTO;
using FluentValidation;

namespace BookStore.Api.Validators
{
    public class SaveBookResourceValidator : AbstractValidator<SaveBookDTO>
    {
        public SaveBookResourceValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(b => b.AuthorId)
                .NotEmpty()
                .WithMessage("Author Id must not be 0.");
        }
    }
}
