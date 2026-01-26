using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Modules.Orders;

namespace Pinya_Presentations.Controllers;

public class OrdersController : Controller
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var query = new GetActiveOrdersQuery();
        var orders = await _mediator.Send(query);
        return View(orders);
    }

    public async Task<IActionResult> Complete()
    {
        var query = new GetCompletedOrderQuery();
        var orders = await _mediator.Send(query);
        return View(orders.OrderByDescending(x => x.CompletedAtUtc));
    }

    [HttpPost]
    public async Task<IActionResult> Complete(Guid id)
    {
        var command = new CompleteOrderCommand(id);
        var result = await _mediator.Send(command);
        return result ? Ok() : BadRequest();
    }
}
