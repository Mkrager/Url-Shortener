using MediatR;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Application.Contracts;

namespace UrlShortener.Application.Behaviours
{
    public class UserContextBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IUserRequest
    {
        private readonly ICurrentUserService _currentUserService;

        public UserContextBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            request.UserId = _currentUserService.UserId;

            if (request is IUserRequest withRoles)
            {
                withRoles.UserRoles = _currentUserService.UserRoles;
            }

            return await next();
        }
    }
}