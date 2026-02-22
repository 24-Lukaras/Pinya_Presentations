using Microsoft.AspNetCore.Mvc;

namespace Pinya_Presentations.Controllers;

public class ItemsController : Controller
{
    public IActionResult Index() => View();
}
