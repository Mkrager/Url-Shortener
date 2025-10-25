using UrlShortener.App.Infrastructure.Api;
using UrlShortener.App.ViewModels;

namespace UrlShortener.App.Contracts
{
    public interface IShortUrlDataService
    {
        Task<ApiResponse<Guid>> CreateShortUrl(ShortUrlViewModel shortUrlViewModel);
        Task<ApiResponse> DeleteShortUrl(Guid id);
        Task<ApiResponse<ShortUrlViewModel>> GetShortUrlById(Guid id);
        Task<ApiResponse<string>> GetShortUrlByCode(string code);
        Task<ApiResponse<List<ShortUrlViewModel>>> GetAllShortUrls();
    }
}
