namespace Binance.Example.CSharp.UserDataWebSocket
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Spot;

    public class UserDataWebSocket_Example
    {
        public static async Task Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                });
            ILogger logger = loggerFactory.CreateLogger<UserDataWebSocket_Example>();
            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger);
            var httpClient = new HttpClient(loggingHandler);

            string apiKey = "api-key";
            string apiSecret = "api-secret";

            var userDataStreams = new UserDataStreams(httpClient, apiKey: apiKey, apiSecret: apiSecret);
            string response = await userDataStreams.CreateSpotListenKey();
            string listenKey = JsonConvert.DeserializeObject<dynamic>(response).listenKey.ToString();

            var websocket = new UserDataWebSocket(listenKey);

            var onlyOneMessage = new TaskCompletionSource<string>();
            websocket.OnMessageReceived(
                data =>
                {
                    onlyOneMessage.SetResult(data);
                    return Task.CompletedTask;
                },
                CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);
            string message = await onlyOneMessage.Task;
            logger.LogInformation(message);
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}