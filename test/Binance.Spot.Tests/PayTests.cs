namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    public class PayTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region GetPayTradeHistory

        [TestMethod]
        public async Task GetPayTradeHistory_Response()
        {
            string responseContent =
                "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderType\":\"C2C\",\"transactionId\":\"M_P_71505104267788288\",\"transactionTime\":1610090460133,\"amount\":\"23.72469206\",\"currency\":\"BNB\",\"fundsDetail\":[{\"currency\":\"\",\"amount\":\"\"}]}],\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/pay/transactions", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var pay = new Pay(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await pay.GetPayTradeHistory();

            result.Should().Be(responseContent);
        }

        #endregion
    }
}