namespace Pinya_Presentations.Db.Entities;

public class Product
{
    public Guid Id { get; init; }
    public string Title { get; set; } = null!;
    public Guid CategoryId { get; set; }
}
