namespace Pinya_Presentations.IdentityProvider.Infrastructure;

public static class Users
{
    public static readonly User[] Data = [
        new User() {
            Username = "admin",
            Password = "admin",
            Applications = [ Applications.HR, Applications.Backoffice ]
        },
        new User() {
            Username = "Pepa",
            Password = "12345",
            Applications = [Applications.HR, Applications.Backoffice ]
        },
        new User() {
            Username = "Bob",
            Password = "12345",
            Applications = [Applications.HR ]
        },
    ];
}

public class User
{
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string[] Applications { get; init; } = Array.Empty<string>();
}
