namespace Binance.Example.CSharp.UserDataStreams
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Spot;

    public class CloseMarginListenKey_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<CloseMarginListenKey_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            var userDataStreams = new UserDataStreams(httpClient);

            string result =
                await userDataStreams.CloseMarginListenKey(
                    "T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");
        }
    }
}