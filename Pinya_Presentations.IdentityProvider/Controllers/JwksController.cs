using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pinya_Presentations.IdentityProvider.Infrastructure;

namespace Pinya_Presentations.IdentityProvider.Controllers;

[ApiController]
public class JwksController : ControllerBase
{
    [HttpGet("/jwks")]
    public IActionResult Get()
    {
        var key = RsaKeyProvider.GetKey();
        var parameters = key.Rsa.ExportParameters(false);

        return Ok(new
        {
            keys = new[]
            {
                new
                {
                    kty = "RSA",
                    alg = "RS256",
                    use = "sig",
                    kid = "demo-rsa-key",
                    n = Base64UrlEncoder.Encode(parameters.Modulus),
                    e = Base64UrlEncoder.Encode(parameters.Exponent)
                }
            }
        });
    }
}
