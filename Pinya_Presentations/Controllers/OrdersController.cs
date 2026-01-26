using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Modules.Orders;

namespace Pinya_Presentations.Controllers
{
    public class OrdersController : Controller
    {
        private readonly GetActiveOrders _getActiveOrders;
        private readonly GetCompletedOrders _getCompletedOrders;
        private readonly CompleteOrder _completeOrder;
        public OrdersController(GetActiveOrders getActiveOrders, GetCompletedOrders getCompletedOrders, CompleteOrder completeOrder)
        {
            _getActiveOrders = getActiveOrders;
            _getCompletedOrders = getCompletedOrders;
            _completeOrder = completeOrder;
        }

        public IActionResult Index()
        {
            var orders = _getActiveOrders.Get();
            return View(orders);
        }

        public IActionResult Complete()
        {
            var orders = _getCompletedOrders.Get().OrderByDescending(x => x.CompletedAtUtc);
            return View(orders);
        }

        [HttpPost]
        public IActionResult Complete(Guid id)
        {
            var command = new CompleteOrderCommand(id);
            var result = _completeOrder.Handle(command);
            return result ? Ok() : BadRequest();
        }
    }
}
