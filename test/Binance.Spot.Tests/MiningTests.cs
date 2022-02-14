namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    public class MiningTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region AccountList

        [TestMethod]
        public async Task AccountList_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":[{\"type\":\"H_hashrate\",\"userName\":\"test\",\"list\":[{\"time\":1585267200000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"},{\"time\":1585353600000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"}]},{\"type\":\"D_hashrate\",\"userName\":\"test\",\"list\":[{\"time\":1587906000000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"},{\"time\":1587909600000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"}]}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/statistics/user/list", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.AccountList();

            result.Should().Be(responseContent);
        }

        #endregion

        #region AcquiringAlgorithm

        [TestMethod]
        public async Task AcquiringAlgorithm_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":[{\"algoName\":\"sha256\",\"algoId\":1,\"poolIndex\":0,\"unit\":\"h/s\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/pub/algoList", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.AcquiringAlgorithm();

            result.Should().Be(responseContent);
        }

        #endregion

        #region AcquiringCoinname

        [TestMethod]
        public async Task AcquiringCoinname_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":[{\"coinName\":\"BTC\",\"coinId\":1,\"poolIndex\":0,\"algoId\":1,\"algoName\":\"sha256\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/pub/coinList", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.AcquiringCoinname();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CancelHashrateResaleConfiguration

        [TestMethod]
        public async Task CancelHashrateResaleConfiguration_Response()
        {
            string responseContent = "{\"code\":0,\"msg\":\"\",\"data\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/hash-transfer/config/cancel", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.CancelHashrateResaleConfiguration();

            result.Should().Be(responseContent);
        }

        #endregion

        #region EarningsList

        [TestMethod]
        public async Task EarningsList_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":{\"accountProfits\":[{\"time\":1586188800000,\"type\":31,\"hashTransfer\":null,\"transferAmount\":null,\"dayHashRate\":129129903378244,\"profitAmount\":8.6083060304,\"coinName\":\"BTC\",\"status\":2},{\"time\":1607529600000,\"coinName\":\"BTC\",\"type\":0,\"dayHashRate\":9942053925926,\"profitAmount\":0.85426469,\"hashTransfer\":200000000000,\"transferAmount\":0.02180958,\"status\":2},{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":31,\"dayHashRate\":200000000000,\"profitAmount\":0.02905916,\"hashTransfer\":null,\"transferAmount\":null,\"status\":2}],\"totalNum\":3,\"pageSize\":20}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/payment/list", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.EarningsList();

            result.Should().Be(responseContent);
        }

        #endregion

        #region ExtraBonusList

        [TestMethod]
        public async Task ExtraBonusList_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":{\"otherProfits\":[{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":4,\"profitAmount\":0.0011859,\"status\":2}],\"totalNum\":3,\"pageSize\":20}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/payment/other", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.ExtraBonusList();

            result.Should().Be(responseContent);
        }

        #endregion

        #region HashrateResaleDetail

        [TestMethod]
        public async Task HashrateResaleDetail_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":{\"profitTransferDetails\":[{\"poolUsername\":\"test4001\",\"toPoolUsername\":\"pop\",\"algoName\":\"sha256\",\"hashRate\":200000000000,\"day\":20201213,\"amount\":0.2256872,\"coinName\":\"BTC\"},{\"poolUsername\":\"test4001\",\"toPoolUsername\":\"pop\",\"algoName\":\"sha256\",\"hashRate\":200000000000,\"day\":20201213,\"amount\":0.2256872,\"coinName\":\"BTC\"}],\"totalNum\":8,\"pageSize\":200}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/hash-transfer/profit/details", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.HashrateResaleDetail();

            result.Should().Be(responseContent);
        }

        #endregion

        #region HashrateResaleList

        [TestMethod]
        public async Task HashrateResaleList_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":{\"configDetails\":[{\"configId\":168,\"poolUsername\":\"123\",\"toPoolUsername\":\"user1\",\"algoName\":\"Ethash\",\"hashRate\":5000000,\"startDay\":20201210,\"endDay\":20210405,\"status\":1},{\"configId\":166,\"poolUsername\":\"pop\",\"toPoolUsername\":\"111111\",\"algoName\":\"Ethash\",\"hashRate\":3320000,\"startDay\":20201226,\"endDay\":20201227,\"status\":0}],\"totalNum\":21,\"pageSize\":200}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/hash-transfer/config/details/list", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.HashrateResaleList();

            result.Should().Be(responseContent);
        }

        #endregion

        #region HashrateResaleRequest

        [TestMethod]
        public async Task HashrateResaleRequest_Response()
        {
            string responseContent = "{\"code\":0,\"msg\":\"\",\"data\":171}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/hash-transfer/config", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.HashrateResaleRequest();

            result.Should().Be(responseContent);
        }

        #endregion

        #region MiningAccountEarning

        [TestMethod]
        public async Task MiningAccountEarning_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":{\"accountProfits\":[{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":2,\"puid\":59985472,\"subName\":\"vdvaghani\",\"amount\":0.09186957}],\"totalNum\":3,\"pageSize\":20}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/payment/uid", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.MiningAccountEarning("sha256");

            result.Should().Be(responseContent);
        }

        #endregion

        #region RequestForDetailMinerList

        [TestMethod]
        public async Task RequestForDetailMinerList_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":[{\"workerName\":\"bhdc1.16A10404B\",\"type\":\"H_hashrate\",\"hashrateDatas\":[{\"time\":1587902400000,\"hashrate\":\"0\",\"reject\":0},{\"time\":1587906000000,\"hashrate\":\"0\",\"reject\":0}]},{\"workerName\":\"bhdc1.16A10404B\",\"type\":\"D_hashrate\",\"hashrateDatas\":[{\"time\":1587902400000,\"hashrate\":\"0\",\"reject\":0},{\"time\":1587906000000,\"hashrate\":\"0\",\"reject\":0}]}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/worker/detail", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.RequestForDetailMinerList();

            result.Should().Be(responseContent);
        }

        #endregion

        #region RequestForMinerList

        [TestMethod]
        public async Task RequestForMinerList_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":{\"workerDatas\":[{\"workerId\":\"1420554439452400131\",\"workerName\":\"2X73\",\"status\":3,\"hashRate\":0,\"dayHashRate\":0,\"rejectRate\":0,\"lastShareTime\":1587712919000},{\"workerId\":\"7893926126382807951\",\"workerName\":\"AZDC1.1A10101\",\"status\":2,\"hashRate\":29711247541680,\"dayHashRate\":12697781298013.66,\"rejectRate\":0,\"lastShareTime\":1587969727000}],\"totalNum\":18530,\"pageSize\":20}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/worker/list", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.RequestForMinerList();

            result.Should().Be(responseContent);
        }

        #endregion

        #region StatisticList

        [TestMethod]
        public async Task StatisticList_Response()
        {
            string responseContent =
                "{\"code\":0,\"msg\":\"\",\"data\":{\"fifteenMinHashRate\":\"457835490067496409.00000000\",\"dayHashRate\":\"214289268068874127.65000000\",\"validNum\":0,\"invalidNum\":17562,\"profitToday\":{\"BTC\":\"0.00314332\",\"BSV\":\"56.17055953\",\"BCH\":\"106.61586001\"},\"profitYesterday\":{\"BTC\":\"0.00314332\",\"BSV\":\"56.17055953\",\"BCH\":\"106.61586001\"},\"userName\":\"test\",\"unit\":\"h/s\",\"algo\":\"sha256\"}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/statistics/user/status", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await mining.StatisticList();

            result.Should().Be(responseContent);
        }

        #endregion
    }
}