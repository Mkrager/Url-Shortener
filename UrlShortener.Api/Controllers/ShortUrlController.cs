using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl;
using UrlShortener.Application.Features.ShortUrls.Commands.DeleteShortUrl;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlByCode;
using UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlsList;

namespace UrlShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController(IMediator mediator) : Controller
    {
        [Authorize]
        [HttpPost(Name = "AddShortUrl")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateShortUrlCommand createShortUrlCommand)
        {
            var id = await mediator.Send(createShortUrlCommand);
            return Ok(id);
        }

        [Authorize]
        [HttpDelete("{id}", Name = "DeleteShortUrl")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteShortUrlCommand = new DeleteShortUrlCommand()
            {
                Id = id,
            };
            await mediator.Send(deleteShortUrlCommand);
            return NoContent();
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetShortUrlById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShortUrlDetailVm>> GetShortUrlById(Guid id)
        {
            var getShortUrlDetailQuery = new GetShortUrlDetailQuery() { Id = id };
            return Ok(await mediator.Send(getShortUrlDetailQuery));
        }

        [HttpGet("by-code/{code}", Name = "GetShortUrlByCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShortUrlDetailVm>> GetShortUrlByCode(string code)
        {
            var getShortUrlByCodeQuery = new GetShortUrlByCodeQuery() { Code = code };
            return Ok(await mediator.Send(getShortUrlByCodeQuery));
        }

        [HttpGet(Name = "GetAllShortUrls")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ShortUrlListVm>>> GetAllShortUrls()
        {
            var dtos = await mediator.Send(new GetShortUrlListQuery());
            return Ok(dtos);
        }
    }
}