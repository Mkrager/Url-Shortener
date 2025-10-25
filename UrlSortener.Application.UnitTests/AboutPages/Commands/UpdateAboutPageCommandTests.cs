using Moq;
using Shouldly;
using UrlShortener.Application.Constants;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Features.AboutPages.Commands.UpdateAboutPage;
using UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl;
using UrlShortener.Domain.Entities;
using UrlSortener.Application.UnitTests.Base;
using UrlSortener.Application.UnitTests.Mocks;

namespace UrlSortener.Application.UnitTests.AboutPages.Commands
{
    public class UpdateAboutPageCommandTests : TestBase
    {
        private readonly Mock<IAsyncRepository<AboutPage>> _aboutPageRepository;

        public UpdateAboutPageCommandTests()
        {
            _aboutPageRepository = AboutPageRepositoryMock.GetAboutPageRepository();
        }
        [Fact]
        public async Task UpdateAboutPage_ValidCommand_UpdatesAboutPageSuccessfully()
        {
            var handler = new UpdateAboutPageCommandHandler(_aboutPageRepository.Object, _mapper);
            var updateCommand = new UpdateAboutPageCommand
            {
                Content = "newContent"
            };

            await handler.Handle(updateCommand, CancellationToken.None);

            var updatedAboutPage = await _aboutPageRepository.Object.GetByIdAsync(SystemGuids.AboutPageId);

            updatedAboutPage.ShouldNotBeNull();
            updatedAboutPage.Content.ShouldBe(updateCommand.Content);
        }

        [Fact]
        public async void Validator_ShouldHaveError_WhenEmptyContent()
        {
            var validator = new UpdateAboutPageCommandValidator();
            var query = new UpdateAboutPageCommand
            {
                Content = ""
            };

            var result = await validator.ValidateAsync(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, f => f.PropertyName == "Content");
        }

    }
}