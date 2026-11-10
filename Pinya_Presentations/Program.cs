using Pinya_Presentations.Configuration;
using Pinya_Presentations.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<ShardsConfiguration>(builder.Configuration);
builder.Services.AddSingleton<TenantsService>();
builder.Services.AddScoped<ITenantAccessor, TenantAccessor>();
builder.Services.AddScoped<AppDbContextFactory>();
builder.Services.AddScoped<IAppDb, AppDb>();
builder.Services.AddHostedService<MigrationsFactory>();

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
