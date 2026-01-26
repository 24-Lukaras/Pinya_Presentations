using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Modules.Sales;

namespace Pinya_Presentations.Controllers
{
    public class SalesController : Controller
    {

        public IActionResult Index([FromServices] GetSalesAmount handler)
        {
            var result = handler.Handle(new GetSalesAmountQuery());
            return View(result.Result);
        }
    }
}
