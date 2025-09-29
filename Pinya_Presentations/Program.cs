using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Db;
using Pinya_Presentations.Db.Repositories;
using Pinya_Presentations.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Database>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDb"));
});
builder.Services.AddScoped<CategoriesRepository>();
builder.Services.AddScoped<CategoriesScopedCache>();
builder.Services.AddResponseCaching();

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
