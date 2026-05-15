using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.Employees.Navigation;

public class AddEmployeeNavigationItem : INavigationItem
{
    public string Title => "Přidat";
    public string Url => "/Employees/Add";
    public string? Category => "Zaměstnanci";
    public int Order => 0;
    public bool Visible => true;
}
