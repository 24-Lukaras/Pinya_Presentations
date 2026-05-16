using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Absences.Areas.Absences;

[Area("Absences")]
[Route("[area]")]
public class AbsencesController : Controller
{
    [HttpGet("Types")]
    public IActionResult Types() => View();

    [HttpGet("All")]
    public IActionResult All() => View();

    [HttpGet("Subordinates")]
    public IActionResult Subordinates() => View();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var marker = context.HttpContext.RequestServices.GetService<ModuleFeatureMarker>();

        if (marker is null)
            context.Result = NotFound();

        base.OnActionExecuting(context);
    }
}
