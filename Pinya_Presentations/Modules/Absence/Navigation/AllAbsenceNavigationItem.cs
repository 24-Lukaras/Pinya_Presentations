using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.Absence.Navigation;

public class AllAbsenceNavigationItem : INavigationItem
{
    public string Title => "Seznam";

    public string Url => "/Absence";

    public string? Category => "Absence";

    public int Order => 500;

    public bool Visible => true;
}
