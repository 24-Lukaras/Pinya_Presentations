using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pinya_Presentations.IdentityProvider.Infrastructure;

public static class JwtHelper
{
    private const string Issuer = "https://localhost:7296";
    private const string Audience = "sso-demo";

    private static readonly byte[] Key =
        Encoding.UTF8.GetBytes("super_secret_signing_key_32_bytes_long!");

    public static string CreateToken(string username)
    {
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.UniqueName, username)
    };

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(Key),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static string CreateIdToken(string username, string clientId, string nonce)
    {
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Aud, clientId),
        new Claim(JwtRegisteredClaimNames.Iss, Issuer),
        new Claim(JwtRegisteredClaimNames.Iat,
            DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
            ClaimValueTypes.Integer64),
        new Claim(JwtRegisteredClaimNames.Nonce, nonce)
    };

        var creds = new SigningCredentials(
            RsaKeyProvider.GetKey(),
            SecurityAlgorithms.RsaSha256);

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: clientId,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static SymmetricSecurityKey GetSecurityKey()
    {
        return new SymmetricSecurityKey(Key)
        {
            KeyId = "demo-key"
        };
    }
}
