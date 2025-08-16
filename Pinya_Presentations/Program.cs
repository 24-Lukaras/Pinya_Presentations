using Bogus;
using Microsoft.EntityFrameworkCore;
using Pinya_Presentations.Db;
using Pinya_Presentations.Db.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MigDb>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    o.UseSeeding((context, _) => {
        var faker = new Faker<Employee>()
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Company, f => f.Company.CompanyName())
            .RuleFor(x => x.Location, f => f.Address.Country());
        var employees = context.Set<Employee>();
        var employeesExist = employees.Any();
        if (!employeesExist)
        {
            var mockEmployees = faker.Generate(10);
            employees.AddRange(mockEmployees);
            context.SaveChanges();
        }
    });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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
