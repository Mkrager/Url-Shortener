using Moq;
using UrlShortener.Application.Contracts.Infrastructure;

namespace UrlSortener.Application.UnitTests.Mocks
{
    public class CodeServiceMock
    {
        public static Mock<ICodeService> GetCodeService()
        {
            var mockService = new Mock<ICodeService>();

            mockService.Setup(s => s.GenerateShortCode(It.IsAny<int>()))
                .Returns("34dfa2");

            return mockService;
        }
    }
}