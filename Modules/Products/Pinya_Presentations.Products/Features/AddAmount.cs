using Pinya_Presentations.Products.Database;

namespace Pinya_Presentations.Products.Features;

public interface IAddAmountHandler
{
    public Task<bool> AddAmountAsync(Guid id, int amount);
}
internal sealed class AddAmount : IAddAmountHandler
{
    private readonly ProductsDb _db;
    public AddAmount(ProductsDb db)
    {
        _db = db;
    }
    public async Task<bool> AddAmountAsync(Guid id, int amount)
    {
        if (amount <= 0)
            return false;
        var item = await _db.Products.FindAsync(id);
        if (item is null)
            return false;
        item.AddAmount(amount);
        await _db.SaveChangesAsync();
        return true;
    }
}
