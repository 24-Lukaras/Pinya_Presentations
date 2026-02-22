using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class UserModel
{
    public string Username { get; init; } = string.Empty;
    public Toggle Active { get; init; } = new Toggle();
    public Checkbox IsAdmin { get; init; } = new Checkbox();

    [Display(Name = "Adresa")]
    public Address Address { get; init; } = new Address();

    [Display(Name = "Kontaktní adresa")]
    public Address ContactAddress { get; init; } = new Address();
}
