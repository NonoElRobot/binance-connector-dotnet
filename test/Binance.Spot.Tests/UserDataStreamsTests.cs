namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    public class UserDataStreamsTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region CloseIsolatedMarginListenKey

        [TestMethod]
        public async Task CloseIsolatedMarginListenKey_Response()
        {
            string responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream/isolated", HttpMethod.Delete)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result =
                await userDataStreams.CloseIsolatedMarginListenKey(
                    "T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");

            result.Should().Be(responseContent);
        }

        #endregion

        #region CloseMarginListenKey

        [TestMethod]
        public async Task CloseMarginListenKey_Response()
        {
            string responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream", HttpMethod.Delete)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result =
                await userDataStreams.CloseMarginListenKey(
                    "T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");

            result.Should().Be(responseContent);
        }

        #endregion

        #region CloseSpotListenKey

        [TestMethod]
        public async Task CloseSpotListenKey_Response()
        {
            string responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/userDataStream", HttpMethod.Delete)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result =
                await userDataStreams.CloseSpotListenKey(
                    "pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s61cv6a81va65sdf19v8a65a1");

            result.Should().Be(responseContent);
        }

        #endregion

        #region CreateIsolatedMarginListenKey

        [TestMethod]
        public async Task CreateIsolatedMarginListenKey_Response()
        {
            string responseContent = "{\"listenKey\":\"T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream/isolated", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await userDataStreams.CreateIsolatedMarginListenKey();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CreateMarginListenKey

        [TestMethod]
        public async Task CreateMarginListenKey_Response()
        {
            string responseContent = "{\"listenKey\":\"T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await userDataStreams.CreateMarginListenKey();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CreateSpotListenKey

        [TestMethod]
        public async Task CreateSpotListenKey_Response()
        {
            string responseContent =
                "{\"listenKey\":\"pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s61cv6a81va65sdf19v8a65a1\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/userDataStream", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await userDataStreams.CreateSpotListenKey();

            result.Should().Be(responseContent);
        }

        #endregion

        #region PingIsolatedMarginListenKey

        [TestMethod]
        public async Task PingIsolatedMarginListenKey_Response()
        {
            string responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream/isolated", HttpMethod.Put)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result =
                await userDataStreams.PingIsolatedMarginListenKey(
                    "T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");

            result.Should().Be(responseContent);
        }

        #endregion

        #region PingMarginListenKey

        [TestMethod]
        public async Task PingMarginListenKey_Response()
        {
            string responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream", HttpMethod.Put)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result =
                await userDataStreams.PingMarginListenKey(
                    "T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");

            result.Should().Be(responseContent);
        }

        #endregion

        #region PingSpotListenKey

        [TestMethod]
        public async Task PingSpotListenKey_Response()
        {
            string responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/userDataStream", HttpMethod.Put)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result =
                await userDataStreams.PingSpotListenKey(
                    "pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s61cv6a81va65sdf19v8a65a1");

            result.Should().Be(responseContent);
        }

        #endregion
    }
}