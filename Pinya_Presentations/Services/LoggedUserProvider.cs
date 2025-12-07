using EventSourcingData.Services;

namespace Pinya_Presentations.Services;

public class LoggedUserProvider : ILoggedUserProvider
{
    private readonly IHttpContextAccessor _httpContext;
    public LoggedUserProvider(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }
    public string? Username => _httpContext.HttpContext?.User?.Identity?.Name;
}
