using AutoMapper;
using MediatR;
using UrlShortener.Application.Contracts.Identity;
using UrlShortener.Application.DTOs.Authentication;

namespace UrlShortener.Application.Features.Account.Queries.Authentication
{
    public class AuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, AuthenticationVm>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthenticationQueryHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<AuthenticationVm> Handle(AuthenticationQuery request, CancellationToken cancellationToken)
        {
            var authentication = await _authenticationService
                .AuthenticateAsync(_mapper.Map<AuthenticationRequest>(request));

            return _mapper.Map<AuthenticationVm>(authentication);
        }
    }
}
