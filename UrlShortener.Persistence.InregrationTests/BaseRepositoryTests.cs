using Microsoft.EntityFrameworkCore;
using Moq;
using UrlShortener.Application.Contracts;
using UrlShortener.Domain.Entities;
using UrlShortener.Persistence.Interceptors;
using UrlShortener.Persistence.Repositories;

namespace UrlShortener.Persistence.InregrationTests
{
    public class BaseRepositoryTests
    {
        private readonly UrlShortenerDbContext _dbContext;
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        private readonly BaseRepository<ShortUrl> _repository;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly string _currentUserId;

        public BaseRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<UrlShortenerDbContext>()
                .UseInMemoryDatabase(databaseName: "UrlShortenerb")
                .Options;

            _currentUserId = "00000000-0000-0000-0000-000000000000";
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _currentUserServiceMock.Setup(m => m.UserId).Returns(_currentUserId);

            _auditableEntitySaveChangesInterceptor = new AuditableEntitySaveChangesInterceptor(_currentUserServiceMock.Object);
            _dbContext = new UrlShortenerDbContext(options, _auditableEntitySaveChangesInterceptor);

            _repository = new BaseRepository<ShortUrl>(_dbContext);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityToDatabase()
        {
            var shortUrl = new ShortUrl { OriginalUrl = "New url", CreatedDate = DateTime.UtcNow };

            var result = await _repository.AddAsync(shortUrl);

            var addedShortUrl = await _dbContext.ShortUrls.FindAsync(result.Id);
            Assert.NotNull(addedShortUrl);
            Assert.Equal("New url", addedShortUrl.OriginalUrl);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntity()
        {
            var shortUrl = new ShortUrl { OriginalUrl = "Old Url", CreatedDate = DateTime.UtcNow };
            await _repository.AddAsync(shortUrl);

            shortUrl.OriginalUrl = "Updated Url";
            await _repository.UpdateAsync(shortUrl);

            var updatedShortUrl = await _dbContext.ShortUrls.FindAsync(shortUrl.Id);
            Assert.NotNull(updatedShortUrl);
            Assert.Equal("Updated Url", updatedShortUrl.OriginalUrl);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteEntity()
        {
            var shortUrl = new ShortUrl { OriginalUrl = "Url to Delete", CreatedDate = DateTime.UtcNow };
            await _repository.AddAsync(shortUrl);

            await _repository.DeleteAsync(shortUrl);

            var deletedShortUrl = await _dbContext.ShortUrls.FindAsync(shortUrl.Id);
            Assert.Null(deletedShortUrl);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity_WhenEntityExists()
        {
            var shortUrl = new ShortUrl { OriginalUrl = "Url", CreatedDate = DateTime.UtcNow };
            await _repository.AddAsync(shortUrl);

            var result = await _repository.GetByIdAsync(shortUrl.Id);

            Assert.NotNull(result);
            Assert.Equal(shortUrl.OriginalUrl, result.OriginalUrl);
        }

        [Fact]
        public async Task ListAllAsync_ShouldReturnAllEntities()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            var shortUrl = new ShortUrl { OriginalUrl = "Url", CreatedDate = DateTime.UtcNow };
            var shortUrl2 = new ShortUrl { OriginalUrl = "Url2", CreatedDate = DateTime.UtcNow };
            await _repository.AddAsync(shortUrl);
            await _repository.AddAsync(shortUrl2);

            var result = await _repository.ListAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}