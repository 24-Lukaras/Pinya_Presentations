using EventSourcingData;
using EventSourcingData.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Pinya_Presentations.Services;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDb(connectionString!);
builder.Services.AddScoped<ILoggedUserProvider, LoggedUserProvider>();
builder.Services.AddAuthorization(opt =>
{
    opt.DefaultPolicy = new AuthorizationPolicy([new ClaimsAuthorizationRequirement(ClaimTypes.Name, null)], [CookieAuthenticationDefaults.AuthenticationScheme]);
});
builder.Services.AddAuthentication().AddCookie(opt =>
{
    opt.LoginPath = "/login";
    opt.LogoutPath = "/logout";
    opt.ExpireTimeSpan = TimeSpan.FromHours(1);
    opt.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets()
    .RequireAuthorization();

app.MapControllerRoute(
    name: "login",
    pattern: "login",
    defaults: new {
        controller = "Account",
        action = "Login"
    })
    .AllowAnonymous();
app.MapControllerRoute(
    name: "logout",
    pattern: "logout",
    defaults: new
    {
        controller = "Account",
        action = "Logout"
    })
    .AllowAnonymous();

app.Run();
