namespace UrlShortener.Application.Common.Interfaces
{
    public interface IUserRequest
    {
        string? UserId { get; set; }
        List<string> UserRoles { get; set; }
    }
}
