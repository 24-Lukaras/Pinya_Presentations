using Pinya_Presentations.Services.Auth;
using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.Absence.Navigation;

public class AllAbsenceNavigationItem : INavigationItem
{
    private readonly UserContext _ctx;
    public AllAbsenceNavigationItem(UserContext ctx)
    {
        _ctx = ctx;
    }

    public string Title => "Seznam";

    public string Url => "/Absence";

    public string? Category => "Absence";

    public int Order => 500;

    public bool Visible => _ctx.IsAdmin;
}
