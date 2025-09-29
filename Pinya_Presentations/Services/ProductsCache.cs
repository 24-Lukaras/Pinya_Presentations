using Microsoft.Extensions.Caching.Memory;
using Pinya_Presentations.Db.Entities;

namespace Pinya_Presentations.Services;

public class ProductsCache
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<ProductsCache> _logger;
    public ProductsCache(IMemoryCache cache, ILogger<ProductsCache> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    private const string KEY = "Products";
    private MemoryCacheEntryOptions GetOptions() => new MemoryCacheEntryOptions()
        .SetSlidingExpiration(TimeSpan.FromSeconds(10))
        .RegisterPostEvictionCallback((key, value, reason, state) =>
        {
            int count = (value as IEnumerable<Product>)?.Count() ?? 0;
            _logger.LogInformation("Products cache evicted with {count} items", count);
        });
    public IEnumerable<Product>? GetAll() =>
        _cache.Get<IEnumerable<Product>>(KEY);
    public void Set(IEnumerable<Product> products) =>
        _cache.Set(KEY, products, GetOptions());
}
