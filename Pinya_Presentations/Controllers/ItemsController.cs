using Microsoft.AspNetCore.Mvc;

namespace Pinya_Presentations.Controllers;

public class ItemsController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Create() => View();
    public IActionResult OrdersList() => View();
}
