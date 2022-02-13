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

    public class SavingsTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region ChangeFixedActivityPositionToDailyPosition

        [TestMethod]
        public async Task ChangeFixedActivityPositionToDailyPosition_Response()
        {
            string responseContent = "{\"dailyPurchaseId\":862290,\"success\":true,\"time\":1577233578000}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/positionChanged", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.ChangeFixedActivityPositionToDailyPosition("BTC001", 1);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetFixedActivityProjectPosition

        [TestMethod]
        public async Task GetFixedActivityProjectPosition_Response()
        {
            string responseContent =
                "[{\"asset\":\"USDT\",\"canTransfer\":true,\"createTimestamp\":1587010770000,\"duration\":14,\"endTime\":1588291200000,\"interest\":\"0.19950000\",\"interestRate\":\"0.05201250\",\"lot\":1,\"positionId\":51724,\"principal\":\"100.00000000\",\"projectId\":\"CUSDT14DAYSS001\",\"projectName\":\"USDT\",\"purchaseTime\":1587010771000,\"redeemDate\":\"2020-05-01\",\"startTime\":1587081600000,\"status\":\"HOLDING\",\"type\":\"CUSTOMIZED_FIXED\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/project/position/list", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetFixedActivityProjectPosition("USDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetFixedAndActivityProjectList

        [TestMethod]
        public async Task GetFixedAndActivityProjectList_Response()
        {
            string responseContent =
                "[{\"asset\":\"USDT\",\"displayPriority\":1,\"duration\":90,\"interestPerLot\":\"1.35810000\",\"interestRate\":\"0.05510000\",\"lotSize\":\"100.00000000\",\"lotsLowLimit\":1,\"lotsPurchased\":74155,\"lotsUpLimit\":80000,\"maxLotsPerUser\":2000,\"needKyc\":false,\"projectId\":\"CUSDT90DAYSS001\",\"projectName\":\"USDT\",\"status\":\"PURCHASING\",\"type\":\"CUSTOMIZED_FIXED\",\"withAreaLimitation\":false}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/project/list", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetFixedAndActivityProjectList(FixedAndActivityProjectType.ACTIVITY);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetFlexibleProductList

        [TestMethod]
        public async Task GetFlexibleProductList_Response()
        {
            string responseContent =
                "[{\"asset\":\"BTC\",\"avgAnnualInterestRate\":\"0.00250025\",\"canPurchase\":true,\"canRedeem\":true,\"dailyInterestPerThousand\":\"0.00685000\",\"featured\":true,\"minPurchaseAmount\":\"0.01000000\",\"productId\":\"BTC001\",\"purchasedAmount\":\"16.32467016\",\"status\":\"PURCHASING\",\"upLimit\":\"200.00000000\",\"upLimitPerUser\":\"5.00000000\"},{\"asset\":\"BUSD\",\"avgAnnualInterestRate\":\"0.01228590\",\"canPurchase\":true,\"canRedeem\":true,\"dailyInterestPerThousand\":\"0.03836000\",\"featured\":true,\"minPurchaseAmount\":\"0.10000000\",\"productId\":\"BUSD001\",\"purchasedAmount\":\"10.38932339\",\"status\":\"PURCHASING\",\"upLimit\":\"100000.00000000\",\"upLimitPerUser\":\"50000.00000000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/product/list", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetFlexibleProductList();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetFlexibleProductPosition

        [TestMethod]
        public async Task GetFlexibleProductPosition_Response()
        {
            string responseContent =
                "[{\"annualInterestRate\":\"0.02600000\",\"asset\":\"USDT\",\"avgAnnualInterestRate\":\"0.02599895\",\"canRedeem\":true,\"dailyInterestRate\":\"0.00007123\",\"freeAmount\":\"75.46000000\",\"freezeAmount\":\"0.00000000\",\"lockedAmount\":\"0.00000000\",\"productId\":\"USDT001\",\"productName\":\"USDT\",\"redeemingAmount\":\"0.00000000\",\"todayPurchasedAmount\":\"0.00000000\",\"totalAmount\":\"75.46000000\",\"totalInterest\":\"0.22759183\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/token/position", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetFlexibleProductPosition("USDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetInterestHistory

        [TestMethod]
        public async Task GetInterestHistory_Response()
        {
            string responseContent =
                "[{\"asset\":\"BUSD\",\"interest\":\"0.00006408\",\"lendingType\":\"DAILY\",\"productName\":\"BUSD\",\"time\":1577233578000},{\"asset\":\"USDT\",\"interest\":\"0.00687654\",\"lendingType\":\"DAILY\",\"productName\":\"USDT\",\"time\":1577233562000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/union/interestHistory", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetInterestHistory(LendingType.DAILY);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetLeftDailyPurchaseQuotaOfFlexibleProduct

        [TestMethod]
        public async Task GetLeftDailyPurchaseQuotaOfFlexibleProduct_Response()
        {
            string responseContent = "{\"asset\":\"BUSD\",\"leftQuota\":\"50000.00000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/userLeftQuota", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetLeftDailyPurchaseQuotaOfFlexibleProduct("BTC001");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetLeftDailyRedemptionQuotaOfFlexibleProduct

        [TestMethod]
        public async Task GetLeftDailyRedemptionQuotaOfFlexibleProduct_Response()
        {
            string responseContent =
                "{\"asset\":\"USDT\",\"dailyQuota\":\"10000000.00000000\",\"leftQuota\":\"0.00000000\",\"minRedemptionAmount\":\"0.10000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/userRedemptionQuota", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetLeftDailyRedemptionQuotaOfFlexibleProduct("BTC001", RedemptionType.FAST);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetPurchaseRecord

        [TestMethod]
        public async Task GetPurchaseRecord_Response()
        {
            string responseContent =
                "[{\"amount\":\"100.00000000\",\"asset\":\"USDT\",\"createTime\":1575018510000,\"lendingType\":\"DAILY\",\"productName\":\"USDT\",\"purchaseId\":26055,\"status\":\"SUCCESS\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/union/purchaseRecord", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetPurchaseRecord(LendingType.DAILY);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetRedemptionRecord

        [TestMethod]
        public async Task GetRedemptionRecord_Response()
        {
            string responseContent =
                "[{\"amount\":\"10.54000000\",\"asset\":\"USDT\",\"createTime\":1577257222000,\"principal\":\"10.54000000\",\"projectId\":\"USDT001\",\"projectName\":\"USDT\",\"status\":\"PAID\",\"type\":\"FAST\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/union/redemptionRecord", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.GetRedemptionRecord(LendingType.DAILY);

            result.Should().Be(responseContent);
        }

        #endregion

        #region LendingAccount

        [TestMethod]
        public async Task LendingAccount_Response()
        {
            string responseContent =
                "{\"positionAmountVos\":[{\"amount\":\"75.46000000\",\"amountInBTC\":\"0.01044819\",\"amountInUSDT\":\"75.46000000\",\"asset\":\"USDT\"},{\"amount\":\"1.67072036\",\"amountInBTC\":\"0.00023163\",\"amountInUSDT\":\"1.67289230\",\"asset\":\"BUSD\"}],\"totalAmountInBTC\":\"0.01067982\",\"totalAmountInUSDT\":\"77.13289230\",\"totalFixedAmountInBTC\":\"0.00000000\",\"totalFixedAmountInUSDT\":\"0.00000000\",\"totalFlexibleInBTC\":\"0.01067982\",\"totalFlexibleInUSDT\":\"77.13289230\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/union/account", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.LendingAccount();

            result.Should().Be(responseContent);
        }

        #endregion

        #region PurchaseFixedActivityProject

        [TestMethod]
        public async Task PurchaseFixedActivityProject_Response()
        {
            string responseContent = "{\"purchaseId\":\"18356\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/customizedFixed/purchase", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.PurchaseFixedActivityProject("CUSDT90DAYSS001", 1);

            result.Should().Be(responseContent);
        }

        #endregion

        #region PurchaseFlexibleProduct

        [TestMethod]
        public async Task PurchaseFlexibleProduct_Response()
        {
            string responseContent = "{\"purchaseId\":40607}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/purchase", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.PurchaseFlexibleProduct("BTC001", 1.3897m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region RedeemFlexibleProduct

        [TestMethod]
        public async Task RedeemFlexibleProduct_Response()
        {
            string responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/redeem", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await savings.RedeemFlexibleProduct("BTC001", 1.9864m, RedemptionType.FAST);

            result.Should().Be(responseContent);
        }

        #endregion
    }
}