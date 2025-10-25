using FluentValidation;

namespace UrlShortener.Application.Features.AboutPages.Commands.UpdateAboutPage
{
    public class UpdateAboutPageCommandValdiator : AbstractValidator<UpdateAboutPageCommand>
    {
        public UpdateAboutPageCommandValdiator()
        {
            RuleFor(r => r.Content)
                .NotEmpty().WithMessage("Content must not be empty");
        }
    }
}
