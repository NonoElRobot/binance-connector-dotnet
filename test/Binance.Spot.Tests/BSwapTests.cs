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

    public class BSwapTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region AddLiquidity

        [TestMethod]
        public async Task AddLiquidity_Response()
        {
            string responseContent = "{\"operationId\":12341}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/liquidityAdd", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.AddLiquidity(2, "USDT", 522.23m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region AddLiquidityPreview

        [TestMethod]
        public async Task AddLiquidityPreview_Response()
        {
            string responseContent =
                "{\"quoteAsset\":\"USDT\",\"baseAsset\":\"BUSD\",\"quoteAmt\":300000,\"baseAmt\":299975,\"price\":1.00008334,\"share\":1.23}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/addLiquidityPreview", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.AddLiquidityPreview(2, "SINGLE", "USDT", 1.1m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region ClaimRewards

        [TestMethod]
        public async Task ClaimRewards_Response()
        {
            string responseContent = "{\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/claimRewards", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.ClaimRewards();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetClaimedHistory

        [TestMethod]
        public async Task GetClaimedHistory_Response()
        {
            string responseContent =
                "[{\"poolId\":52,\"poolName\":\"BNB/USDT\",\"assetRewards\":\"BNB\",\"claimTime\":1565769342148,\"claimAmount\":2.3e-7,\"status\":1}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/claimedHistory", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.GetClaimedHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetLiquidityInformationOfAPool

        [TestMethod]
        public async Task GetLiquidityInformationOfAPool_Response()
        {
            string responseContent =
                "[{\"poolId\":2,\"poolNmae\":\"BUSD/USDT\",\"updateTime\":1565769342148,\"liquidity\":{\"BUSD\":100000315.79,\"USDT\":99999245.54},\"share\":{\"shareAmount\":12415,\"sharePercentage\":0.00006207,\"asset\":{\"BUSD\":6207.02,\"USDT\":6206.95}}}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/liquidity", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.GetLiquidityInformationOfAPool();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetLiquidityOperationRecord

        [TestMethod]
        public async Task GetLiquidityOperationRecord_Response()
        {
            string responseContent =
                "[{\"operationId\":12341,\"poolId\":2,\"poolName\":\"BUSD/USDT\",\"operation\":\"ADD\",\"status\":1,\"updateTime\":1565769342148,\"shareAmount\":\"10.1\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/liquidityOps", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.GetLiquidityOperationRecord();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetSwapHistory

        [TestMethod]
        public async Task GetSwapHistory_Response()
        {
            string responseContent =
                "[{\"swapId\":2314,\"swapTime\":1565770342148,\"status\":0,\"quoteAsset\":\"USDT\",\"baseAsset\":\"BUSD\",\"quoteQty\":300000,\"baseQty\":299975,\"price\":1.00008334,\"fee\":120}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/swap", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.GetSwapHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetUnclaimedRewardsRecord

        [TestMethod]
        public async Task GetUnclaimedRewardsRecord_Response()
        {
            string responseContent =
                "{\"totalUnclaimedRewards\":{\"BUSD\":100000315.79,\"BNB\":1e-8,\"USDT\":2e-8},\"details\":{\"BNB/USDT\":{\"BUSD\":100000315.79,\"USDT\":2e-8},\"BNB/BTC\":{\"BNB\":1e-8}}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/unclaimedRewards", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.GetUnclaimedRewardsRecord();

            result.Should().Be(responseContent);
        }

        #endregion

        #region ListAllSwapPools

        [TestMethod]
        public async Task ListAllSwapPools_Response()
        {
            string responseContent =
                "[{\"poolId\":2,\"poolName\":\"BUSD/USDT\",\"assets\":[\"BUSD\",\"USDT\"]},{\"poolId\":3,\"poolName\":\"BUSD/DAI\",\"assets\":[\"BUSD\",\"DAI\"]},{\"poolId\":4,\"poolName\":\"USDT/DAI\",\"assets\":[\"USDT\",\"DAI\"]}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/pools", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.ListAllSwapPools();

            result.Should().Be(responseContent);
        }

        #endregion

        #region PoolConfigure

        [TestMethod]
        public async Task PoolConfigure_Response()
        {
            string responseContent =
                "[{\"poolId\":2,\"poolNmae\":\"BUSD/USDT\",\"updateTime\":1565769342148,\"liquidity\":{\"constantA\":2000,\"minRedeemShare\":0.1,\"slippageTolerance\":0.2},\"assetConfigure\":{\"BUSD\":{\"minAdd\":10,\"maxAdd\":20,\"minSwap\":10,\"maxSwap\":30},\"USDT\":{\"minAdd\":10,\"maxAdd\":20,\"minSwap\":10,\"maxSwap\":30}}}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/poolConfigure", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.PoolConfigure();

            result.Should().Be(responseContent);
        }

        #endregion

        #region RemoveLiquidity

        [TestMethod]
        public async Task RemoveLiquidity_Response()
        {
            string responseContent = "{\"operationId\":12341}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/liquidityRemove", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.RemoveLiquidity(2, LiquidityRemovalType.SINGLE, 522.23m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region RequestQuote

        [TestMethod]
        public async Task RequestQuote_Response()
        {
            string responseContent =
                "{\"quoteAsset\":\"USDT\",\"baseAsset\":\"BUSD\",\"quoteQty\":300000,\"baseQty\":299975,\"price\":1.00008334,\"slippage\":0.00007245,\"fee\":120}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/quote", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.RequestQuote("USDT", "BUSD", 300000m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region Swap

        [TestMethod]
        public async Task Swap_Response()
        {
            string responseContent = "{\"swapId\":2314}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/swap", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await bSwap.Swap("USDT", "BUSD", 300000m);

            result.Should().Be(responseContent);
        }

        #endregion
    }
}