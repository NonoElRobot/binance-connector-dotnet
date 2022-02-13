namespace Binance.Example.CSharp.BSwap
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class RemoveLiquidity_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<RemoveLiquidity_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var bSwap = new BSwap(httpClient);

            string result = await bSwap.RemoveLiquidity(2, LiquidityRemovalType.SINGLE, 522.23m);
        }
    }
}