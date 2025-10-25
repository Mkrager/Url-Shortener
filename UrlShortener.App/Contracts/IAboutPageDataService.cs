using UrlShortener.App.Infrastructure.Api;
using UrlShortener.App.ViewModels;

namespace UrlShortener.App.Contracts
{
    public interface IAboutPageDataService
    {
        Task<ApiResponse<AboutPageViewModel>> GetAboutPage();
        Task<ApiResponse> UpdateAboutPage(AboutPageViewModel aboutPageViewModel);
    }
}
