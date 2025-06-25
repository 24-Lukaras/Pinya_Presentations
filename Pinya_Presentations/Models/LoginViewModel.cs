using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class LoginViewModel
{
    [Required]
    public string Username { get; init; } = null!;
}
