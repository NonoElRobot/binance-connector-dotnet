namespace Binance.Example.CSharp.Futures
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class AdjustCrosscollateralLtv_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<AdjustCrosscollateralLtv_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var futures = new Futures(httpClient);

            string result = await futures.AdjustCrosscollateralLtv("BUSD", 5m, LoanDirection.ADDITIONAL);
        }
    }
}