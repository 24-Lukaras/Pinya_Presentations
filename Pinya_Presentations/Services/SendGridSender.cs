using Microsoft.Extensions.Options;
using Pinya_Presentations.Settings;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Pinya_Presentations.Services;

public class SendGridSender
{
    private readonly EmailSettings _settings;

    public SendGridSender(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendTestMailAsync()
    {
        var message = new SendGridMessage()
        {
            Subject = "Test",
            HtmlContent = "<p>Test</p>",
            From = new EmailAddress(_settings.Sender),
        };
        message.AddTo(_settings.Receiver);
        var client = new SendGridClient(_settings.SendGridApiKey);
        await client.SendEmailAsync(message);

        // simulated logging to database
        await Task.Delay(200);
    }
}
