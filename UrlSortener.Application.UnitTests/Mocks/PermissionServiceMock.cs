using Moq;
using UrlShortener.Application.Contracts.Application;
using UrlShortener.Domain.Entities;

namespace UrlSortener.Application.UnitTests.Mocks
{
    public class PermissionServiceMock
    {
        public static Mock<IPermissionService> GetPermissionService()
        {
            var mockService = new Mock<IPermissionService>();

            mockService.Setup(s => s.UserHasPrivilegedRole(It.IsAny<List<string>>()))
                       .Returns(false);

            mockService.Setup(s => s.IsCreatedByUser(It.IsAny<ShortUrl>(), It.IsAny<string>()))
                       .Returns(false);

            return mockService;
        }
    }
}