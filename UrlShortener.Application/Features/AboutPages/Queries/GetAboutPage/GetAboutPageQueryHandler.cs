using AutoMapper;
using MediatR;
using UrlShortener.Application.Constants;
using UrlShortener.Application.Contracts.Persistance;

namespace UrlShortener.Application.Features.AboutPages.Queries.GetAboutPage
{
    public class GetAboutPageQueryHandler : IRequestHandler<GetAboutPageQuery, AboutPageVm>
    {
        private readonly IAsyncRepository<AboutPageVm> _aboutPageRepository;
        private readonly IMapper _mapper;
        public GetAboutPageQueryHandler(IAsyncRepository<AboutPageVm> aboutPageRepository, IMapper mapper)
        {
            _aboutPageRepository = aboutPageRepository;
            _mapper = mapper;
        }
        public async Task<AboutPageVm> Handle(GetAboutPageQuery request, CancellationToken cancellationToken)
        {
            var aboutPage = await _aboutPageRepository.GetByIdAsync(SystemGuids.AboutPageId);
            return _mapper.Map<AboutPageVm>(aboutPage);
        }
    }
}
