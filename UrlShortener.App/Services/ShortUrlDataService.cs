using System.Text.Json;
using System.Text;
using UrlShortener.App.Contracts;
using UrlShortener.App.Infrastructure.Api;
using UrlShortener.App.Infrastructure.BaseServices;
using UrlShortener.App.ViewModels;

namespace UrlShortener.App.Services
{
    public class ShortUrlDataService : BaseDataService, IShortUrlDataService
    {
        public ShortUrlDataService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<ApiResponse<Guid>> CreateShortUrl(ShortUrlViewModel shortUrlViewModel)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(shortUrlViewModel),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("shortUrl", content);
            return await HandleResponse<Guid>(response);
        }

        public async Task<ApiResponse> DeleteShortUrl(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"shortUrl/{id}");
            return await HandleResponse(response);
        }

        public async Task<ApiResponse<List<ShortUrlViewModel>>> GetAllShortUrls()
        {
            var response = await _httpClient.GetAsync("shortUrl");
            return await HandleResponse<List<ShortUrlViewModel>>(response);
        }

        public async Task<ApiResponse<ShortUrlViewModel>> GetShortUrlById(Guid id)
        {
            var response = await _httpClient.GetAsync($"shortUrl/{id}");
            return await HandleResponse<ShortUrlViewModel>(response);
        }
    }
}