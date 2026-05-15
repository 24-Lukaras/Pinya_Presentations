using Pinya_Presentations.Modules.Absence.Navigation;
using Pinya_Presentations.Modules.Employees.Navigation;
using Pinya_Presentations.Modules.News.Navigation;
using Pinya_Presentations.Services.Auth;
using Pinya_Presentations.Services.Navigation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserContext>();

builder.Services.AddScoped<INavigationItem, AbsenceSettingsNavigationItem>();
builder.Services.AddScoped<INavigationItem, AllAbsenceNavigationItem>();
builder.Services.AddScoped<INavigationItem, SubordinatesAbsenceNavigationItem>();

builder.Services.AddScoped<INavigationItem, AddEmployeeNavigationItem>();
builder.Services.AddScoped<INavigationItem, EmployeesListNavigationItem>();
builder.Services.AddScoped<INavigationItem, EmployeesInactiveListNavigationItem>();

builder.Services.AddScoped<INavigationItem, NewsNavigationItem>();

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

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
