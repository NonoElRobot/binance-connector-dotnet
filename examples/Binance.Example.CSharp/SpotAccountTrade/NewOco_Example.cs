namespace Binance.Example.CSharp.SpotAccountTrade
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class NewOco_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<NewOco_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var spotAccountTrade = new SpotAccountTrade(httpClient);

            string result = await spotAccountTrade.NewOco("LTCBTC", Side.BUY, 522.23m, 127.54398m, 137.027m);
        }
    }
}