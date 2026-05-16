using Pinya_Presentations.Services.Navigation;
using Pinya_Presentations.Shared.Services.Auth;

namespace Pinya_Presentations.Modules.Employees.Navigation;

public class AddEmployeeNavigationItem : INavigationItem
{
    private readonly IUserContext _ctx;
    public AddEmployeeNavigationItem(IUserContext ctx)
    {
        _ctx = ctx;
    }
    public string Title => "Přidat";
    public string Url => "/Employees/Add";
    public string? Category => "Zaměstnanci";
    public int Order => 0;
    public bool Visible => _ctx.IsAdmin;
}
