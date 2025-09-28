using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Models;
using Pinya_Presentations.Services;
using System.Diagnostics;
using System.Security.Claims;

namespace Pinya_Presentations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChatRoomService _service;
        public HomeController(ILogger<HomeController> logger, ChatRoomService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Stocks()
        {
            return View();
        }

        [Authorize]
        public IActionResult Chat()
        {
            string? username = HttpContext.User?.Identity?.Name;

            if (username is null)
                return View(Array.Empty<ChatMessageViewModel>());

            var model = _service.GetAllMessagesOrdered().Select(x =>
                new ChatMessageViewModel(x.Message, x.Username, x.SentAtUtc, x.Username == username))
                .ToArray();

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var identity = new ClaimsIdentity([ new Claim(ClaimTypes.Name, model.Username) ], CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(claimsPrincipal);

            return Redirect("/Home/Chat");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
