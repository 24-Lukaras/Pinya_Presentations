
using Pinya_Presentations.Events;
using System.Threading.Channels;

namespace Pinya_Presentations.Services;

public class EmailProcessor : BackgroundService
{
    private readonly ChannelReader<SendEmailEvent> _reader;
    private readonly IServiceScopeFactory _scopeFactory;
    public EmailProcessor(Channel<SendEmailEvent> channel, IServiceScopeFactory scopeFactory)
    {
        _reader = channel.Reader;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _reader.WaitToReadAsync(stoppingToken))
        {
            var message =  await _reader.ReadAsync(stoppingToken);
            using (var scope = _scopeFactory.CreateScope())
            {
                var sender = scope.ServiceProvider.GetRequiredService<SendGridSender>();
                await sender.SendTestMailAsync();
            }
        }
    }
}
