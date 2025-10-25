using Moq;
using Shouldly;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Features.AboutPages.Queries.GetAboutPage;
using UrlShortener.Domain.Entities;
using UrlSortener.Application.UnitTests.Base;
using UrlSortener.Application.UnitTests.Mocks;

namespace UrlSortener.Application.UnitTests.AboutPages.Queries
{
    public class GetAboutPageQueryHandlerTests : TestBase
    {
        private readonly Mock<IAsyncRepository<AboutPage>> _aboutPageRepository;

        public GetAboutPageQueryHandlerTests()
        {
            _aboutPageRepository = AboutPageRepositoryMock.GetAboutPageRepository();
        }

        [Fact]
        public async Task GetAboutPageReturnsCorrectAboutPage()
        {
            var handler = new GetAboutPageQueryHandler(_aboutPageRepository.Object, _mapper);

            var result = await handler.Handle(new GetAboutPageQuery(), CancellationToken.None);

            result.ShouldBeOfType<AboutPageVm>();

            result.Content.ShouldBe("testContent");
        }
    }
}