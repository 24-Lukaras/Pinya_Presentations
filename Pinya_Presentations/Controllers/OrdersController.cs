using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pinya_Presentations.Models;
using Pinya_Presentations.Orders.Application.Managers;

namespace Pinya_Presentations.Controllers;

public class OrdersController : Controller
{
    private readonly OrdersManager _manager;
    public OrdersController(OrdersManager manager)
    {
        _manager = manager;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _manager.GetOrdersAsync();
        var model = orders.Select(OrderGridModel.FromDto).ToArray();
        return View(model);
    }
    [HttpGet("/[controller]/Add")]
    public IActionResult Add() => View();

    [HttpPost("/[controller]")]
    public async Task<IActionResult> Add(
        AddOrderModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var result = await _manager.CreateOrderAsync(model.Customer);
        if (result is null)
        {
            ModelState.AddModelError<AddOrderModel>(x => x.Customer, "Hodnota není validní");
            return View(model);
        }
        return Redirect($"/Orders/{result.Id}");
    }

    [HttpGet("/[controller]/{id}")]
    public async Task<IActionResult> Detail(Guid id)
    {
        var dto = await _manager.GetOrderAsync(id);
        if (dto is null)
            return NotFound();
        return View(OrderDetailModel.FromDto(dto));
    }

}
