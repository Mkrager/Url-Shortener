﻿using AutoMapper;
using MediatR;
using UrlShortener.Application.Contracts.Identity;
using UrlShortener.Application.DTOs.Authentication;

namespace UrlShortener.Application.Features.Account.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, string>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        public RegistrationCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var register = await _authenticationService
                .RegisterAsync(_mapper.Map<RegistrationRequest>(request));

            return register;
        }
    }
}