using Pinya_Presentations.Models;

namespace Pinya_Presentations.Services;

public class LoggedUserProvider
{
    private readonly HttpContext? _ctx;
    public LoggedUserProvider(IHttpContextAccessor contextAccessor)
    {
        _ctx = contextAccessor.HttpContext;
    }
    
    private LoggedUser? _cached;
    public LoggedUser? GetUser()
    {
        if (_cached is not null)
            return _cached;

        var claim = _ctx?.User?.Claims.FirstOrDefault(x => x.Type == LoggedUser.CLAIM_TYPE);
        if (claim is null)
            return null;

        _cached = new LoggedUser(claim.Value);
        return _cached;
    }
}

