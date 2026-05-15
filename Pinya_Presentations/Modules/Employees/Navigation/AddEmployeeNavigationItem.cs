using Pinya_Presentations.Services.Auth;
using Pinya_Presentations.Services.Navigation;

namespace Pinya_Presentations.Modules.Employees.Navigation;

public class AddEmployeeNavigationItem : INavigationItem
{
    private readonly UserContext _ctx;
    public AddEmployeeNavigationItem(UserContext ctx)
    {
        _ctx = ctx;
    }
    public string Title => "Přidat";
    public string Url => "/Employees/Add";
    public string? Category => "Zaměstnanci";
    public int Order => 0;
    public bool Visible => _ctx.IsAdmin;
}
