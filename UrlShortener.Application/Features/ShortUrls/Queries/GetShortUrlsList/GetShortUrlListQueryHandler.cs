using AutoMapper;
using MediatR;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlsList
{
    public class GetShortUrlListQueryHandler : IRequestHandler<GetShortUrlListQuery, List<ShortUrlListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ShortUrl> _shortUlrRepository;
        public GetShortUrlListQueryHandler(IMapper mapper, IAsyncRepository<ShortUrl> shortUlrRepository)
        {
            _mapper = mapper;
            _shortUlrRepository = shortUlrRepository;
        }
        public async Task<List<ShortUrlListVm>> Handle(GetShortUrlListQuery request, CancellationToken cancellationToken)
        {
            var shortUrlsList = await _shortUlrRepository.ListAllAsync();
            return _mapper.Map<List<ShortUrlListVm>>(shortUrlsList);
        }
    }
}