using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Db;
using Pinya_Presentations.Db.Repositories;
using Pinya_Presentations.Models;

namespace Pinya_Presentations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsRepository _products;
        private readonly CategoriesRepository _categories;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ProductsRepository products, CategoriesRepository categories, ILogger<HomeController> logger)
        {
            _products = products;
            _categories = categories;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var products = await _products.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> Product()
        {
            var products = await _products.GetAllAsync();
            var product = products.FirstOrDefault();

            if (product is null)
                return Redirect("/");

            var categories = await _categories.GetAllAsync();
            var model = new EditProductViewModel()
            {
                Id = product.Id,
                Title = product.Title,
                Category = categories.FirstOrDefault(x => x.Id == product.CategoryId)?.Title ?? string.Empty,
                CategoryId = product.CategoryId,
            };
            return View(model);
        }

        [ResponseCache(Duration = 3, Location = ResponseCacheLocation.Any)]
        public IActionResult OutputCache()
        {
            var model = Guid.NewGuid();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
