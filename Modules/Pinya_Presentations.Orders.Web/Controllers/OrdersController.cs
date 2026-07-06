using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pinya_Presentations.Orders.Application.Managers;
using Pinya_Presentations.Orders.Web.Model;

namespace Pinya_Presentations.Orders.Web.Controllers;

[Area("Orders")]
public class OrdersController : Controller
{
    private readonly OrdersManager _manager;
    public OrdersController(OrdersManager manager)
    {
        _manager = manager;
    }

    [HttpGet("/[area]")]
    public async Task<IActionResult> Index()
    {
        var orders = await _manager.GetOrdersAsync();
        var model = orders.Select(OrderGridModel.FromDto).ToArray();
        return View(model);
    }
    [HttpGet("/[area]/Add")]
    public IActionResult Add() => View();

    [HttpPost("/[area]")]
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

    [HttpGet("/[area]/{id}")]
    public async Task<IActionResult> Detail(Guid id)
    {
        var dto = await _manager.GetOrderAsync(id);
        if (dto is null)
            return NotFound();
        return View(OrderDetailModel.FromDto(dto));
    }

    [HttpGet("/[area]/Search")]
    public async Task<IActionResult> SearchItems(string query)
    {
        var items = await _manager.SearchProducts(query);
        return Json(items);
    }

    [HttpPost("/[area]/{id}/Item")]
    public async Task<IActionResult> AddItem(
        AddOrderItemModel model)
    {
        var result = await _manager.AddItemAsync(model.Id, model.ProductId, model.Amount);
        return Redirect($"/Orders/{model.Id}");
    }

}
