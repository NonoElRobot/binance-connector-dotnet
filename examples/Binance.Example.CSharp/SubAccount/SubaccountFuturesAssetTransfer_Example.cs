namespace Binance.Example.CSharp.SubAccount
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;
    using Spot.Models;

    public class SubaccountFuturesAssetTransfer_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<SubaccountFuturesAssetTransfer_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var subAccount = new SubAccount(httpClient);

            string result = await subAccount.SubaccountFuturesAssetTransfer(
                "aaa@test.com",
                "bbb@test.com",
                FuturesType.USDT_MARGINED_FUTURES,
                "BNB",
                2.187m);
        }
    }
}