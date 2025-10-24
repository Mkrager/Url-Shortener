using Moq;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Domain.Entities;

namespace UrlSortener.Application.UnitTests.Mocks
{
    public class ShortUrlRepositoryMock
    {
        public static Mock<IShortUrlRepository> GetShortUrlRepository()
        {
            var shortUrls = new List<ShortUrl>
            {
                new ShortUrl 
                { 
                    Id = Guid.Parse("3f2a3a3e-27c9-4b65-bfb4-2b1e3d4b54ee"),
                    OriginalUrl = "TestOriginalUrl1",
                },
                new ShortUrl 
                {
                    Id = Guid.Parse("c1e9a0b2-5f3d-4427-8a3f-6db42c948ce4"),
                    OriginalUrl = "TestOriginalUrl2",
                    CreatedBy = "userId"
                }
            };

            var mockRepository = new Mock<IShortUrlRepository>();

            mockRepository.Setup(r => r.ListAllAsync())
                .ReturnsAsync(shortUrls);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => shortUrls.FirstOrDefault(x => x.Id == id));

            mockRepository.Setup(r => r.IsUrlUniqueAsync(It.IsAny<string>()))
                .ReturnsAsync((string originalUrl) => !shortUrls.Any(r => r.OriginalUrl == originalUrl));

            mockRepository.Setup(r => r.GetShortUrlByCodeAsync(It.IsAny<string>()))
                .ReturnsAsync((string code) => shortUrls.FirstOrDefault(r => r.ShortCode == code));

            mockRepository.Setup(r => r.AddAsync(It.IsAny<ShortUrl>()))
                .ReturnsAsync((ShortUrl shortUrl) =>
                {
                    shortUrls.Add(shortUrl);
                    return shortUrl;
                });

            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<ShortUrl>()))
                .Callback((ShortUrl shortUrl) => shortUrls.Remove(shortUrl));

            return mockRepository;
        }
    }
}