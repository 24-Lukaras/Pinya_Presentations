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
        private readonly Database _db;
        private readonly CategoriesRepository _categories;
        private readonly ILogger<HomeController> _logger;

        public HomeController(Database db, CategoriesRepository categories, ILogger<HomeController> logger)
        {
            _db = db;
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

        public async Task<IActionResult> Product()
        {
            var product = await _db.Products.FirstOrDefaultAsync();

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
