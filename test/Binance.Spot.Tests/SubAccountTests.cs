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

    public class SubAccountTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region AddIpListForASubaccountApiKey

        [TestMethod]
        public async Task AddIpListForASubaccountApiKey_Response()
        {
            string responseContent = "{\"ip\":\"192.168.1.20\",\"updateTime\":1636369557189,\"apiKey\":\"api-key\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.AddIpListForASubaccountApiKey("test@email", "api-key", "1.1.1.1");

            result.Should().Be(responseContent);
        }

        #endregion

        #region CreateAVirtualSubaccount

        [TestMethod]
        public async Task CreateAVirtualSubaccount_Response()
        {
            string responseContent = "{\"email\":\"addsdd_virtual@aasaixwqnoemail.com\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/virtualSubAccount", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.CreateAVirtualSubaccount();

            result.Should().Be(responseContent);
        }

        #endregion

        #region DeleteIpListForASubaccountApiKey

        [TestMethod]
        public async Task DeleteIpListForASubaccountApiKey_Response()
        {
            string responseContent =
                "{\"ipRestrict\":\"true\",\"ipList\":[\"\"],\"updateTime\":1636369557189,\"apiKey\":\"api-key\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList", HttpMethod.Delete)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.DeleteIpListForASubaccountApiKey("test@email", "api-key", "1.1.1.1");

            result.Should().Be(responseContent);
        }

        #endregion

        #region DepositAssetsIntoTheManagedSubaccount

        [TestMethod]
        public async Task DepositAssetsIntoTheManagedSubaccount_Response()
        {
            string responseContent = "{\"tranId\":66157362489}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/managed-subaccount/deposit", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.DepositAssetsIntoTheManagedSubaccount("aaa@test.com", "USDT", 522.23m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region EnableFuturesForSubaccount

        [TestMethod]
        public async Task EnableFuturesForSubaccount_Response()
        {
            string responseContent = "{\"email\":\"123@test.com\",\"isFuturesEnabled\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/enable", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.EnableFuturesForSubaccount("123@test.com");

            result.Should().Be(responseContent);
        }

        #endregion

        #region EnableLeverageTokenForSubaccount

        [TestMethod]
        public async Task EnableLeverageTokenForSubaccount_Response()
        {
            string responseContent = "{\"email\":\"123@test.com\",\"enableBvlt\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/Bvlt/enable", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.EnableLeverageTokenForSubaccount("123@test.com", true);

            result.Should().Be(responseContent);
        }

        #endregion

        #region EnableMarginForSubaccount

        [TestMethod]
        public async Task EnableMarginForSubaccount_Response()
        {
            string responseContent = "{\"email\":\"123@test.com\",\"isMarginEnabled\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/margin/enable", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.EnableMarginForSubaccount("123@test.com");

            result.Should().Be(responseContent);
        }

        #endregion

        #region EnableOrDisableIpRestrictionForASubaccountApiKey

        [TestMethod]
        public async Task EnableOrDisableIpRestrictionForASubaccountApiKey_Response()
        {
            string responseContent =
                "{\"ipRestrict\":\"true\",\"ipList\":[\"0.0.0.0\"],\"updateTime\":1636369557189,\"apiKey\":\"apikey\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/subAccountApi/ipRestriction", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result =
                await subAccount.EnableOrDisableIpRestrictionForASubaccountApiKey("test@email", "api-key", false);

            result.Should().Be(responseContent);
        }

        #endregion

        #region FuturesTransferForSubaccount

        [TestMethod]
        public async Task FuturesTransferForSubaccount_Response()
        {
            string responseContent = "{\"txnId\":\"2966662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/transfer", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.FuturesTransferForSubaccount(
                "123@test.com",
                "USDT",
                522.23m,
                FuturesTransferType.SPOT_TO_USDT_MARGINED_FUTURES);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetDetailOnSubaccountsFuturesAccount

        [TestMethod]
        public async Task GetDetailOnSubaccountsFuturesAccount_Response()
        {
            string responseContent =
                "{\"email\":\"abc@test.com\",\"asset\":\"USDT\",\"assets\":[{\"asset\":\"USDT\",\"initialMargin\":\"0.00000000\",\"maintenanceMargin\":\"0.00000000\",\"marginBalance\":\"0.88308000\",\"maxWithdrawAmount\":\"0.88308000\",\"openOrderInitialMargin\":\"0.00000000\",\"positionInitialMargin\":\"0.00000000\",\"unrealizedProfit\":\"0.00000000\",\"walletBalance\":\"0.88308000\"}],\"canDeposit\":true,\"canTrade\":true,\"canWithdraw\":true,\"feeTier\":2,\"maxWithdrawAmount\":\"0.88308000\",\"totalInitialMargin\":\"0.00000000\",\"totalMaintenanceMargin\":\"0.00000000\",\"totalMarginBalance\":\"0.88308000\",\"totalOpenOrderInitialMargin\":\"0.00000000\",\"totalPositionInitialMargin\":\"0.00000000\",\"totalUnrealizedProfit\":\"0.00000000\",\"totalWalletBalance\":\"0.88308000\",\"updateTime\":1576756674610}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/account", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetDetailOnSubaccountsFuturesAccount("123@test.com");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetDetailOnSubaccountsFuturesAccountV2

        [TestMethod]
        public async Task GetDetailOnSubaccountsFuturesAccountV2_Response()
        {
            string responseContent =
                "{\"futureAccountResp\":{\"email\":\"abc@test.com\",\"assets\":[{\"asset\":\"USDT\",\"initialMargin\":\"0.00000000\",\"maintenanceMargin\":\"0.00000000\",\"marginBalance\":\"0.88308000\",\"maxWithdrawAmount\":\"0.88308000\",\"openOrderInitialMargin\":\"0.00000000\",\"positionInitialMargin\":\"0.00000000\",\"unrealizedProfit\":\"0.00000000\",\"walletBalance\":\"0.88308000\"}],\"canDeposit\":true,\"canTrade\":true,\"canWithdraw\":true,\"feeTier\":2,\"maxWithdrawAmount\":\"0.88308000\",\"totalInitialMargin\":\"0.00000000\",\"totalMaintenanceMargin\":\"0.00000000\",\"totalMarginBalance\":\"0.88308000\",\"totalOpenOrderInitialMargin\":\"0.00000000\",\"totalPositionInitialMargin\":\"0.00000000\",\"totalUnrealizedProfit\":\"0.00000000\",\"totalWalletBalance\":\"0.88308000\",\"updateTime\":1576756674610}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/sub-account/futures/account", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetDetailOnSubaccountsFuturesAccountV2(
                "abc@test.com",
                FuturesType.USDT_MARGINED_FUTURES);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetDetailOnSubaccountsMarginAccount

        [TestMethod]
        public async Task GetDetailOnSubaccountsMarginAccount_Response()
        {
            string responseContent =
                "{\"email\":\"123@test.com\",\"marginLevel\":\"11.64405625\",\"totalAssetOfBtc\":\"6.82728457\",\"totalLiabilityOfBtc\":\"0.58633215\",\"totalNetAssetOfBtc\":\"6.24095242\",\"marginTradeCoeffVo\":{\"forceLiquidationBar\":\"1.10000000\",\"marginCallBar\":\"1.50000000\",\"normalBar\":\"2.00000000\"},\"marginUserAssetVoList\":[{\"asset\":\"BTC\",\"borrowed\":\"0.00000000\",\"free\":\"0.00499500\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00499500\"},{\"asset\":\"BNB\",\"borrowed\":\"201.66666672\",\"free\":\"2346.50000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"2144.83333328\"},{\"asset\":\"ETH\",\"borrowed\":\"0.00000000\",\"free\":\"0.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00000000\"},{\"asset\":\"USDT\",\"borrowed\":\"0.00000000\",\"free\":\"0.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00000000\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/margin/account", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetDetailOnSubaccountsMarginAccount("123@test.com");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetFuturesPositionriskOfSubaccount

        [TestMethod]
        public async Task GetFuturesPositionriskOfSubaccount_Response()
        {
            string responseContent =
                "[{\"entryPrice\":\"9975.12000\",\"leverage\":\"50\",\"maxNotional\":\"1000000\",\"liquidationPrice\":\"7963.54\",\"markPrice\":\"9973.50770517\",\"positionAmount\":\"0.010\",\"symbol\":\"BTCUSDT\",\"unrealizedProfit\":\"-0.01612295\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/positionRisk", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetFuturesPositionRiskOfSubaccount("123@test.com");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetFuturesPositionriskOfSubaccountV2

        [TestMethod]
        public async Task GetFuturesPositionriskOfSubaccountV2_Response()
        {
            string responseContent =
                "{\"futurePositionRiskVos\":[{\"entryPrice\":\"9975.12000\",\"leverage\":\"50\",\"maxNotional\":\"1000000\",\"liquidationPrice\":\"7963.54\",\"markPrice\":\"9973.50770517\",\"positionAmount\":\"0.010\",\"symbol\":\"BTCUSDT\",\"unrealizedProfit\":\"-0.01612295\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/sub-account/futures/positionRisk", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetFuturesPositionRiskOfSubaccountV2(
                "abc@test.com",
                FuturesType.USDT_MARGINED_FUTURES);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetIpRestrictionForASubaccountApiKey

        [TestMethod]
        public async Task GetIpRestrictionForASubaccountApiKey_Response()
        {
            string responseContent =
                "{\"ipRestrict\":\"true\",\"ipList\":[\"\"],\"updateTime\":1636369557189,\"apiKey\":\"api-key\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/subAccountApi/ipRestriction", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetIpRestrictionForASubaccountApiKey("test@email", "api-key");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetSubaccountDepositAddress

        [TestMethod]
        public async Task GetSubaccountDepositAddress_Response()
        {
            string responseContent =
                "{\"address\":\"TDunhSa7jkTNuKrusUTU1MUHtqXoBPKETV\",\"coin\":\"USDT\",\"tag\":\"\",\"url\":\"https://tronscan.org/#/address/TDunhSa7jkTNuKrusUTU1MUHtqXoBPKETV\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/deposit/subAddress", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetSubaccountDepositAddress("testsub@gmail.com", "USDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetSubaccountDepositHistory

        [TestMethod]
        public async Task GetSubaccountDepositHistory_Response()
        {
            string responseContent =
                "[{\"amount\":\"0.00999800\",\"coin\":\"PAXG\",\"network\":\"ETH\",\"status\":1,\"address\":\"0x788cabe9236ce061e5a892e1a59395a81fc8d62c\",\"addressTag\":\"\",\"txId\":\"0xaad4654a3234aa6118af9b4b335f5ae81c360b2394721c019b5d1e75328b09f3\",\"insertTime\":1599621997000,\"transferType\":0,\"confirmTimes\":\"12/12\"},{\"amount\":\"0.50000000\",\"coin\":\"IOTA\",\"network\":\"IOTA\",\"status\":1,\"address\":\"SIZ9VLMHWATXKV99LH99CIGFJFUMLEHGWVZVNNZXRJJVWBPHYWPPBOSDORZ9EQSHCZAMPVAPGFYQAUUV9DROOXJLNW\",\"addressTag\":\"\",\"txId\":\"ESBFVQUTPIWQNJSPXFNHNYHSQNTGKRVKPRABQWTAXCDWOAKDKYWPTVG9BGXNVNKTLEJGESAVXIKIZ9999\",\"insertTime\":1599620082000,\"transferType\":0,\"confirmTimes\":\"1/1\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/deposit/subHisrec", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetSubaccountDepositHistory("testsub@gmail.com");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetSubaccountsStatusOnMarginFutures

        [TestMethod]
        public async Task GetSubaccountsStatusOnMarginFutures_Response()
        {
            string responseContent =
                "[{\"email\":\"123@test.com\",\"isSubUserEnabled\":true,\"isUserActive\":true,\"insertTime\":1570791523523,\"isMarginEnabled\":true,\"isFutureEnabled\":true,\"mobile\":1570791523523}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/status", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetSubaccountsStatusOnMarginFutures();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetSummaryOfSubaccountsFuturesAccount

        [TestMethod]
        public async Task GetSummaryOfSubaccountsFuturesAccount_Response()
        {
            string responseContent =
                "{\"totalInitialMargin\":\"9.83137400\",\"totalMaintenanceMargin\":\"0.41568700\",\"totalMarginBalance\":\"23.03235621\",\"totalOpenOrderInitialMargin\":\"9.00000000\",\"totalPositionInitialMargin\":\"0.83137400\",\"totalUnrealizedProfit\":\"0.03219710\",\"totalWalletBalance\":\"22.15879444\",\"asset\":\"USD\",\"subAccountList\":[{\"email\":\"123@test.com\",\"totalInitialMargin\":\"9.00000000\",\"totalMaintenanceMargin\":\"0.00000000\",\"totalMarginBalance\":\"22.12659734\",\"totalOpenOrderInitialMargin\":\"9.00000000\",\"totalPositionInitialMargin\":\"0.00000000\",\"totalUnrealizedProfit\":\"0.00000000\",\"totalWalletBalance\":\"22.12659734\",\"asset\":\"USD\"},{\"email\":\"345@test.com\",\"totalInitialMargin\":\"0.83137400\",\"totalMaintenanceMargin\":\"0.41568700\",\"totalMarginBalance\":\"0.90575887\",\"totalOpenOrderInitialMargin\":\"0.00000000\",\"totalPositionInitialMargin\":\"0.83137400\",\"totalUnrealizedProfit\":\"0.03219710\",\"totalWalletBalance\":\"0.87356177\",\"asset\":\"USD\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/accountSummary", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetSummaryOfSubaccountsFuturesAccount();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetSummaryOfSubaccountsFuturesAccountV2

        [TestMethod]
        public async Task GetSummaryOfSubaccountsFuturesAccountV2_Response()
        {
            string responseContent =
                "{\"futureAccountSummaryResp\":{\"totalInitialMargin\":\"9.83137400\",\"totalMaintenanceMargin\":\"0.41568700\",\"totalMarginBalance\":\"23.03235621\",\"totalOpenOrderInitialMargin\":\"9.00000000\",\"totalPositionInitialMargin\":\"0.83137400\",\"totalUnrealizedProfit\":\"0.03219710\",\"totalWalletBalance\":\"22.15879444\",\"asset\":\"USD\",\"subAccountList\":[{\"email\":\"123@test.com\",\"totalInitialMargin\":\"9.00000000\",\"totalMaintenanceMargin\":\"0.00000000\",\"totalMarginBalance\":\"22.12659734\",\"totalOpenOrderInitialMargin\":\"9.00000000\",\"totalPositionInitialMargin\":\"0.00000000\",\"totalUnrealizedProfit\":\"0.00000000\",\"totalWalletBalance\":\"22.12659734\",\"asset\":\"USD\"},{\"email\":\"345@test.com\",\"totalInitialMargin\":\"0.83137400\",\"totalMaintenanceMargin\":\"0.41568700\",\"totalMarginBalance\":\"0.90575887\",\"totalOpenOrderInitialMargin\":\"0.00000000\",\"totalPositionInitialMargin\":\"0.83137400\",\"totalUnrealizedProfit\":\"0.03219710\",\"totalWalletBalance\":\"0.87356177\",\"asset\":\"USD\"}]}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/sub-account/futures/accountSummary", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetSummaryOfSubaccountsFuturesAccountV2(FuturesType.USDT_MARGINED_FUTURES);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetSummaryOfSubaccountsMarginAccount

        [TestMethod]
        public async Task GetSummaryOfSubaccountsMarginAccount_Response()
        {
            string responseContent =
                "{\"totalAssetOfBtc\":\"4.33333333\",\"totalLiabilityOfBtc\":\"2.11111112\",\"totalNetAssetOfBtc\":\"2.22222221\",\"subAccountList\":[{\"email\":\"123@test.com\",\"totalAssetOfBtc\":\"2.11111111\",\"totalLiabilityOfBtc\":\"1.11111111\",\"totalNetAssetOfBtc\":\"1.00000000\"},{\"email\":\"345@test.com\",\"totalAssetOfBtc\":\"2.22222222\",\"totalLiabilityOfBtc\":\"1.00000001\",\"totalNetAssetOfBtc\":\"1.22222221\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/margin/accountSummary", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.GetSummaryOfSubaccountsMarginAccount();

            result.Should().Be(responseContent);
        }

        #endregion

        #region MarginTransferForSubaccount

        [TestMethod]
        public async Task MarginTransferForSubaccount_Response()
        {
            string responseContent = "{\"txnId\":\"2966662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/margin/transfer", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.MarginTransferForSubaccount(
                "123@test.com",
                "USDT",
                522.23m,
                MarginTransferType.SPOT_TO_MARGIN);

            result.Should().Be(responseContent);
        }

        #endregion

        #region QueryManagedSubaccountAssetDetails

        [TestMethod]
        public async Task QueryManagedSubaccountAssetDetails_Response()
        {
            string responseContent =
                "[{\"coin\":\"INJ\",\"name\":\"Injective Protocol\",\"totalBalance\":\"0\",\"availableBalance\":\"0\",\"inOrder\":\"0\",\"btcValue\":\"0\"},{\"coin\":\"FILDOWN\",\"name\":\"FILDOWN\",\"totalBalance\":\"0\",\"availableBalance\":\"0\",\"inOrder\":\"0\",\"btcValue\":\"0\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/managed-subaccount/asset", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.QueryManagedSubaccountAssetDetails("123@test.com");

            result.Should().Be(responseContent);
        }

        #endregion

        #region QuerySubaccountAssets

        [TestMethod]
        public async Task QuerySubaccountAssets_Response()
        {
            string responseContent =
                "{\"balances\":[{\"asset\":\"ADA\",\"free\":10000,\"locked\":0},{\"asset\":\"BNB\",\"free\":10003,\"locked\":0},{\"asset\":\"BTC\",\"free\":11467.6399,\"locked\":0},{\"asset\":\"ETH\",\"free\":10004.995,\"locked\":0},{\"asset\":\"USDT\",\"free\":11652.14213,\"locked\":0}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v3/sub-account/assets", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.QuerySubaccountAssets("testsub@gmail.com");

            result.Should().Be(responseContent);
        }

        #endregion

        #region QuerySubaccountFuturesAssetTransferHistory

        [TestMethod]
        public async Task QuerySubaccountFuturesAssetTransferHistory_Response()
        {
            string responseContent =
                "{\"success\":true,\"futuresType\":2,\"transfers\":[{\"from\":\"aaa@test.com\",\"to\":\"bbb@test.com\",\"asset\":\"BTC\",\"qty\":\"1\",\"tranId\":11897001102,\"time\":1544433328000},{\"from\":\"bbb@test.com\",\"to\":\"ccc@test.com\",\"asset\":\"ETH\",\"qty\":\"2\",\"tranId\":11631474902,\"time\":1544433328000}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/internalTransfer", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.QuerySubaccountFuturesAssetTransferHistory(
                "aaa@test.com",
                FuturesType.USDT_MARGINED_FUTURES);

            result.Should().Be(responseContent);
        }

        #endregion

        #region QuerySubaccountList

        [TestMethod]
        public async Task QuerySubaccountList_Response()
        {
            string responseContent =
                "{\"subAccounts\":[{\"email\":\"testsub@gmail.com\",\"isFreeze\":false,\"createTime\":1544433328000},{\"email\":\"virtual@oxebmvfonoemail.com\",\"isFreeze\":false,\"createTime\":1544433328000}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/list", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.QuerySubaccountList();

            result.Should().Be(responseContent);
        }

        #endregion

        #region QuerySubaccountSpotAssetsSummary

        [TestMethod]
        public async Task QuerySubaccountSpotAssetsSummary_Response()
        {
            string responseContent =
                "{\"totalCount\":2,\"masterAccountTotalAsset\":\"0.23231201\",\"spotSubUserAssetBtcVoList\":[{\"email\":\"sub123@test.com\",\"totalAsset\":\"9999.00000000\"},{\"email\":\"test456@test.com\",\"totalAsset\":\"0.00000000\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/spotSummary", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.QuerySubaccountSpotAssetsSummary();

            result.Should().Be(responseContent);
        }

        #endregion

        #region QuerySubaccountSpotAssetTransferHistory

        [TestMethod]
        public async Task QuerySubaccountSpotAssetTransferHistory_Response()
        {
            string responseContent =
                "[{\"from\":\"aaa@test.com\",\"to\":\"bbb@test.com\",\"asset\":\"BTC\",\"qty\":\"10\",\"status\":\"SUCCESS\",\"tranId\":6489943656,\"time\":1544433328000},{\"from\":\"bbb@test.com\",\"to\":\"ccc@test.com\",\"asset\":\"ETH\",\"qty\":\"2\",\"status\":\"SUCCESS\",\"tranId\":6489938713,\"time\":1544433328000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/sub/transfer/history", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.QuerySubaccountSpotAssetTransferHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region QueryUniversalTransferHistory

        [TestMethod]
        public async Task QueryUniversalTransferHistory_Response()
        {
            string responseContent =
                "[{\"tranId\":11945860693,\"fromEmail\":\"master@test.com\",\"toEmail\":\"subaccount1@test.com\",\"asset\":\"BTC\",\"amount\":\"0.1\",\"fromAccountType\":\"SPOT\",\"toAccountType\":\"COIN_FUTURE\",\"status\":\"SUCCESS\",\"createTimeStamp\":1544433325000},{\"tranId\":11945857955,\"fromEmail\":\"master@test.com\",\"toEmail\":\"subaccount2@test.com\",\"asset\":\"ETH\",\"amount\":\"0.2\",\"fromAccountType\":\"SPOT\",\"toAccountType\":\"USDT_FUTURE\",\"status\":\"SUCCESS\",\"createTimeStamp\":1544433326000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/universalTransfer", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.QueryUniversalTransferHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region SubaccountFuturesAssetTransfer

        [TestMethod]
        public async Task SubaccountFuturesAssetTransfer_Response()
        {
            string responseContent = "{\"success\":true,\"txnId\":\"2934662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/internalTransfer", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.SubaccountFuturesAssetTransfer(
                "aaa@test.com",
                "bbb@test.com",
                FuturesType.USDT_MARGINED_FUTURES,
                "BNB",
                2.187m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region SubaccountTransferHistory

        [TestMethod]
        public async Task SubaccountTransferHistory_Response()
        {
            string responseContent =
                "[{\"counterParty\":\"master\",\"email\":\"master@test.com\",\"type\":1,\"asset\":\"BTC\",\"qty\":\"1\",\"fromAccountType\":\"SPOT\",\"toAccountType\":\"SPOT\",\"status\":\"SUCCESS\",\"tranId\":11798835829,\"time\":1544433325000},{\"counterParty\":\"subAccount\",\"email\":\"sub2@test.com\",\"type\":1,\"asset\":\"ETH\",\"qty\":\"2\",\"fromAccountType\":\"SPOT\",\"toAccountType\":\"SPOT\",\"status\":\"SUCCESS\",\"tranId\":11798829519,\"time\":1544433326000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/transfer/subUserHistory", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.SubaccountTransferHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region TransferToMaster

        [TestMethod]
        public async Task TransferToMaster_Response()
        {
            string responseContent = "{\"txnId\":\"2966662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/transfer/subToMaster", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.TransferToMaster("USDT", 522.23m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region TransferToSubaccountOfSameMaster

        [TestMethod]
        public async Task TransferToSubaccountOfSameMaster_Response()
        {
            string responseContent = "{\"txnId\":\"2966662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/transfer/subToSub", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.TransferToSubaccountOfSameMaster("123@test.com", "USDT", 522.23m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region UniversalTransfer

        [TestMethod]
        public async Task UniversalTransfer_Response()
        {
            string responseContent = "{\"tranId\":11945860693}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/universalTransfer", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.UniversalTransfer(
                UniversalTransferAccountType.SPOT,
                UniversalTransferAccountType.USDT_FUTURE,
                "USDT",
                522.23m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region WithdrawlAssetsFromTheManagedSubaccount

        [TestMethod]
        public async Task WithdrawlAssetsFromTheManagedSubaccount_Response()
        {
            string responseContent = "{\"tranId\":66157362489}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/managed-subaccount/withdraw", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await subAccount.WithdrawalAssetsFromTheManagedSubaccount("aaa@test.com", "USDT", 522.23m);

            result.Should().Be(responseContent);
        }

        #endregion
    }
}