using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Modules.Orders;

namespace Pinya_Presentations.Controllers;

public class OrdersController : Controller
{
    public IActionResult Index([FromServices] GetActiveOrders handler)
    {
        var orders = handler.Handle(new GetActiveOrdersQuery());
        return View(orders.Result);
    }

    public IActionResult Complete([FromServices] GetCompletedOrders handler)
    {
        var orders = handler.Handle(new GetCompletedRecordQuery());
        return View(orders.Result!.OrderByDescending(x => x.CompletedAtUtc));
    }

    [HttpPost]
    public IActionResult Complete(Guid id, [FromServices] CompleteOrder handler)
    {
        var command = new CompleteOrderCommand(id);
        var result = handler.Handle(command);
        if (result.Error is not null)
            return BadRequest();
        return Ok();
    }
}
