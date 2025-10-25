using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.App.Contracts;
using UrlShortener.App.Helpers;
using UrlShortener.App.ViewModels;

namespace UrlShortener.App.Controllers
{
    public class AboutPageController : Controller
    {
        private readonly IAboutPageDataService _aboutPageDataService;

        public AboutPageController(IAboutPageDataService aboutPageDataService)
        {
            _aboutPageDataService = aboutPageDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _aboutPageDataService.GetAboutPage();
            return View(result.Data);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(AboutPageViewModel aboutPageViewModel)
        {
            var result = await _aboutPageDataService.UpdateAboutPage(aboutPageViewModel);

            if (!result.IsSuccess)
            {
                return BadRequest(new { error = result.ErrorText });
            }

            return Ok(new { success = true, redirectToUrl = Url.Action("Index", "AboutPage") });
        }

    }
}
