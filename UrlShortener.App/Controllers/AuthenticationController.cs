using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.App.Contracts;
using UrlShortener.App.Helpers;
using UrlShortener.App.ViewModels;

namespace UrlShortener.App.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult UnAuthorizedHandler()
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["LoginErrorMessage"] = "You need to login to continue.";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AccessDeniedHandler()
        {
            TempData["ErrorMessage"] = "You don't have access";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateRequest request)
        {
            var result = await _authenticationService.Authenticate(request);
            TempData["LoginErrorMessage"] = HandleErrors.HandleResponse(result, "Success");

            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            var result = await _authenticationService.Register(request);
            TempData["LoginErrorMessage"] = HandleErrors.HandleResponse(result, "Success");

            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}