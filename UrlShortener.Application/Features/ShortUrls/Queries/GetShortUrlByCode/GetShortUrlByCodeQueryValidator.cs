using FluentValidation;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlByCode
{
    public class GetShortUrlByCodeQueryValidator : AbstractValidator<GetShortUrlByCodeQuery>
    {
        public GetShortUrlByCodeQueryValidator()
        {
            RuleFor(r => r.Code)
                .NotEmpty()
                .WithMessage("Code must not be empty");
        }
    }
}