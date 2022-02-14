namespace Binance.Spot.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    public class MarketDataWebSocketTests
    {
        #region ConnectAsync

        [TestMethod]
        public async Task ConnectAsync_Url_Formation_Single_Stream_Key()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();

            string listenKey = "BTCUSDT@trade";
            var websocket = new MarketDataWebSocket(listenKey, mockHandler.Object);
            await websocket.ConnectAsync(CancellationToken.None);

            mockHandler.Verify(
                mock => mock.ConnectAsync(
                    It.Is<Uri>(uri => uri.AbsolutePath == "/ws/BTCUSDT@trade"),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [TestMethod]
        public async Task ConnectAsync_Url_Formation_Multiple_Stream_Keys()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();

            string[] listenKeys = new[] { "BTCUSDT@trade", "BNBUSDT@kline_1m" };
            var websocket = new MarketDataWebSocket(listenKeys, mockHandler.Object);
            await websocket.ConnectAsync(CancellationToken.None);

            mockHandler.Verify(
                mock => mock.ConnectAsync(
                    It.Is<Uri>(
                        uri => uri.AbsolutePath == "/stream" && uri.Query == "?streams=BTCUSDT@trade/BNBUSDT@kline_1m"),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        #endregion
    }
}