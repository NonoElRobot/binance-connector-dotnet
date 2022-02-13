namespace Binance.Example.CSharp.MarketDataWebSocket
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class TradeStream_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<TradeStream_Example>();

            var websocket = new MarketDataWebSocket("btcusdt@trade");

            var onlyOneMessage = new TaskCompletionSource<string>();

            websocket.OnMessageReceived(
                data =>
                {
                    onlyOneMessage.SetResult(data);
                    return Task.CompletedTask;
                },
                CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            string message = await onlyOneMessage.Task;

            logger.LogInformation(message);

            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}