namespace Binance.Common.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using FluentAssertions.Specialized;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Moq;
    using Moq.Protected;

    [TestClass]
    public class BinanceServiceTests
    {
        #region SendPublicAsync

        [TestMethod]
        public async Task SendPublicAsync_HttpMethod_Post()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Post),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Post);
        }

        [TestMethod]
        public async Task SendPublicAsync_HttpMethod_Put()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Put),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Put);
        }

        [TestMethod]
        public async Task SendPublicAsync_HttpMethod_Delete()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Delete),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Delete);
        }

        [TestMethod]
        public async Task SendPublicAsync_HttpMethod_Get()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Get);
        }

        [TestMethod]
        public async Task SendPublicAsync_QueryParameter_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("hello=world")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(
                string.Empty,
                HttpMethod.Get,
                new Dictionary<string, object> { { "hello", "world" } });
        }

        [TestMethod]
        public async Task SendPublicAsync_Empty_QueryParameter_Not_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => !rm.RequestUri.Query.Contains("hello=")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(
                string.Empty,
                HttpMethod.Get,
                new Dictionary<string, object> { { "hello", null } });
        }

        [TestMethod]
        public async Task SendPublicAsync_Server_Formatted_Unauthorized_Error_Throws_BinanceClientException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            string content = "{\"code\":1234,\"msg\":\"Message\"}";
            string headerKey = "Test-Header";
            string headerValue = "Test-Value";

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent(content)
            };
            response.Headers.Add(headerKey, headerValue);

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com");

            var action = new Func<Task<string>>(
                () => binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Get));
            ExceptionAssertions<BinanceClientException> exception =
                await action.Should().ThrowAsync<BinanceClientException>();

            exception.Which.Code.Should().Be(1234);
            exception.Which.Message.Should().Be("Message");
            exception.Which.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
            exception.Which.Headers.Should().ContainKey(headerKey);
            exception.Which.Headers[headerKey].First().Should().Be(headerValue);
        }

        [TestMethod]
        public async Task SendPublicAsync_Request_And_Response_Are_Logged()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            var mockLogger = new Mock<ILogger>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            var binanceService = new MockBinanceService(
                new HttpClient(new BinanceLoggingHandler(mockLogger.Object, mockMessageHandler.Object)),
                "https://www.binance.com",
                string.Empty,
                "apiSecret");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Get);

            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.AtLeast(2));
        }

        #endregion

        #region SendSignedAsync

        [TestMethod]
        public async Task SendSignedAsync_HttpMethod_Post()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Post),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Post);
        }

        [TestMethod]
        public async Task SendSignedAsync_HttpMethod_Put()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Put),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Put);
        }

        [TestMethod]
        public async Task SendSignedAsync_HttpMethod_Delete()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Delete),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Delete);
        }

        [TestMethod]
        public async Task SendSignedAsync_HttpMethod_Get()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
        }

        [TestMethod]
        public async Task SendSignedAsync_QueryParameter_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("hello=world")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Get,
                new Dictionary<string, object> { { "hello", "world" } });
        }

        [TestMethod]
        public async Task SendSignedAsync_Empty_QueryParameter_Not_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => !rm.RequestUri.Query.Contains("hello=")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Get,
                new Dictionary<string, object> { { "hello", null } });
        }

        [TestMethod]
        public async Task SendSignedAsync_Signature_In_Query_String_Is_Valid()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(
                        rm => rm.RequestUri.Query.Contains(
                            "signature=0b8e45a6918d16e018dbd1a53ea3f47b1c7bd20eed53601064226d0d86ecc836")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "api-key",
                "api-secret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "symbol", "LTCBTC" },
                    { "side", "BUY" },
                    { "type", "LIMIT" },
                    { "timeInForce", "GTC" },
                    { "quantity", 1 },
                    { "price", 0.1 },
                    { "recvWindow", 5000 },
                    { "timestamp", 1499827319559 }
                });
        }

        [TestMethod]
        public async Task SendSignedAsync_Timestamp_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("timestamp=1499827319559")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Post,
                new Dictionary<string, object> { { "timestamp", 1499827319559 } });
        }

        [TestMethod]
        public async Task SendSignedAsync_RecvWindow_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("recvWindow=1000")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Get,
                new Dictionary<string, object> { { "recvWindow", 1000 } });
        }

        [TestMethod]
        public async Task SendSignedAsync_RecvWindow_Default_Not_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => !rm.RequestUri.Query.Contains("recvWindow=")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                "apiKey",
                "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
        }

        [TestMethod]
        public async Task SendSignedAsync_Server_Unformatted_Internal_Error_Throws_BinanceServerException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.InternalServerError, Content = new StringContent("hello")
                    });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                null,
                "apiSecret");

            var action = new Func<Task<string>>(
                () => binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get));
            ExceptionAssertions<BinanceServerException> exception =
                await action.Should().ThrowAsync<BinanceServerException>();

            exception.Which.Message.Should().Be("hello");
        }

        [TestMethod]
        public async Task SendSignedAsync_Server_Formatted_Internal_Error_Throws_BinanceServerException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Content = new StringContent("{\"code\":1234,\"msg\":\"Message\"}")
                    });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                null,
                "apiSecret");

            var action = new Func<Task<string>>(
                () => binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get));
            ExceptionAssertions<BinanceServerException> exception =
                await action.Should().ThrowAsync<BinanceServerException>();

            exception.Which.Message.Should().Be("{\"code\":1234,\"msg\":\"Message\"}");
        }

        [TestMethod]
        public async Task SendSignedAsync_Server_Unformatted_Unauthorized_Error_Throws_BinanceClientException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            string content = "hello";
            string headerKey = "Test-Header";
            string headerValue = "Test-Value";

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent(content)
            };
            response.Headers.Add(headerKey, headerValue);

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                null,
                "apiSecret");

            var action = new Func<Task<string>>(
                () => binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get));
            ExceptionAssertions<BinanceClientException> exception =
                await action.Should().ThrowAsync<BinanceClientException>();

            exception.Which.Code.Should().Be(-1);
            exception.Which.Message.Should().Be(content);
            exception.Which.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
            exception.Which.Headers.Should().ContainKey(headerKey);
            exception.Which.Headers[headerKey].First().Should().Be(headerValue);
        }

        [TestMethod]
        public async Task SendSignedAsync_Server_Formatted_Unauthorized_Error_Throws_BinanceClientException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            string content = "{\"code\":1234,\"msg\":\"Message\"}";
            string headerKey = "Test-Header";
            string headerValue = "Test-Value";

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent(content)
            };
            response.Headers.Add(headerKey, headerValue);

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                null,
                "apiSecret");

            var action = new Func<Task<string>>(
                () => binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get));
            ExceptionAssertions<BinanceClientException> exception =
                await action.Should().ThrowAsync<BinanceClientException>();

            exception.Which.Code.Should().Be(1234);
            exception.Which.Message.Should().Be("Message");
            exception.Which.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
            exception.Which.Headers.Should().ContainKey(headerKey);
            exception.Which.Headers[headerKey].First().Should().Be(headerValue);
        }

        [TestMethod]
        public async Task SendSignedAsync_Missing_ApiKey_Throws_BinanceClientException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(rm => !rm.Headers.Contains("X-MBX-APIKEY")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Unauthorized,
                        Content = new StringContent("{\"code\":-2014,\"msg\":\"API-key format invalid.\"}")
                    });
            var binanceService = new MockBinanceService(
                new HttpClient(mockMessageHandler.Object),
                "https://www.binance.com",
                null,
                "apiSecret");

            var action = new Func<Task<string>>(
                () => binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get));
            await action.Should().ThrowAsync<BinanceClientException>();
        }

        [TestMethod]
        public async Task SendSignedAsync_Request_And_Response_Are_Logged()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            var mockLogger = new Mock<ILogger>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            var binanceService = new MockBinanceService(
                new HttpClient(new BinanceLoggingHandler(mockLogger.Object, mockMessageHandler.Object)),
                "https://www.binance.com",
                string.Empty,
                "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);

            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.AtLeast(2));
        }

        #endregion
    }
}