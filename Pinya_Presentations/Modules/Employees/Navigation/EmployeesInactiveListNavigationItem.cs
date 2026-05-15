using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.Employees.Navigation;

public class EmployeesInactiveListNavigationItem : INavigationItem
{
    public string Title => "Neaktivní";
    public string Url => "/Employees/Inactive";
    public string? Category => "Zaměstnanci";
    public int Order => 500;
    public bool Visible => true;
}
