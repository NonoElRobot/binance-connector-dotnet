namespace Binance.Example.CSharp.Futures
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class CalculateRateAfterAdjustCrosscollateralLtvV2_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<CalculateRateAfterAdjustCrosscollateralLtvV2_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var futures = new Futures(httpClient);

            string result = await futures.CalculateRateAfterAdjustCrosscollateralLtvV2(
                "BTC",
                "BUSD",
                1.2375m,
                LoanDirection.ADDITIONAL);
        }
    }
}