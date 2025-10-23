using EmptyFiles;
using Microsoft.EntityFrameworkCore;
using Moq;
using UrlShortener.Application.Contracts;
using UrlShortener.Domain.Entities;
using UrlShortener.Persistence.Interceptors;
using UrlShortener.Persistence.Repositories;

namespace UrlShortener.Persistence.InregrationTests
{
    public class ShortUrlRepositoryTests
    {
        private readonly UrlShortenerDbContext _dbContext;
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        private readonly ShortUrlRepository _repository;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly string _currentUserId;

        public ShortUrlRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<UrlShortenerDbContext>()
                .UseInMemoryDatabase(databaseName: "UrlShortener")
                .Options;

            _currentUserId = "00000000-0000-0000-0000-000000000000";
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _currentUserServiceMock.Setup(m => m.UserId).Returns(_currentUserId);

            _auditableEntitySaveChangesInterceptor = new AuditableEntitySaveChangesInterceptor(_currentUserServiceMock.Object);
            _dbContext = new UrlShortenerDbContext(options, _auditableEntitySaveChangesInterceptor);

            _repository = new ShortUrlRepository(_dbContext);
        }

        [Fact]
        public async Task CheckIsUrlUnique_ReturnsFalseWhenNotUnique()
        {
            var shortUrl1 = new ShortUrl { Id = Guid.NewGuid(), OriginalUrl = "testUrl" };

            _dbContext.ShortUrls.Add(shortUrl1);
            await _dbContext.SaveChangesAsync();

            var result = await _repository.IsUrlUniqueAsync("testUrl");
            Assert.False(result);
        }
    }
}
