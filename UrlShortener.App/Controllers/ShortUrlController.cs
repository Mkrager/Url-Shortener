using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.App.Contracts;
using UrlShortener.App.ViewModels;

namespace UrlShortener.App.Controllers
{
    [Route("shortUrl")]
    public class ShortUrlController : Controller
    {
        private readonly IShortUrlDataService _shortUrlDataService;
        public ShortUrlController(IShortUrlDataService shortUrlDataService)
        {
            _shortUrlDataService = shortUrlDataService; 
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ShortUrlViewModel shortUrlViewModel)
        {
            var result = await _shortUrlDataService.CreateShortUrl(shortUrlViewModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _shortUrlDataService.GetAllShortUrls();
            return Json(result.Data);
        }

        [HttpGet("s/{code}")]
        public async Task<IActionResult> S(string code)
        {
            var result = await _shortUrlDataService.GetShortUrlByCode(code);

            if (result.Data == null)
                return NotFound("Short URL not found");

            return Redirect(result.Data);
        }
    }
}
