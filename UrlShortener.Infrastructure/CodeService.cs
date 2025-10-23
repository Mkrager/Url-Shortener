using UrlShortener.Application.Contracts.Infrastructure;

namespace UrlShortener.Infrastructure
{
    public class CodeService : ICodeService
    {
        private static readonly char[] Alphabet =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        public string GenerateShortCode(int length = 6)
        {
            var rnd = new Random();
            return new string(
                Enumerable.Repeat(Alphabet, length)
                .Select(chars => chars[rnd.Next(chars.Length)])
                .ToArray());
        }
    }
}