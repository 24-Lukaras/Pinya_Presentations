namespace Pinya_Presentations.Orders.Domain;

public class OrderItem
{
    public Guid Id { get; private init; }
    public Guid ProductId { get; private init; }
    public string ProductName { get; private init; }
    public int Amount { get; set; }

    private OrderItem() { }
    public OrderItem(Guid productId, string productName)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        ProductName = productName;
    }
}
