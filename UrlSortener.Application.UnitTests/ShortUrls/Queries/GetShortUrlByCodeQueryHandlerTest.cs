using Moq;
using Shouldly;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlByCode;
using UrlSortener.Application.UnitTests.Mocks;

namespace UrlSortener.Application.UnitTests.ShortUrls.Queries
{
    public class GetShortUrlByCodeQueryHandlerTest
    {
        private readonly Mock<IShortUrlRepository> _shortUrlRepository;
        public GetShortUrlByCodeQueryHandlerTest()
        {
            _shortUrlRepository = ShortUrlRepositoryMock.GetShortUrlRepository();
        }

        [Fact]
        public async Task GetShortUrlByCode_ReturnsCorrectShortUrl()
        {
            var handler = new GetShortUrlByCodeQueryHandler(_shortUrlRepository.Object);

            var result = await handler.Handle(new GetShortUrlByCodeQuery() { Code = "123456" }, CancellationToken.None);

            result.ShouldBeOfType<string>();

            result.ShouldBe("TestOriginalUrl1");
        }

        [Fact]
        public async void Validator_ShouldHaveError_WhenEmptyCode()
        {
            var validator = new GetShortUrlByCodeQueryValidator();
            var query = new GetShortUrlByCodeQuery
            {
                Code = ""
            };

            var result = await validator.ValidateAsync(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, f => f.PropertyName == "Code");
        }

    }
}
