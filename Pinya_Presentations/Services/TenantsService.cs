using Microsoft.Extensions.Options;
using Pinya_Presentations.Configuration;
using Pinya_Presentations.Models;

namespace Pinya_Presentations.Services;

public class TenantsService
{
    private readonly IReadOnlyDictionary<Guid, string> _connectionStringsMapping;
    public IReadOnlyCollection<Tenant> Tenants { get; }
    public TenantsService(IOptions<ShardsConfiguration> options)
    {
        var config = options.Value;
        Dictionary<Guid, string> mapping = new Dictionary<Guid, string>();
        foreach (var shard in config.Shards)
        {
            foreach (var tenant in shard.Tenants)
            {
                mapping[tenant.Id] = shard.ConnectionString;
            }
        }
        _connectionStringsMapping = mapping;
        Tenants = config.Shards
            .SelectMany(x => x.Tenants)
            .Select(x => new Tenant() { Id = x.Id, Title = x.Title })
            .ToArray();
    }

    public string? GetConnectionString(Guid tenantId) =>
        _connectionStringsMapping.GetValueOrDefault(tenantId);

    public IEnumerable<string> GetAllConnectionStrings() =>
        _connectionStringsMapping.Values.Distinct();
}
