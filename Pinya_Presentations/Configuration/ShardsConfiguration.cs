namespace Pinya_Presentations.Configuration;

public class ShardsConfiguration
{
    public IReadOnlyCollection<ShardDefinition> Shards { get; init; }
}
public class ShardDefinition
{
    public string Id { get; init; }
    public string ConnectionString { get; init; }
    public IReadOnlyCollection<TenantDefinition> Tenants { get; init; }
}
public class TenantDefinition
{
    public Guid Id { get; init; }
    public string Title { get; init; }
}
