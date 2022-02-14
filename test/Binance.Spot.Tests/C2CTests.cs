namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;
    using Spot.Models;

    public class C2CTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region GetC2cTradeHistory

        [TestMethod]
        public async Task GetC2cTradeHistory_Response()
        {
            string responseContent =
                "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderNumber\":\"20219644646554779648\",\"advNo\":\"11218246497340923904\",\"tradeType\":\"SELL\",\"asset\":\"BUSD\",\"fiat\":\"CNY\",\"fiatSymbol\":\"￥\",\"amount\":\"5000.00000000\",\"totalPrice\":\"33400.00000000\",\"unitPrice\":\"6.68\",\"orderStatus\":\"COMPLETED\",\"createTime\":1619361369000,\"commission\":\"0\",\"counterPartNickName\":\"ab***\",\"advertisementRole\":\"TAKER\"}],\"total\":1,\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/c2c/orderMatch/listUserOrderHistory", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var c2C = new C2C(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await c2C.GetC2CTradeHistory(Side.BUY);

            result.Should().Be(responseContent);
        }

        #endregion
    }
}