using Microsoft.AspNetCore.SignalR;

namespace Pinya_Presentations.Hubs;

public class StocksHub : Hub
{
    public const string STOCKS_UPDATED_EVENT = "StocksUpdated";
    public static Dictionary<string, double> Stocks { get; } = new() {
        { "NVIDIA Corporation (NVDA)", 178.19 },
        { "Electronic Arts Inc. (EA)", 193.35 },
        { "The Boeing Company (BA)", 221.26 }
    };
}

public class StocksUpdater : BackgroundService
{
    private readonly IHubContext<StocksHub> _connections;
    public StocksUpdater(IHubContext<StocksHub> connections)
    {
        _connections = connections;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(Random.Shared.Next(3000, 6000), stoppingToken);

            foreach (var stock in StocksHub.Stocks)
            {
                double factor = 0.95 + Random.Shared.NextDouble() * 0.1;
                StocksHub.Stocks[stock.Key] = stock.Value * factor;
            }

            await _connections.Clients.All.SendAsync(StocksHub.STOCKS_UPDATED_EVENT, StocksHub.Stocks);
        }
    }
}
