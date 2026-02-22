using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Models;

namespace Pinya_Presentations.Controllers;

public class UsersController : Controller
{
    private static readonly UserEntry _admin = new UserEntry()
    {
        Username = "admin",
        IsAdmin = true
    };
    public IActionResult Update()
    {
        return View(ToModel(_admin));
    }

    [HttpPost]
    public IActionResult Update(UserModel model)
    {
        _admin.Username = model.Username;
        _admin.IsAdmin = model.IsAdmin;
        _admin.Active = model.Active;
        return RedirectToAction(nameof(Update));
    }

    private static UserModel ToModel(UserEntry entry) => new UserModel()
    {
        Username = _admin.Username,
        Active = _admin.Active,
        IsAdmin = _admin.IsAdmin,
    };
}

public class UserEntry
{
    public string Username { get; set; }
    public bool IsAdmin { get; set; }
    public bool Active { get; set; }
}
