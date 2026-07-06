using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pinya_Presentations.Models;
using Pinya_Presentations.Products.Features;

namespace Pinya_Presentations.Controllers;

public class ProductsController : Controller
{
    public async Task<IActionResult> Index(
        [FromServices] IGetBriefProductsHandler handler)
    {
        var dtos = await handler.GetAsync();
        var model = dtos.Select(x => new ProductGridModel()
        {
            Id = x.Id,
            Title = x.Title,
        }).ToArray();
        return View(model);
    }

    [HttpGet("/[controller]/Add")]
    public IActionResult Add() => View();

    [HttpPost("/[controller]")]
    public async Task<IActionResult> Add(
        AddProductModel model,
        [FromServices] IAddProductHandler handler)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await handler.AddAsync(model.Title);
        if (result is null)
        {
            ModelState.AddModelError<AddProductModel>(x => x.Title, "Název není validní");
            return View(model);
        }

        return Redirect($"/Products/{result}");
    }

    [HttpGet("/[controller]/{id}")]
    public async Task<IActionResult> Detail(
        Guid id,
        [FromServices] IGetProductHandler handler)
    {
        var dto = await handler.GetAsync(id);
        if (dto is null)
            return NotFound();
        var model = ProductFormModel.FromDto(dto);
        return View(model);
    }

    [HttpPost("/[controller]/Amount/{id}")]
    public async Task<IActionResult> AddAmount(
        Guid id,
        [Bind(Prefix = "Changes")] ProductUpdateModel model,
        [FromServices] IAddAmountHandler handler)
    {
        var result = await handler.AddAmountAsync(id, model.Amount);
        return Redirect($"/Products/{id}");
    }
}
