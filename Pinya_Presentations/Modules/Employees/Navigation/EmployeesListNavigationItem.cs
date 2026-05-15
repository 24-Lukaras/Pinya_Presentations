using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.Employees.Navigation;

public class EmployeesListNavigationItem : INavigationItem
{
    public string Title => "Seznam";
    public string Url => "/Employees";
    public string? Category => "Zaměstnanci";
    public int Order => 100;
    public bool Visible => true;
}
