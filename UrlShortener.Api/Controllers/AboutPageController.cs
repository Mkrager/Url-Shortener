using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.Services;
using UrlShortener.Application.Features.AboutPages.Commands.UpdateAboutPage;
using UrlShortener.Application.Features.AboutPages.Queries.GetAboutPage;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails;

namespace UrlShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AboutPageController(IMediator mediator) : Controller
    {
        [HttpGet("{id}", Name = "GetAboutPage")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShortUrlDetailVm>> GetAboutPage()
        {
            var getAboutPageQuery = new GetAboutPageQuery();
            return Ok(await mediator.Send(getAboutPageQuery));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateAboutPageCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

    }
}
