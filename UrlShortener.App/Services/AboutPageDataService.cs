using System.Text.Json;
using System.Text;
using UrlShortener.App.Contracts;
using UrlShortener.App.Infrastructure.Api;
using UrlShortener.App.Infrastructure.BaseServices;
using UrlShortener.App.ViewModels;

namespace UrlShortener.App.Services
{
    public class AboutPageDataService : BaseDataService, IAboutPageDataService
    {
        public AboutPageDataService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<ApiResponse<AboutPageViewModel>> GetAboutPage()
        {
            var response = await _httpClient.GetAsync($"aboutPage");
            return await HandleResponse<AboutPageViewModel>(response);
        }

        public async Task<ApiResponse> UpdateAboutPage(AboutPageViewModel aboutPageViewModel)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(aboutPageViewModel),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PutAsync("aboutPage", content);
            return await HandleResponse(response);
        }
    }
}
