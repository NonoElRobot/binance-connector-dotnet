namespace Binance.Example.CSharp.Savings
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class GetLeftDailyPurchaseQuotaOfFlexibleProduct_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<GetLeftDailyPurchaseQuotaOfFlexibleProduct_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var savings = new Savings(httpClient);

            string result = await savings.GetLeftDailyPurchaseQuotaOfFlexibleProduct("BTC001");
        }
    }
}