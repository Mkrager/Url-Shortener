using Moq;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Domain.Entities;

namespace UrlSortener.Application.UnitTests.Mocks
{
    public class AboutPageRepositoryMock
    {
        public static Mock<IAsyncRepository<AboutPage>> GetAboutPageRepository()
        {
            var aboutPages = new List<AboutPage>
            {
                new AboutPage
                {
                    Id = Guid.Parse("cf140332-bddc-424e-8550-fd65bee52e78"),
                    Content = "testContent"
                },
            };

            var mockRepository = new Mock<IAsyncRepository<AboutPage>>();

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => aboutPages.FirstOrDefault(x => x.Id == id));

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<AboutPage>()))
                .Callback((AboutPage aboutPage) =>
                {
                    var oldAboutPage = aboutPages.FirstOrDefault(x => x.Id == aboutPage.Id);
                    if (oldAboutPage != null)
                    {
                        oldAboutPage.Content = oldAboutPage.Content;
                    }
                });

            return mockRepository;
        }
    }
}
