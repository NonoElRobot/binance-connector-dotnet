namespace Binance.Example.CSharp.Wallet
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class Withdraw_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<Withdraw_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var wallet = new Wallet(httpClient);

            string result = await wallet.Withdraw("BNB", "1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv", 2.1m);
        }
    }
}