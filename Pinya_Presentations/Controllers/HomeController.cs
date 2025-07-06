using System.Diagnostics;
using System.Threading.Channels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinya_Presentations.Events;
using Pinya_Presentations.Models;
using Pinya_Presentations.Services;
using Pinya_Presentations.Settings;

namespace Pinya_Presentations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChannelWriter<SendEmailEvent> _writer;
        private readonly SendGridSender _sender;
        private readonly EmailSettings _settings;

        public HomeController(ILogger<HomeController> logger, Channel<SendEmailEvent> channel, SendGridSender sender, IOptions<EmailSettings> settings)
        {
            _logger = logger;
            _writer = channel.Writer;
            _sender = sender;
            _settings = settings.Value;
        }

        public IActionResult Index() => View();

        public IActionResult Sending() => View();

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailsModel model)
        {
            if (model.UseChannels)
            {
                await _writer.WriteAsync(new SendEmailEvent());
                await _writer.WriteAsync(new SendEmailEvent());
                await _writer.WriteAsync(new SendEmailEvent());
                await _writer.WriteAsync(new SendEmailEvent());
                await _writer.WriteAsync(new SendEmailEvent());
            }
            else
            {
                await _sender.SendTestMailAsync();
                await _sender.SendTestMailAsync();
                await _sender.SendTestMailAsync();
                await _sender.SendTestMailAsync();
                await _sender.SendTestMailAsync();
            }

            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
