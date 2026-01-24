namespace Pinya_Presentations.IdentityProvider.Infrastructure;

public static class AuthCodes
{
    private record AuthCode(string Username, string ClientId, string Nonce, DateTime ExpiresAt);

    private static readonly Dictionary<string, AuthCode> _codes = new();

    public static void Store(string code, string username, string clientId, string nonce)
    {
        _codes[code] = new AuthCode(
            username,
            clientId,
            nonce,
            DateTime.UtcNow.AddMinutes(1)
        );
    }

    public static (string Username, string ClientId, string Nonce)? Consume(string code)
    {
        if (!_codes.TryGetValue(code, out var auth))
            return null;

        _codes.Remove(code);

        if (auth.ExpiresAt < DateTime.UtcNow)
            return null;

        return (auth.Username, auth.ClientId, auth.Nonce);
    }
}
