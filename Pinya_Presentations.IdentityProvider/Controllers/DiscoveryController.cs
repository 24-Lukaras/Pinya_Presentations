using Microsoft.AspNetCore.Mvc;

namespace Pinya_Presentations.IdentityProvider.Controllers;

[ApiController]
public class DiscoveryController : ControllerBase
{
    [HttpGet("/.well-known/openid-configuration")]
    public IActionResult Get()
    {
        var issuer = "https://localhost:7296";

        return Ok(new
        {
            issuer,
            authorization_endpoint = $"{issuer}/authorize",
            token_endpoint = $"{issuer}/token",
            jwks_uri = $"{issuer}/jwks",
            response_types_supported = new[] { "code" },
            subject_types_supported = new[] { "public" },
            id_token_signing_alg_values_supported = new[] { "RS256" }
        });
    }
}