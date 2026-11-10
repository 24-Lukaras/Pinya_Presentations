namespace Pinya_Presentations.Services;

public interface ITenantAccessor
{
    public string? Title { get; }
    public Guid? TenantId { get; }
}
public class TenantAccessor : ITenantAccessor
{
    public string? Title => _title;
    private readonly string? _title;
    public Guid? TenantId => _tenantId;
    private readonly Guid? _tenantId;

    public const string TENANT_COOKIE_KEY = "tenant_cookie";
    public TenantAccessor(
        IHttpContextAccessor httpContext,
        TenantsService service)
    {
        string? tenantValue = httpContext.HttpContext?.Request.Cookies[TENANT_COOKIE_KEY];
        if (tenantValue is null)
            return;
        if (!Guid.TryParse(tenantValue, out Guid tenantId))
            return;
        var tenant = service.Tenants.FirstOrDefault(x => x.Id == tenantId);
        if (tenant is null)
            return;
        _title = tenant.Title;
        _tenantId = tenant.Id;
    }
}
