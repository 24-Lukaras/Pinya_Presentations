namespace Pinya_Presentations.IdentityProvider.Infrastructure;

public static class Clients
{
    public readonly static IEnumerable<Client> Data = [
        new Client()
        {
            ClientId = Applications.Portal,
            ClientSecret = "secret0",
            RedirectUri = "https://localhost:7122/signin-oidc"
        },
        new Client()
        {
            ClientId = Applications.HR,
            ClientSecret = "secret1",
            RedirectUri = "https://localhost:7266/signin-oidc"
        },
        new Client()
        {
            ClientId = Applications.Backoffice,
            ClientSecret = "secret2",
            RedirectUri = "https://localhost:7189/signin-oidc"
        },
    ];
}
public class Client
{
    public string ClientId { get; init; } = null!;
    public string ClientSecret { get; init; } = null!;
    public string RedirectUri { get; init; } = null!;
}