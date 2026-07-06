using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class AddOrderModel
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Zákazník")]
    public string Customer { get; init; }
}
