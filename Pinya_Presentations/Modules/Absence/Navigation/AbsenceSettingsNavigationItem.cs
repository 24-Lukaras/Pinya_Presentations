using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.Absence.Navigation;

public class AbsenceSettingsNavigationItem : INavigationItem
{
    public string Title => "Správa typů";

    public string Url => "/Absence/Types";

    public string? Category => "Absence";

    public int Order => 1000;

    public bool Visible => true;
}
