using AutoMapper;
using UrlShortener.Application.Profiles;

namespace UrlSortener.Application.UnitTests.Base
{
    public abstract class TestBase
    {
        protected readonly IMapper _mapper;

        protected TestBase()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
    }
}