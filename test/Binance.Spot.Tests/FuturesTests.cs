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

    public class FuturesTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region AdjustCrosscollateralLtv

        [TestMethod]
        public async Task AdjustCrosscollateralLtv_Response()
        {
            string responseContent =
                "{\"collateralCoin\":\"BUSD\",\"direction\":\"ADDITIONAL\",\"amount\":\"5.00000000\",\"time\":1583540328433}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/adjustCollateral", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.AdjustCrosscollateralLtv("BUSD", 5m, LoanDirection.ADDITIONAL);

            result.Should().Be(responseContent);
        }

        #endregion

        #region AdjustCrosscollateralLtvHistory

        [TestMethod]
        public async Task AdjustCrosscollateralLtvHistory_Response()
        {
            string responseContent =
                "{\"rows\":[{\"amount\":\".17398184\",\"collateralCoin\":\"BUSD\",\"coin\":\"USDT\",\"preCollateralRate\":\"0.87054861\",\"afterCollateralRate\":\"0.89736451\",\"direction\":\"REDUCED\",\"status\":\"COMPLETED\",\"adjustTime\":1583978243588}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/adjustCollateral/history", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.AdjustCrosscollateralLtvHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region AdjustCrosscollateralLtvV2

        [TestMethod]
        public async Task AdjustCrosscollateralLtvV2_Response()
        {
            string responseContent =
                "{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BTC\",\"direction\":\"ADDITIONAL\",\"amount\":\"5.00000000\",\"time\":1583540328433}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/adjustCollateral", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.AdjustCrosscollateralLtvV2("BUSD", "BTC", 5m, LoanDirection.ADDITIONAL);

            result.Should().Be(responseContent);
        }

        #endregion

        #region BorrowForCrosscollateral

        [TestMethod]
        public async Task BorrowForCrosscollateral_Response()
        {
            string responseContent =
                "{\"coin\":\"USDT\",\"amount\":\"4.50000000\",\"collateralCoin\":\"BUSD\",\"collateralAmount\":\"5.00000000\",\"time\":1582540328433,\"borrowId\":\"438648398970089472\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/borrow", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.BorrowForCrosscollateral("USDT", "BUSD");

            result.Should().Be(responseContent);
        }

        #endregion

        #region CalculateRateAfterAdjustCrosscollateralLtv

        [TestMethod]
        public async Task CalculateRateAfterAdjustCrosscollateralLtv_Response()
        {
            string responseContent = "{\"afterCollateralRate\":\"0.89736451\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/calcAdjustLevel", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CalculateRateAfterAdjustCrosscollateralLtv(
                "BUSD",
                1.2376m,
                LoanDirection.ADDITIONAL);

            result.Should().Be(responseContent);
        }

        #endregion

        #region CalculateRateAfterAdjustCrosscollateralLtvV2

        [TestMethod]
        public async Task CalculateRateAfterAdjustCrosscollateralLtvV2_Response()
        {
            string responseContent = "{\"afterCollateralRate\":\"0.89736451\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/calcAdjustLevel", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CalculateRateAfterAdjustCrosscollateralLtvV2(
                "BTC",
                "BUSD",
                1.2375m,
                LoanDirection.ADDITIONAL);

            result.Should().Be(responseContent);
        }

        #endregion

        #region CheckCollateralRepayLimit

        [TestMethod]
        public async Task CheckCollateralRepayLimit_Response()
        {
            string responseContent = "{\"coin\":\"USDT\",\"collateralCoin\":\"BTC\",\"max\":\"15000\",\"min\":\"15\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/collateralRepayLimit", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CheckCollateralRepayLimit("USDT", "BTC");

            result.Should().Be(responseContent);
        }

        #endregion

        #region CollateralRepaymentResult

        [TestMethod]
        public async Task CollateralRepaymentResult_Response()
        {
            string responseContent = "{\"quoteId\":\"3eece81ca2734042b2f538ea0d9cbdd3\",\"status\":\"SUCCESS\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/collateralRepayResult", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CollateralRepaymentResult("3eece81ca2734042b2f538ea0d9cbdd3");

            result.Should().Be(responseContent);
        }

        #endregion

        #region CrosscollateralBorrowHistory

        [TestMethod]
        public async Task CrosscollateralBorrowHistory_Response()
        {
            string responseContent =
                "{\"rows\":[{\"confirmedTime\":1582540328433,\"coin\":\"USDT\",\"collateralRate\":\"0.89991001\",\"leftTotal\":\"4.5\",\"leftPrincipal\":\"4.5\",\"deadline\":4736102399000,\"collateralCoin\":\"BUSD\",\"collateralAmount\":\"5.0\",\"orderStatus\":\"PENDING\",\"borrowId\":\"438648398970089472\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/borrow/history", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CrosscollateralBorrowHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CrosscollateralInformation

        [TestMethod]
        public async Task CrosscollateralInformation_Response()
        {
            string responseContent =
                "[{\"collateralCoin\":\"BUSD\",\"rate\":\"0.9\",\"marginCallCollateralRate\":\"0.95\",\"liquidationCollateralRate\":\"0.98\",\"currentCollateralRate\":\"0.87168984\",\"interestRate\":\"0.0\",\"interestGracePeriod\":\"0\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/configs", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CrosscollateralInformation();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CrosscollateralInformationV2

        [TestMethod]
        public async Task CrosscollateralInformationV2_Response()
        {
            string responseContent =
                "[{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BTC\",\"rate\":\"0.9\",\"marginCallCollateralRate\":\"0.95\",\"liquidationCollateralRate\":\"0.98\",\"currentCollateralRate\":\"0.87168984\",\"interestRate\":\"0.0\",\"interestGracePeriod\":\"0\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/configs", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CrosscollateralInformationV2();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CrosscollateralInterestHistory

        [TestMethod]
        public async Task CrosscollateralInterestHistory_Response()
        {
            string responseContent =
                "{\"rows\":[{\"collateralCoin\":\"BUSD\",\"interestCoin\":\"USDT\",\"interest\":\"2.354\",\"interestFreeLimitUsed\":\"0\",\"principalForInterest\":\"10000\",\"interestRate\":\"0.002\",\"time\":1582794387516}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/interestHistory", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CrosscollateralInterestHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CrosscollateralLiquidationHistory

        [TestMethod]
        public async Task CrosscollateralLiquidationHistory_Response()
        {
            string responseContent =
                "{\"rows\":[{\"collateralAmountForLiquidation\":\"10.12345678\",\"collateralCoin\":\"BUSD\",\"forceLiquidationStartTime\":1583978243588,\"coin\":\"USDT\",\"restCollateralAmountAfterLiquidation\":\"15.12345678\",\"restLoanAmount\":\"11.12345678\",\"status\":\"PENDING\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/liquidationHistory", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CrosscollateralLiquidationHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CrosscollateralRepaymentHistory

        [TestMethod]
        public async Task CrosscollateralRepaymentHistory_Response()
        {
            string responseContent =
                "{\"rows\":[{\"coin\":\"USDT\",\"amount\":\"1.68\",\"collateralCoin\":\"BUSD\",\"repayType\":\"NORMAL\",\"releasedCollateral\":\"1.80288889\",\"price\":\"1.001\",\"repayCollateral\":\"10010\",\"confirmedTime\":1582781327575,\"updateTime\":1582794387516,\"status\":\"PENDING\",\"repayId\":\"439659223998894080\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/repay/history", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CrosscollateralRepaymentHistory();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CrosscollateralWallet

        [TestMethod]
        public async Task CrosscollateralWallet_Response()
        {
            string responseContent =
                "{\"totalCrossCollateral\":\"5.8238577133\",\"totalBorrowed\":\"5.07000000\",\"totalInterest\":\"0.0\",\"interestFreeLimit\":\"100000\",\"asset\":\"USDT\",\"crossCollaterals\":[{\"collateralCoin\":\"BUSD\",\"locked\":\"5.82211108\",\"loanAmount\":\"5.07\",\"currentCollateralRate\":\"0.87168984\",\"interestFreeLimitUsed\":\"5.07\",\"principalForInterest\":\"0.0\",\"interest\":\"0.0\"},{\"collateralCoin\":\"BTC\",\"locked\":\"0\",\"loanAmount\":\"0\",\"currentCollateralRate\":\"0\",\"interestFreeLimitUsed\":\"0\",\"principalForInterest\":\"0.0\",\"interest\":\"0.0\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/wallet", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CrosscollateralWallet();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CrosscollateralWalletV2

        [TestMethod]
        public async Task CrosscollateralWalletV2_Response()
        {
            string responseContent =
                "{\"totalCrossCollateral\":\"5.8238577133\",\"totalBorrowed\":\"5.07000000\",\"totalInterest\":\"0.0\",\"interestFreeLimit\":\"100000\",\"asset\":\"USD\",\"crossCollaterals\":[{\"loanCoin\":\"USDT\",\"collateralCoin\":\"BUSD\",\"locked\":\"5.82211108\",\"loanAmount\":\"5.07\",\"currentCollateralRate\":\"0.87168984\",\"interestFreeLimitUsed\":\"5.07\",\"principalForInterest\":\"0.0\",\"interest\":\"0.0\"},{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BTC\",\"locked\":\"0\",\"loanAmount\":\"0\",\"currentCollateralRate\":\"0\",\"interestFreeLimitUsed\":\"0\",\"principalForInterest\":\"0.0\",\"interest\":\"0.0\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/wallet", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.CrosscollateralWalletV2();

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetCollateralRepayQuote

        [TestMethod]
        public async Task GetCollateralRepayQuote_Response()
        {
            string responseContent =
                "{\"coin\":\"USDT\",\"collateralCoin\":\"BTC\",\"amount\":\"0.00222\",\"quoteId\":\"8a03da95f0ad4fdc8067e3b6cde72423\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/collateralRepay", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.GetCollateralRepayQuote("USDT", "BTC", 0.00222m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetFutureAccountTransactionHistoryList

        [TestMethod]
        public async Task GetFutureAccountTransactionHistoryList_Response()
        {
            string responseContent =
                "{\"rows\":[{\"asset\":\"USDT\",\"tranId\":100000001,\"amount\":\"40.84624400\",\"type\":\"1\",\"timestamp\":1555056425000,\"status\":\"CONFIRMED\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/transfer", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.GetFutureAccountTransactionHistoryList("USDT", 1631318399000);

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetMaxAmountForAdjustCrosscollateralLtv

        [TestMethod]
        public async Task GetMaxAmountForAdjustCrosscollateralLtv_Response()
        {
            string responseContent = "{\"maxInAmount\":\"9.97109038\",\"maxOutAmount\":\"0.50952693\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/calcMaxAdjustAmount", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.GetMaxAmountForAdjustCrosscollateralLtv("USDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region GetMaxAmountForAdjustCrosscollateralLtvV2

        [TestMethod]
        public async Task GetMaxAmountForAdjustCrosscollateralLtvV2_Response()
        {
            string responseContent = "{\"maxInAmount\":\"9.97109038\",\"maxOutAmount\":\"0.50952693\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/calcMaxAdjustAmount", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.GetMaxAmountForAdjustCrosscollateralLtvV2("BTC", "BUSD");

            result.Should().Be(responseContent);
        }

        #endregion

        #region NewFutureAccountTransfer

        [TestMethod]
        public async Task NewFutureAccountTransfer_Response()
        {
            string responseContent = "{\"tranId\":100000001}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/transfer", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.NewFutureAccountTransfer(
                "USDT",
                522.23m,
                FuturesTransferType.SPOT_TO_USDT_MARGINED_FUTURES);

            result.Should().Be(responseContent);
        }

        #endregion

        #region RepayForCrosscollateral

        [TestMethod]
        public async Task RepayForCrosscollateral_Response()
        {
            string responseContent =
                "{\"coin\":\"USDT\",\"amount\":\"1.68\",\"collateralCoin\":\"BUSD\",\"repayId\":\"439659223998894080\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/repay", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.RepayForCrosscollateral("USDT", "BUSD", 1.68m);

            result.Should().Be(responseContent);
        }

        #endregion

        #region RepayWithCollateral

        [TestMethod]
        public async Task RepayWithCollateral_Response()
        {
            string responseContent =
                "{\"coin\":\"USDT\",\"collateralCoin\":\"BTC\",\"amount\":\"30\",\"quoteId\":\"3eece81ca2734042b2f538ea0d9cbdd3\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/collateralRepay", HttpMethod.Post)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await futures.RepayWithCollateral("3eece81ca2734042b2f538ea0d9cbdd3");

            result.Should().Be(responseContent);
        }

        #endregion
    }
}