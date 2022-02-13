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

    public class MarketTests
    {
        private readonly string _apiKey = "api-key";
        private readonly string _apiSecret = "api-secret";

        #region CheckServerTime

        [TestMethod]
        public async Task CheckServerTime_Response()
        {
            string responseContent = "{\"serverTime\":1499827319559}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/time", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.CheckServerTime();

            result.Should().Be(responseContent);
        }

        #endregion

        #region CompressedAggregateTradesList

        [TestMethod]
        public async Task CompressedAggregateTradesList_Response()
        {
            string responseContent =
                "[{\"a\":26129,\"p\":\"0.01633102\",\"q\":\"4.70443515\",\"f\":27781,\"l\":27781,\"T\":1498793709153,\"m\":true,\"M\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/aggTrades", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.CompressedAggregateTradesList("BTCUSDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region CurrentAveragePrice

        [TestMethod]
        public async Task CurrentAveragePrice_Response()
        {
            string responseContent = "{\"mins\":5,\"price\":\"9.35751834\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/avgPrice", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.CurrentAveragePrice("BTCUSDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region ExchangeInformation

        [TestMethod]
        public async Task ExchangeInformation_Response()
        {
            string responseContent =
                "{\"timezone\":\"UTC\",\"serverTime\":1565246363776,\"rateLimits\":[{}],\"exchangeFilters\":[],\"symbols\":[{\"symbol\":\"ETHBTC\",\"status\":\"TRADING\",\"baseAsset\":\"ETH\",\"baseAssetPrecision\":8,\"quoteAsset\":\"BTC\",\"quotePrecision\":8,\"quoteAssetPrecision\":8,\"orderTypes\":[\"LIMIT\",\"LIMIT_MAKER\",\"MARKET\",\"STOP_LOSS\",\"STOP_LOSS_LIMIT\",\"TAKE_PROFIT\",\"TAKE_PROFIT_LIMIT\"],\"icebergAllowed\":true,\"ocoAllowed\":true,\"isSpotTradingAllowed\":true,\"isMarginTradingAllowed\":true,\"filters\":[],\"permissions\":[\"SPOT\",\"MARGIN\"]}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/exchangeInfo", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.ExchangeInformation();

            result.Should().Be(responseContent);
        }

        #endregion

        #region KlineCandlestickData

        [TestMethod]
        public async Task KlineCandlestickData_Response()
        {
            string responseContent =
                "[[1499040000000,\"0.01634790\",\"0.80000000\",\"0.01575800\",\"0.01577100\",\"148976.11427815\",1499644799999,\"2434.19055334\",308,\"1756.87402397\",\"28.46694368\",\"17928899.62484339\"]]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/klines", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.KlineCandlestickData("BTCUSDT", Interval.FIFTEEN_MINUTE);

            result.Should().Be(responseContent);
        }

        #endregion

        #region OldTradeLookup

        [TestMethod]
        public async Task OldTradeLookup_Response()
        {
            string responseContent =
                "[{\"id\":28457,\"price\":\"4.00000100\",\"qty\":\"12.00000000\",\"quoteQty\":\"48.000012\",\"time\":1499865549590,\"isBuyerMaker\":true,\"isBestMatch\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/historicalTrades", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.OldTradeLookup("BTCUSDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region OrderBook

        [TestMethod]
        public async Task OrderBook_Response()
        {
            string responseContent =
                "{\"lastUpdateId\":1027024,\"bids\":[[\"4.00000000\",\"431.00000000\"]],\"asks\":[[\"4.00000200\",\"12.00000000\"]]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/depth", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.OrderBook("BTCUSDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region RecentTradesList

        [TestMethod]
        public async Task RecentTradesList_Response()
        {
            string responseContent =
                "[{\"id\":28457,\"price\":\"4.00000100\",\"qty\":\"12.00000000\",\"quoteQty\":\"48.000012\",\"time\":1499865549590,\"isBuyerMaker\":true,\"isBestMatch\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/trades", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.RecentTradesList("BTCUSDT");

            result.Should().Be(responseContent);
        }

        #endregion

        #region SymbolOrderBookTicker

        [TestMethod]
        public async Task SymbolOrderBookTicker_Response()
        {
            string responseContent =
                "{\"symbol\":\"LTCBTC\",\"bidPrice\":\"4.00000000\",\"bidQty\":\"431.00000000\",\"askPrice\":\"4.00000200\",\"askQty\":\"9.00000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ticker/bookTicker", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.SymbolOrderBookTicker();

            result.Should().Be(responseContent);
        }

        #endregion

        #region SymbolPriceTicker

        [TestMethod]
        public async Task SymbolPriceTicker_Response()
        {
            string responseContent = "{\"symbol\":\"LTCBTC\",\"price\":\"4.00000200\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ticker/price", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.SymbolPriceTicker();

            result.Should().Be(responseContent);
        }

        #endregion

        #region TestConnectivity

        [TestMethod]
        public async Task TestConnectivity_Response()
        {
            string responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ping", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.TestConnectivity();

            result.Should().Be(responseContent);
        }

        #endregion

        #region TwentyFourHrTickerPriceChangeStatistics

        [TestMethod]
        public async Task TwentyFourHrTickerPriceChangeStatistics_Response()
        {
            string responseContent =
                "{\"symbol\":\"BNBBTC\",\"priceChange\":\"-94.99999800\",\"priceChangePercent\":\"-95.960\",\"weightedAvgPrice\":\"0.29628482\",\"prevClosePrice\":\"0.10002000\",\"lastPrice\":\"4.00000200\",\"lastQty\":\"200.00000000\",\"bidPrice\":\"4.00000000\",\"askPrice\":\"4.00000200\",\"openPrice\":\"99.00000000\",\"highPrice\":\"100.00000000\",\"lowPrice\":\"0.10000000\",\"volume\":\"8913.30000000\",\"quoteVolume\":\"15.30000000\",\"openTime\":1499783499040,\"closeTime\":1499869899040,\"firstId\":28385,\"lastId\":28460,\"count\":76}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ticker/24hr", HttpMethod.Get)
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, Content = new StringContent(responseContent)
                    });
            var market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this._apiKey,
                apiSecret: this._apiSecret);

            string result = await market.TwentyFourHrTickerPriceChangeStatistics();

            result.Should().Be(responseContent);
        }

        #endregion
    }
}