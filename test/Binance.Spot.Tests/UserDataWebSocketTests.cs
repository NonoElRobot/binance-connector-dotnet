namespace Binance.Spot.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    public class UserDataWebSocketTests
    {
        #region ConnectAsync

        [TestMethod]
        public async Task ConnectAsync_Url_Formation_Single_Listen_Key()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();

            string listenKey = "iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q6";
            var websocket = new UserDataWebSocket(listenKey, mockHandler.Object);
            await websocket.ConnectAsync(CancellationToken.None);

            mockHandler.Verify(
                mock => mock.ConnectAsync(
                    It.Is<Uri>(
                        uri => uri.AbsolutePath == "/ws/iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q6"),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [TestMethod]
        public async Task ConnectAsync_Url_Formation_Multiple_Listen_Keys()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();

            string[] listenKeys = new[]
            {
                "iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q6",
                "iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q7"
            };
            var websocket = new UserDataWebSocket(listenKeys, mockHandler.Object);
            await websocket.ConnectAsync(CancellationToken.None);

            mockHandler.Verify(
                mock => mock.ConnectAsync(
                    It.Is<Uri>(
                        uri => uri.AbsolutePath == "/stream" && uri.Query ==
                            "?streams=iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q6/iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q7"),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        #endregion
    }
}