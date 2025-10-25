using Moq;
using Shouldly;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails;
using UrlSortener.Application.UnitTests.Base;
using UrlSortener.Application.UnitTests.Mocks;

namespace UrlSortener.Application.UnitTests.ShortUrls.Queries
{
    public class GetShortUrlDetailsQueryHandlerTest : TestBase
    {
        private readonly Mock<IShortUrlRepository> _mockShortUrlRepository;

        public GetShortUrlDetailsQueryHandlerTest()
        {
            _mockShortUrlRepository = ShortUrlRepositoryMock.GetShortUrlRepository();
        }

        [Fact]
        public async Task GetShortUrlDetails_ReturnsCorrectShortUrlDetails()
        {
            var handler = new GetShortUrlDetailQueryHandler(_mockShortUrlRepository.Object, _mapper);

            var result = await handler.Handle(new GetShortUrlDetailQuery() { Id = Guid.Parse("3f2a3a3e-27c9-4b65-bfb4-2b1e3d4b54ee") }, CancellationToken.None);

            result.ShouldBeOfType<ShortUrlDetailVm>();

            result.Id.ShouldBe(Guid.Parse("3f2a3a3e-27c9-4b65-bfb4-2b1e3d4b54ee"));
        }
    }
}