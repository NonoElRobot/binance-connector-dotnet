namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    public class NftTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region GetNftAsset

        [TestMethod]
        public async Task GetNftAsset_Response()
        {
            string responseContent =
                "{\"total\":347,\"list\":[{\"network\":\"BSC\",\"contractAddress\":\"REGULAR11234567891779\",\"tokenId\":\"100900000017\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/nft/user/getAsset", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var nFt = new Nft(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await nFt.GetNftAsset();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetNftDepositHistory

        [TestMethod]
        public async Task GetNftDepositHistory_Response()
        {
            string responseContent =
                "{\"total\":1,\"list\":[{\"network\":\"ETH\",\"txID\":0,\"contractAdrress\":\"0xe507c961ee127d4439977a61af39c34eafee0dc6\",\"tokenId\":\"10014\",\"timestamp\":1629986047000}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/nft/history/deposit", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var nFt = new Nft(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await nFt.GetNftDepositHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetNftTransactionHistory

        [TestMethod]
        public async Task GetNftTransactionHistory_Response()
        {
            string responseContent =
                "{\"total\":1,\"list\":[{\"orderNo\":\"1_470502070600699904\",\"tokens\":[{\"network\":\"BSC\",\"tokenId\":\"216000000496\",\"contractAddress\":\"MYSTERY_BOX0000087\"}],\"tradeTime\":1626941236000,\"tradeAmount\":\"19.60000000\",\"tradeCurrency\":\"BNB\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/nft/history/transactions", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var nFt = new Nft(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await nFt.GetNftTransactionHistory(1);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetNftWithdrawHistory

        [TestMethod]
        public async Task GetNftWithdrawHistory_Response()
        {
            string responseContent =
                "{\"total\":178,\"list\":[{\"network\":\"ETH\",\"txID\":\"0x2be5eed31d787fdb4880bc631c8e76bdfb6150e137f5cf1732e0416ea206f57f\",\"contractAdrress\":\"0xe507c961ee127d4439977a61af39c34eafee0dc6\",\"tokenId\":\"1000001247\",\"timestamp\":1633674433000,\"fee\":0.1,\"feeAsset\":\"ETH\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/nft/history/withdraw", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var nFt = new Nft(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await nFt.GetNftWithdrawHistory();

            result.Should().Be(responseContent);
        }

        #endregion
    }
}