namespace Binance.Example.CSharp.SubAccount
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class GetIpRestrictionForASubaccountApiKey_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<GetIpRestrictionForASubaccountApiKey_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var subAccount = new SubAccount(httpClient);

            string result = await subAccount.GetIpRestrictionForASubaccountApiKey("test@email", "api-key");
        }
    }
}