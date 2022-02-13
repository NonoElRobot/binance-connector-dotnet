namespace Binance.Example.CSharp.Fiat
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class GetFiatPaymentsHistory_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<GetFiatPaymentsHistory_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var fiat = new Fiat(httpClient);

            string result = await fiat.GetFiatPaymentsHistory(FiatPaymentTransactionType.BUY);
        }
    }
}