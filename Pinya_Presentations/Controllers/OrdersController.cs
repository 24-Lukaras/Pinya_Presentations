using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Modules.Orders;

namespace Pinya_Presentations.Controllers;

public class OrdersController : Controller
{
    public IActionResult Index([FromServices] GetActiveOrders handler)
    {
        var orders = handler.Get();
        return View(orders);
    }

    public IActionResult Complete([FromServices] GetCompletedOrders handler)
    {
        var orders = handler.Get();
        return View(orders.OrderByDescending(x => x.CompletedAtUtc));
    }

    [HttpPost]
    public IActionResult Complete(Guid id, [FromServices] CompleteOrder handler)
    {
        var command = new CompleteOrderCommand(id);
        var result = handler.Handle(command);
        return result ? Ok() : BadRequest();
    }
}
