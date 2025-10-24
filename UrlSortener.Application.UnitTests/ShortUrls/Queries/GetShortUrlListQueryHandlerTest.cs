using Moq;
using Shouldly;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlsList;
using UrlShortener.Domain.Entities;
using UrlSortener.Application.UnitTests.Base;
using UrlSortener.Application.UnitTests.Mocks;

namespace UrlSortener.Application.UnitTests.ShortUrls.Queries
{
    public class GetShortUrlListQueryHandlerTest : TestBase
    {
        private readonly Mock<IShortUrlRepository> _mockShortUrlRepository;

        public GetShortUrlListQueryHandlerTest()
        {
            _mockShortUrlRepository = ShortUrlRepositoryMock.GetShortUrlRepository();
        }

        [Fact]
        public async Task GetShortUrlList_ReturnsListOfCourses()
        {
            var handler = new GetShortUrlListQueryHandler(_mapper, _mockShortUrlRepository.Object);

            var result = await handler.Handle(new GetShortUrlListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ShortUrlListVm>>();

            result.Count.ShouldBe(2);
        }
    }
}