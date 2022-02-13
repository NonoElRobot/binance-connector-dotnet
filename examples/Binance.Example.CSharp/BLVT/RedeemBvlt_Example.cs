namespace Binance.Example.CSharp.BLVT
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class RedeemBvlt_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<RedeemBvlt_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var Bvlt = new Bvlt(httpClient);

            string result = await Bvlt.RedeemBvlt("BTCDOWN", 10.05022099m);
        }
    }
}