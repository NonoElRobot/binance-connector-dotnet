namespace Binance.Example.CSharp.Futures
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class GetFutureAccountTransactionHistoryList_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<GetFutureAccountTransactionHistoryList_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var futures = new Futures(httpClient);

            string result = await futures.GetFutureAccountTransactionHistoryList("USDT", 1631318399000);
        }
    }
}