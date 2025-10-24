using AutoMapper;
using UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlsList;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShortUrl, CreateShortUrlCommand>().ReverseMap();
            CreateMap<ShortUrl, ShortUrlListVm>().ReverseMap();
            CreateMap<ShortUrl, ShortUrlDetailVm>().ReverseMap();
        }
    }
}