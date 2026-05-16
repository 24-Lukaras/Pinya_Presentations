using Pinya_Presentations.Services.Navigation;
using Pinya_Presentations.Shared.Services.Auth;

namespace Pinya_Presentations.Modules.Absence.Navigation;

public class AllAbsenceNavigationItem : INavigationItem
{
    private readonly IUserContext _ctx;
    public AllAbsenceNavigationItem(IUserContext ctx)
    {
        _ctx = ctx;
    }

    public string Title => "Seznam";

    public string Url => "/Absences/All";

    public string? Category => "Absence";

    public int Order => 500;

    public bool Visible => _ctx.IsAdmin;
}
