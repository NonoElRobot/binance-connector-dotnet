namespace Binance.Example.CSharp.MarginAccountTrade
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class MarginAccountNewOrder_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<MarginAccountNewOrder_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var marginAccountTrade = new MarginAccountTrade(httpClient);

            string result = await marginAccountTrade.MarginAccountNewOrder("BTCUSDT", Side.SELL, OrderType.MARKET);
        }
    }
}