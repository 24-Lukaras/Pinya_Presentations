using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Pinya_Presentations.IdentityProvider.Infrastructure;

public static class RsaKeyProvider
{
    private static readonly RSA Rsa = RSA.Create(2048);

    public static RsaSecurityKey GetKey()
    {
        return new RsaSecurityKey(Rsa)
        {
            KeyId = "demo-rsa-key"
        };
    }
}
