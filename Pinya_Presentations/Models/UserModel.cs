namespace Pinya_Presentations.Models;

public class UserModel
{
    public string Username { get; init; } = string.Empty;
    public Toggle Active { get; init; } = new Toggle();
    public Checkbox IsAdmin { get; init; } = new Checkbox();
}
