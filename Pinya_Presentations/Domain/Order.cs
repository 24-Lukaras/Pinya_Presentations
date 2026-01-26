namespace Pinya_Presentations.Domain;

public class Order
{
    public Guid Id { get; init; }
    public string Company { get; init; }
    public OrderStatus Status { get; set; }
    public DateTime? CompletedAtUtc { get; set; }

    public IEnumerable<OrderItem> Items { get; init; }
}

public enum OrderStatus
{
    Active,
    Completed
}
