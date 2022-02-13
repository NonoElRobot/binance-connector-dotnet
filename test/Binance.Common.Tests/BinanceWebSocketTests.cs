namespace Binance.Common.Tests
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class BinanceWebSocketTests
    {
        #region ConnectAsync

        [TestMethod]
        public async Task ConnectAsync_Cancel_Stops_Connect()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com");

            await Task.WhenAll(
                binanceWebSocket.ConnectAsync(cancellationTokenSource.Token),
                Task.Run(() => cancellationTokenSource.Cancel()));
        }

        #endregion

        #region DisconnectAsync

        [TestMethod]
        public async Task DisconnectAsync_Cancel_Stops_Disconnect()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com");

            await binanceWebSocket.ConnectAsync(CancellationToken.None);

            await Task.WhenAll(
                binanceWebSocket.DisconnectAsync(cancellationTokenSource.Token),
                Task.Run(() => cancellationTokenSource.Cancel()));
        }

        #endregion

        #region SendAsync

        [TestMethod]
        public async Task SendAsync_Cancel_Stops_Send()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com");

            await binanceWebSocket.ConnectAsync(CancellationToken.None);

            await Task.WhenAll(
                binanceWebSocket.SendAsync(string.Empty, cancellationTokenSource.Token),
                Task.Run(() => cancellationTokenSource.Cancel()));
        }

        #endregion

        #region OnMessageReceived

        [TestMethod]
        public async Task OnMessageReceived_Subscribes_Action()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com");

            await binanceWebSocket.ConnectAsync(CancellationToken.None);

            binanceWebSocket.OnMessageReceived(
                message =>
                {
                    message.Should().Be("message");

                    return Task.CompletedTask;
                },
                CancellationToken.None);
        }

        [TestMethod]
        public async Task OnMessageReceived_Cancel_Drops_Receiver()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com");

            await binanceWebSocket.ConnectAsync(CancellationToken.None);

            binanceWebSocket.OnMessageReceived(
                message =>
                {
                    return Task.Delay(2);
                },
                cancellationTokenSource.Token);

            cancellationTokenSource.Cancel();
        }

        #endregion
    }
}