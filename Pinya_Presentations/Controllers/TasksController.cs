using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Models;

namespace Pinya_Presentations.Controllers;

public class TasksController : Controller
{
    public IActionResult Edit()
    {
        var model = new TaskViewModel()
        {
            Title = "Deploy changes",
            Status = (int)TaskState.Planned,
            PercentComplete = 20
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Edit(TaskViewModel model)
    {
        return View(model);
    }
}
