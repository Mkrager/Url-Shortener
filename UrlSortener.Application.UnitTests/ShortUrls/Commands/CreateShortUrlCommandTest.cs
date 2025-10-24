using Moq;
using Shouldly;
using System.CodeDom.Compiler;
using UrlShortener.Application.Contracts.Infrastructure;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl;
using UrlSortener.Application.UnitTests.Base;
using UrlSortener.Application.UnitTests.Mocks;

namespace UrlSortener.Application.UnitTests.ShortUrls.Commands
{
    public class CreateShortUrlCommandTest : TestBase
    {
        private readonly Mock<IShortUrlRepository> _mockShortUrlRepository;
        private readonly Mock<ICodeService> _mockCodeService; 

        public CreateShortUrlCommandTest()
        {
            _mockShortUrlRepository = ShortUrlRepositoryMock.GetShortUrlRepository();
            _mockCodeService = CodeServiceMock.GetCodeService();
        }

        [Fact]
        public async Task Should_Create_ShortUrl_Successfully()
        {
            var handler = new CreateShortUrlCommandHandler(_mapper, _mockShortUrlRepository.Object, _mockCodeService.Object);

            var courseId = Guid.NewGuid();

            var command = new CreateShortUrlCommand
            {
                OriginalUrl = "url"    
            };

            await handler.Handle(command, CancellationToken.None);

            var allShortUrl = await _mockShortUrlRepository.Object.ListAllAsync();
            allShortUrl.Count.ShouldBe(3);

            var createdLShortUrl = allShortUrl.FirstOrDefault(a => a.OriginalUrl == command.OriginalUrl);
            createdLShortUrl.ShouldNotBeNull();
            createdLShortUrl.OriginalUrl.ShouldBe(command.OriginalUrl);
        }

        [Fact]
        public async void Validator_ShouldHaveError_WhenSameUrlAlreadyExist()
        {
            var validator = new CreateShortUrlCommandValidator(_mockShortUrlRepository.Object);
            var query = new CreateShortUrlCommand
            {
                OriginalUrl = "TestOriginalUrl1"
            };

            var result = await validator.ValidateAsync(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, f => f.PropertyName == "OriginalUrl");
        }

        [Fact]
        public async void Validator_ShouldHaveError_WhenEmptyOriginalUrl()
        {
            var validator = new CreateShortUrlCommandValidator(_mockShortUrlRepository.Object);
            var query = new CreateShortUrlCommand
            {
                OriginalUrl = ""
            };

            var result = await validator.ValidateAsync(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, f => f.PropertyName == "OriginalUrl");
        }
    }
}