namespace Binance.Example.CSharp.Wallet
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class UserUniversalTransfer_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<UserUniversalTransfer_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var wallet = new Wallet(httpClient);

            string result = await wallet.UserUniversalTransfer(UniversalTransferType.MAIN_UMFUTURE, "BNB", 2.1m);
        }
    }
}