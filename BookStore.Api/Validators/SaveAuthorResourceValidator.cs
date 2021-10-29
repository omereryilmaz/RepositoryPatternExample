using BookStore.Api.DTO;
using FluentValidation;

namespace BookStore.Api.Validators
{
    public class SaveAuthorResourceValidator : AbstractValidator<SaveAuthorDTO>
    {
        public SaveAuthorResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
