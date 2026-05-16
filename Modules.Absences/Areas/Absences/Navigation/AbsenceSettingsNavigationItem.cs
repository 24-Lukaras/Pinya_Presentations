using Pinya_Presentations.Services.Navigation;
using Pinya_Presentations.Shared.Services.Auth;

namespace Pinya_Presentations.Modules.Absence.Navigation;

public class AbsenceSettingsNavigationItem : INavigationItem
{
    private readonly IUserContext _ctx;
    public AbsenceSettingsNavigationItem(IUserContext ctx)
    {
        _ctx = ctx;
    }

    public string Title => "Správa typů";

    public string Url => "/Absences/Types";

    public string? Category => "Absence";

    public int Order => 1000;

    public bool Visible => _ctx.IsAdmin;
}
