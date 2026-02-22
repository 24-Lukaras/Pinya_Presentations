using Microsoft.AspNetCore.Mvc;

namespace Pinya_Presentations.Controllers;

public class UsersController : Controller
{
    public IActionResult Create() => View();
}
