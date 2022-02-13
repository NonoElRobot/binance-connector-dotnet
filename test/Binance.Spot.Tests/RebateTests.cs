namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    public class RebateTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region GetSpotRebateHistoryRecords

        [TestMethod]
        public async Task GetSpotRebateHistoryRecords_Response()
        {
            string responseContent =
                "{\"status\":\"OK\",\"type\":\"GENERAL\",\"code\":\"000000000\",\"data\":{\"page\":1,\"totalRecords\":2,\"totalPageNum\":1,\"data\":[{\"asset\":\"USDT\",\"type\":1,\"amount\":\"0.0001126\",\"updateTime\":1637651320000}]}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/rebate/taxQuery", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var rebate = new Rebate(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await rebate.GetSpotRebateHistoryRecords();

            result.Should().Be(responseContent);
        }

        #endregion
    }
}