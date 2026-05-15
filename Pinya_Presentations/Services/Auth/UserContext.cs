namespace Pinya_Presentations.Services.Auth;

public class UserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool IsAdmin => _httpContextAccessor.HttpContext?.Request?.Query.ContainsKey("admin") ?? false;
}
