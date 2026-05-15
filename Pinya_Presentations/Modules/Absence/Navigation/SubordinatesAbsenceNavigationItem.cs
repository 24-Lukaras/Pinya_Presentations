using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.Absence.Navigation;

public class SubordinatesAbsenceNavigationItem : INavigationItem
{
    public string Title => "Podřízení";
    public string Url => "/Absence/Subordinates";
    public string? Category => "Absence";
    public int Order => 0;
    public bool Visible => true;
}
