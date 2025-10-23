namespace UrlShortener.Application.Contracts.Infrastructure
{
    public interface ICodeService
    {
        string GenerateShortCode(int length = 6);
    }
}