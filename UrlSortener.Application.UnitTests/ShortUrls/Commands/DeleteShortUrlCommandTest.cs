using Moq;
using Shouldly;
using UrlShortener.Application.Contracts.Application;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Features.ShortUrls.Commands.DeleteShortUrl;
using UrlSortener.Application.UnitTests.Mocks;

namespace UrlSortener.Application.UnitTests.ShortUrls.Commands
{
    public class DeleteShortUrlCommandTest
    {
        private readonly Mock<IShortUrlRepository> _mockShortUrlRepository;
        private readonly Mock<IPermissionService> _mockPermissionService;

        public DeleteShortUrlCommandTest()
        {
            _mockShortUrlRepository = ShortUrlRepositoryMock.GetShortUrlRepository();
            _mockPermissionService = PermissionServiceMock.GetPermissionService();
        }

        [Fact]
        public async Task Should_Delete_ShortUrl_Successfully()
        {
            var handler = new DeleteShortUrlCommandHandler(_mockShortUrlRepository.Object);

            var result = handler.Handle(new DeleteShortUrlCommand() 
            { 
                Id = Guid.Parse("c1e9a0b2-5f3d-4427-8a3f-6db42c948ce4") 
            }, CancellationToken.None);

            var allLessons = await _mockShortUrlRepository.Object.ListAllAsync();

            allLessons.Count.ShouldBe(1);
        }

        [Fact]
        public async void Validator_ShouldHaveError_WhenUserDontHaveAccess()
        {
            var validator = new DeleteShortUrlCommandValidator(_mockPermissionService.Object, _mockShortUrlRepository.Object);
            var query = new DeleteShortUrlCommand
            {
                Id = Guid.Parse("c1e9a0b2-5f3d-4427-8a3f-6db42c948ce4"),

                UserId = "userId2",
                UserRoles = new List<string>()
                {
                    "Default"
                }
            };

            var result = await validator.ValidateAsync(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("don't have access"));
        }
    }
}