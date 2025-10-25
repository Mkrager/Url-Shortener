using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.App.Contracts;
using UrlShortener.App.Models;

namespace UrlShortener.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShortUrlDataService _shortUrlDataService;

        public HomeController(IShortUrlDataService shortUrlDataService)
        {
            _shortUrlDataService = shortUrlDataService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _shortUrlDataService.GetAllShortUrls();
            return View();
        }
    }
}
