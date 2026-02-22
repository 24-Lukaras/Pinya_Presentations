using Bogus;

namespace Pinya_Presentations.Services.Items;

public class ItemsRepository
{
    private static IEnumerable<StorageItem> _items = Array.Empty<StorageItem>();

    public ItemsRepository()
    {
        if (!_items.Any())
        {
            var faker = new Faker<StorageItem>()
                .RuleFor(x => x.Title, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.Product()}")
                .RuleFor(x => x.Amount, f => f.Random.Int(1, 200))
                .UseSeed(100);
            var emptyFaker = new Faker<StorageItem>()
                .RuleFor(x => x.Title, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.Product()}")
                .UseSeed(5500);
            var orderGenerator = new Random(69);

            var result = faker.Generate(15);
            result.AddRange(emptyFaker.Generate(5));
            _items = result.OrderBy(x => orderGenerator.Next()).ToList();
        }
    }

    public Task<IEnumerable<StorageItem>> GetAllAsync() => Task.FromResult(_items);
    public Task<IEnumerable<StorageItem>> GetAvailableAsync() => Task.FromResult(_items.Where(x => x.Amount > 0));
    public Task<IEnumerable<StorageItem>> GetUnavailableAsync() => Task.FromResult(_items.Where(x => x.Amount <= 0));
}
public class StorageItem
{
    public required string Title { get; init; }
    public required int Amount { get; init; }
}
