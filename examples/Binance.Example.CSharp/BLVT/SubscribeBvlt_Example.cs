namespace Binance.Example.CSharp.BLVT
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class SubscribeBvlt_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<SubscribeBvlt_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var Bvlt = new Bvlt(httpClient);

            string result = await Bvlt.SubscribeBvlt("BTCDOWN", 9.99999995m);
        }
    }
}