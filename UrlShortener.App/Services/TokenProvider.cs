﻿using UrlShortener.App.Contracts;

namespace UrlShortener.App.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string Token => _httpContextAccessor.HttpContext.Request.Cookies["access_token"];
    }
}