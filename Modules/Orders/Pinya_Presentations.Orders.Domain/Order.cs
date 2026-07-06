namespace Pinya_Presentations.Orders.Domain;

public class Order
{
    public Guid Id { get; private init; }
    public OrderStatus Status { get; private set; }
    public string Customer { get; private init; }
    public DateTime CreatedAtUtc { get; private init; }
    public IEnumerable<OrderItem> Items => _items;
    private List<OrderItem> _items = new List<OrderItem>();

    private Order() { }
    public Order(string customer)
    {
        Id = Guid.NewGuid();
        Status = OrderStatus.Created;
        Customer = customer;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public OrderItem? AddItem(Guid productId, string productName, int amount)
    {
        if (amount <= 0)
            return null;

        var item = _items.FirstOrDefault(x => x.ProductId == productId);
        if (item is null)
        {
            item = new OrderItem(productId, productName);
            _items.Add(item);
        }
        item.Amount += amount;
        return item;
    }
    public bool RemoveItem(Guid productId, int amount)
    {
        if (amount <= 0)
            return false;

        var item = _items.FirstOrDefault(x => x.ProductId == productId);
        if (item is null)
            return false;

        item.Amount -= amount;
        if (item.Amount <= 0)
            _items.Remove(item);

        return true;
    }
}
