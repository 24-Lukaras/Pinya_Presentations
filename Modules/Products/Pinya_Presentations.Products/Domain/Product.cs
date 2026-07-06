namespace Pinya_Presentations.Products.Domain;

internal class Product
{
    public Guid Id { get; private init; }
    public string Title { get; set; }
    public int Amount { get; private set; }
    public int ReservedAmount { get; private set; }
    public int AvailableAmount => Amount - ReservedAmount;
    public DateTime CreatedAtUtc { get; private init; }

    private Product() { }
    public Product(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        CreatedAtUtc = DateTime.UtcNow;
    }
    public int AddAmount(int amount)
    {
        if (amount <= 0)
            return Amount;
        Amount += amount;
        return Amount;
    }
    public bool TryReserveAmount(int amount)
    {
        if (amount <= 0)
            return false;
        if (AvailableAmount < amount)
            return false;
        ReservedAmount += amount;
        return true;
    }
    public bool TryReleaseReserved(int amount)
    {
        if (ReservedAmount < amount)
            return false;

        Amount -= amount;
        ReservedAmount -= amount;
        return true;
    }
}
