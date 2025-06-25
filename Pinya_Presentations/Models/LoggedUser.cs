
namespace Pinya_Presentations.Models;

public class LoggedUser
{
    public const string CLAIM_TYPE = "LoggedUser_Username";
    public string Name { get; init; }
    public LoggedUser(string name)
    {
        Name = name;
    }
}
