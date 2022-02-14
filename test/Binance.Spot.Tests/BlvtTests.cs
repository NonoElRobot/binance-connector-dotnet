namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    public class BvltTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region GetBvltInfo

        [TestMethod]
        public async Task GetBvltInfo_Response()
        {
            string responseContent =
                "[{\"tokenName\":\"BTCDOWN\",\"description\":\"3X Short Bitcoin Token\",\"underlying\":\"BTC\",\"tokenIssued\":\"717953.95\",\"basket\":\"-821.474 BTCUSDT Futures\",\"currentBaskets\":[{\"symbol\":\"BTCUSDT\",\"amount\":\"-1183.984\",\"notionalValue\":\"-22871089.96704\"}],\"nav\":\"4.79\",\"realLeverage\":\"-2.316\",\"fundingRate\":\"0.001020\",\"dailyManagementFee\":\"0.0001\",\"purchaseFeePct\":\"0.0010\",\"dailyPurchaseLimit\":\"100000.00\",\"redeemFeePct\":\"0.0010\",\"dailyRedeemLimit\":\"1000000.00\",\"timstamp\":1583127900000},{\"tokenName\":\"LINKUP\",\"description\":\"3X LONG ChainLink Token\",\"underlying\":\"LINK\",\"tokenIssued\":\"163846.99\",\"basket\":\"417288.870 LINKUSDT Futures\",\"currentBaskets\":[{\"symbol\":\"LINKUSDT\",\"amount\":\"1640883.83\",\"notionalValue\":\"22596611.22293\"}],\"nav\":\"9.60\",\"realLeverage\":\"2.597\",\"fundingRate\":\"-0.000917\",\"dailyManagementFee\":\"0.0001\",\"purchaseFeePct\":\"0.0010\",\"dailyPurchaseLimit\":\"100000.00\",\"redeemFeePct\":\"0.0010\",\"dailyRedeemLimit\":\"1000000.00\",\"timstamp\":1583127900000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/Bvlt/tokenInfo", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var Bvlt = new Bvlt(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await Bvlt.GetBvltInfo();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetBvltUserLimitInfo

        [TestMethod]
        public async Task GetBvltUserLimitInfo_Response()
        {
            string responseContent =
                "[{\"tokenName\":\"LINKUP\",\"userDailyTotalPurchaseLimit\":\"1000\",\"userDailyTotalRedeemLimit\":\"1000\"},{\"tokenName\":\"LINKDOWN\",\"userDailyTotalPurchaseLimit\":\"1000\",\"userDailyTotalRedeemLimit\":\"50000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/Bvlt/userLimit", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var Bvlt = new Bvlt(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await Bvlt.GetBvltUserLimitInfo();

            result.Should().Be(responseContent);
        }

        #endregion

        #region QueryRedemptionRecord

        [TestMethod]
        public async Task QueryRedemptionRecord_Response()
        {
            string responseContent =
                "[{\"id\":1,\"tokenName\":\"LINKUP\",\"amount\":\"0.54216292\",\"nav\":\"18.36345064\",\"fee\":\"0.00995598\",\"netProceed\":\"9.94602604\",\"timstamp\":1599128003050}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/Bvlt/redeem/record", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var Bvlt = new Bvlt(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await Bvlt.QueryRedemptionRecord();

            result.Should().Be(responseContent);
        }

        #endregion

        #region QuerySubscriptionRecord

        [TestMethod]
        public async Task QuerySubscriptionRecord_Response()
        {
            string responseContent =
                "[{\"id\":1,\"tokenName\":\"LINKUP\",\"amount\":\"0.54216292\",\"nav\":\"18.42621386\",\"fee\":\"0.00999000\",\"totalCharge\":\"9.99999991\",\"timstamp\":1599127217916}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/Bvlt/subscribe/record", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var Bvlt = new Bvlt(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await Bvlt.QuerySubscriptionRecord();

            result.Should().Be(responseContent);
        }

        #endregion

        #region RedeemBvlt

        [TestMethod]
        public async Task RedeemBvlt_Response()
        {
            string responseContent =
                "{\"id\":123,\"status\":\"S\",\"tokenName\":\"LINKUP\",\"redeemAmount\":\"0.95590905\",\"amount\":\"10.05022099\",\"timstamp\":1600250279614}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/Bvlt/redeem", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var Bvlt = new Bvlt(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await Bvlt.RedeemBvlt("BTCDOWN", 10.05022099m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region SubscribeBvlt

        [TestMethod]
        public async Task SubscribeBvlt_Response()
        {
            string responseContent =
                "{\"id\":123,\"status\":\"S\",\"tokenName\":\"LINKUP\",\"amount\":\"0.95590905\",\"cost\":\"9.99999995\",\"timstamp\":1600249972899}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/Bvlt/subscribe", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var Bvlt = new Bvlt(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await Bvlt.SubscribeBvlt("BTCDOWN", 9.99999995m);

            result.Should().Be(responseContent);
        }

        #endregion
    }
}