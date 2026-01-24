using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.IdentityProvider.Infrastructure;
using Pinya_Presentations.IdentityProvider.Models;
using System.Security.Claims;

namespace Pinya_Presentations.IdentityProvider.Controllers
{
    public class AuthController : Controller
    {
        

        [HttpGet("/authorize")]
        public IActionResult Authorize(
            string client_id,
            string redirect_uri,
            string state,
            string nonce)
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect($"/login?client_id={client_id}&redirect_uri={redirect_uri}&state={state}&nonce={nonce}");
            }

            var code = Guid.NewGuid().ToString("N");
            AuthCodes.Store(code, User.Identity.Name!, client_id, nonce);

            return Redirect($"{redirect_uri}?code={code}&state={state}&nonce={nonce}");
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginViewModel model,
            string client_id,
            string redirect_uri,
            string state,
            string nonce)
        {
            var user = Users.Data.FirstOrDefault(x => x.Username == model.Username);
            if (user is null || user.Password != model.Password)
                return Unauthorized();

            var claims = new[] { new Claim(ClaimTypes.Name, model.Username) };
            var identity = new ClaimsIdentity(claims, "IdpCookie");

            await HttpContext.SignInAsync("IdpCookie", new ClaimsPrincipal(identity));

            return Redirect($"/authorize?client_id={client_id}&redirect_uri={redirect_uri}&state={state}&nonce={nonce}");
        }

        [HttpPost("/token")]
        public IActionResult Token(
            string code,
            string client_id,
            string client_secret,
            string nonce)
        {
            var client = Clients.Data.Single(c => c.ClientId == client_id);
            if (client.ClientSecret != client_secret)
                return Unauthorized();

            var auth = AuthCodes.Consume(code);
            if (auth == null || auth.Value.ClientId != client_id)
                return Unauthorized();

            var token = JwtHelper.CreateToken(auth.Value.Username);
            var idToken = JwtHelper.CreateIdToken(auth.Value.Username, client_id, auth.Value.Nonce);

            return Ok(new
            {
                access_token = token,
                id_token = idToken,
                token_type = "Bearer",
                expires_in = 300
            });
        }
    }
}
