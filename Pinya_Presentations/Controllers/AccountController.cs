using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Models;
using System.Security.Claims;

namespace Pinya_Presentations.Controllers;

public sealed class AccountController : Controller
{

    public ActionResult Login() => View();
    [HttpPost]
    public async Task<ActionResult> Login(LoginModel model)
    {
        if (User.Identity?.IsAuthenticated ?? false)
            return Redirect("/");

        var identity = new ClaimsIdentity([new Claim(ClaimTypes.Name, model.Username)], CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(claimsPrincipal);
        return Redirect("/");
    }
}
