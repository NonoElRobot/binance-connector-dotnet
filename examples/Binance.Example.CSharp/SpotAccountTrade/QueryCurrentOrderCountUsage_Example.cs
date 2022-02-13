namespace Binance.Example.CSharp.SpotAccountTrade
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class QueryCurrentOrderCountUsage_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<QueryCurrentOrderCountUsage_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var trade = new SpotAccountTrade(httpClient);

            string result = await trade.QueryCurrentOrderCountUsage();
        }
    }
}