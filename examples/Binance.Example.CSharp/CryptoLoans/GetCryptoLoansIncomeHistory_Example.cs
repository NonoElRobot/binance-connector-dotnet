namespace Binance.Example.CSharp.CryptoLoans
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class GetCryptoLoansIncomeHistory_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<GetCryptoLoansIncomeHistory_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var cryptoLoans = new CryptoLoans(httpClient);

            string result = await cryptoLoans.GetCryptoLoansIncomeHistory("BTC");
        }
    }
}