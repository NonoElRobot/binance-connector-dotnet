namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    public class CryptoLoansTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region GetCryptoLoansIncomeHistory

        [TestMethod]
        public async Task GetCryptoLoansIncomeHistory_Response()
        {
            string responseContent =
                "[{\"asset\":\"BUSD\",\"type\":\"borrowIn\",\"amount\":\"100\",\"timestamp\":1633771139847,\"tranId\":\"80423589583\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/loan/income", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var cryptoLoans = new CryptoLoans(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await cryptoLoans.GetCryptoLoansIncomeHistory("BTC");

            result.Should().Be(responseContent);
        }

        #endregion
    }
}