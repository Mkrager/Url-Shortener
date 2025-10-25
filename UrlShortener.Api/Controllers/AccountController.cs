using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.DTOs.Authentication;
using UrlShortener.Application.Features.Account.Commands.Registration;
using UrlShortener.Application.Features.Account.Queries.Authentication;

namespace UrlShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator mediator) : Controller
    {
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync([FromBody] AuthenticationQuery request)
        {
            var dtos = await mediator.Send(request);

            return Ok(dtos);
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterAsync([FromBody] RegistrationCommand request)
        {
            var dtos = await mediator.Send(request);

            return Ok(dtos);
        }
    }
}