using UrlShortener.App.Infrastructure.Api;

namespace UrlShortener.App.Helpers
{
    public static class HandleErrors
    {
        public static string HandleResponse<T>(ApiResponse<T> response, string successMessage = "")
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return successMessage;
            }
            else
            {
                return response.ErrorText;
            }
        }

        public static string HandleResponse(ApiResponse response, string successMessage = "")
        {
            if (response.IsSuccess)
            {
                return successMessage;
            }
            else
            {
                return response.ErrorText;
            }
        }
    }
}