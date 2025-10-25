using FluentValidation;

namespace UrlShortener.Application.Features.AboutPages.Commands.UpdateAboutPage
{
    public class UpdateAboutPageCommandValidator : AbstractValidator<UpdateAboutPageCommand>
    {
        public UpdateAboutPageCommandValidator()
        {
            RuleFor(r => r.Content)
                .NotEmpty().WithMessage("Content must not be empty");
        }
    }
}
