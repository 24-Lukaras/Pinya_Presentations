using Microsoft.Extensions.Options;
using Pinya_Presentations.Events;
using Pinya_Presentations.Services;
using Pinya_Presentations.Settings;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SendGridSender>();
builder.Services.AddHostedService<EmailProcessor>();
builder.Services.Configure<EmailSettings>(builder.Configuration);

var emailChannel = Channel.CreateUnbounded<SendEmailEvent>();
builder.Services.AddSingleton(emailChannel);

var app = builder.Build();

var config = app.Services.GetRequiredService<IOptions<EmailSettings>>();
if (config.Value is null
    || string.IsNullOrEmpty(config.Value.SendGridApiKey)
    || string.IsNullOrEmpty(config.Value.Sender)
    || string.IsNullOrEmpty(config.Value.Receiver))
    throw new Exception($"Please configure keys '{nameof(config.Value.SendGridApiKey)}', '{nameof(config.Value.Sender)}', '{nameof(config.Value.Receiver)}' in user secrets.");

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
