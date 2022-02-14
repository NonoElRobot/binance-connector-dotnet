namespace Binance.Example.CSharp.MarginAccountTrade
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class MarginAccountNewOco_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<MarginAccountNewOco_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var marginAccountTrade = new MarginAccountTrade(httpClient);

            string result = await marginAccountTrade.MarginAccountNewOco(
                "LTCBTC",
                Side.BUY,
                0.624363m,
                522.23m,
                515.38276m);
        }
    }
}