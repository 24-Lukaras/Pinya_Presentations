using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class EditProductViewModel
{
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string Category { get; init; } = null!;
    [UIHint("CategoryId")]
    public Guid CategoryId { get; init; }
}
