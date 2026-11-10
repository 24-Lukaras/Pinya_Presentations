using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pinya_Presentations.Models;
using Pinya_Presentations.Services;

namespace Pinya_Presentations.Controllers
{
    public class HomeController : Controller
    {
        private readonly TenantsService _service;
        private readonly IAppDb _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            TenantsService service,
            IAppDb db,
            ILogger<HomeController> logger)
        {
            _service = service;
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _db.Employees.GetAllAsync();
            if (!model.Any())
                return View();
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var tenant = _service.Tenants.FirstOrDefault(x => x.Id == model.TenantId);
            if (tenant is null)
                return Redirect("/");
            Response.Cookies.Append(TenantAccessor.TENANT_COOKIE_KEY, tenant.Id.ToString());
            return Redirect("/");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete(TenantAccessor.TENANT_COOKIE_KEY);
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
