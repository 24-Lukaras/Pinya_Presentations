using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class AddProductModel
{
    [Required]
    [Display(Name = "Název")]
    [DataType(DataType.Text)]
    public string Title { get; init; }
}
