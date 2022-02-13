namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    public class ConvertTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region GetConvertTradeHistory

        [TestMethod]
        public async Task GetConvertTradeHistory_Response()
        {
            string responseContent =
                "{\"list\":[{\"quoteId\":\"f3b91c525b2644c7bc1e1cd31b6e1aa6\",\"orderId\":940708407462087200,\"orderStatus\":\"SUCCESS\",\"fromAsset\":\"USDT\",\"fromAmount\":\"20\",\"toAsset\":\"BNB\",\"toAmount\":\"0.06154036\",\"ratio\":\"0.00307702\",\"inverseRatio\":\"324.99\",\"createTime\":1624248872184}],\"startTime\":1623824139000,\"endTime\":1626416139000,\"limit\":100,\"moreData\":false}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/convert/tradeFlow", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var convert = new Convert(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await convert.GetConvertTradeHistory(1639646747000, 1642325147000);

            result.Should().Be(responseContent);
        }

        #endregion
    }
}