namespace Binance.Spot
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;

    public class Market : SpotService
    {
        private const string TEST_CONNECTIVITY = "/api/v3/ping";

        private const string CHECK_SERVER_TIME = "/api/v3/time";

        private const string EXCHANGE_INFORMATION = "/api/v3/exchangeInfo";

        private const string ORDER_BOOK = "/api/v3/depth";

        private const string RECENT_TRADES_LIST = "/api/v3/trades";

        private const string OLD_TRADE_LOOKUP = "/api/v3/historicalTrades";

        private const string COMPRESSED_AGGREGATE_TRADES_LIST = "/api/v3/aggTrades";

        private const string KLINE_CANDLESTICK_DATA = "/api/v3/klines";

        private const string CURRENT_AVERAGE_PRICE = "/api/v3/avgPrice";

        private const string TWENTY_FOUR_HR_TICKER_PRICE_CHANGE_STATISTICS = "/api/v3/ticker/24hr";

        private const string SYMBOL_PRICE_TICKER = "/api/v3/ticker/price";

        private const string SYMBOL_ORDER_BOOK_TICKER = "/api/v3/ticker/bookTicker";

        public Market(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public Market(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     Test connectivity to the Rest API and get the current server time.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <returns>Binance server UTC timestamp.</returns>
        public async Task<string> CheckServerTime()
        {
            string result = await this.SendPublicAsync<string>(
                CHECK_SERVER_TIME,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Get compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have
        ///     the quantity aggregated.
        ///     <para />
        ///     - If `startTime` and `endTime` are sent, time between startTime and endTime must be less than 1 hour.
        ///     <para />
        ///     - If `fromId`, `startTime`, and `endTime` are not sent, the most recent aggregate trades will be returned.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="fromId">Trade id to fetch from. Default gets most recent trades.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns>Trade list.</returns>
        public async Task<string> CompressedAggregateTradesList(
            string symbol,
            long? fromId = null,
            long? startTime = null,
            long? endTime = null,
            int? limit = null)
        {
            string result = await this.SendPublicAsync<string>(
                COMPRESSED_AGGREGATE_TRADES_LIST,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "fromId", fromId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit }
                });

            return result;
        }

        /// <summary>
        ///     Current average price for a symbol.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <returns>Average price.</returns>
        public async Task<string> CurrentAveragePrice(string symbol)
        {
            string result = await this.SendPublicAsync<string>(
                CURRENT_AVERAGE_PRICE,
                HttpMethod.Get,
                new Dictionary<string, object> { { "symbol", symbol } });

            return result;
        }

        /// <summary>
        ///     Current exchange trading rules and symbol information.
        ///     <para />
        ///     - If any symbol provided in either symbol or symbols do not exist, the endpoint will throw an error.
        ///     <para />
        ///     Weight: 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols">Trading symbols, e.g. ["BTCUSDT","BNBBTC"].</param>
        /// <returns>Current exchange trading rules and symbol information.</returns>
        public async Task<string> ExchangeInformation(string symbol = null, string symbols = null)
        {
            string result = await this.SendPublicAsync<string>(
                EXCHANGE_INFORMATION,
                HttpMethod.Get,
                new Dictionary<string, object> { { "symbol", symbol }, { "symbols", symbols } });

            return result;
        }

        /// <summary>
        ///     Kline/candlestick bars for a symbol..
        ///     <para />
        ///     Klines are uniquely identified by their open time.
        ///     <para />
        ///     - If `startTime` and `endTime` are not sent, the most recent klines are returned.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="interval">kline intervals.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns>Kline data.</returns>
        public async Task<string> KlineCandlestickData(
            string symbol,
            Interval interval,
            long? startTime = null,
            long? endTime = null,
            int? limit = null)
        {
            string result = await this.SendPublicAsync<string>(
                KLINE_CANDLESTICK_DATA,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "interval", interval },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit }
                });

            return result;
        }

        /// <summary>
        ///     Get older market trades.
        ///     <para />
        ///     Weight: 5.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="fromId">Trade id to fetch from. Default gets most recent trades.</param>
        /// <returns>Trade list.</returns>
        public async Task<string> OldTradeLookup(string symbol, int? limit = null, long? fromId = null)
        {
            string result = await this.SendPublicAsync<string>(
                OLD_TRADE_LOOKUP,
                HttpMethod.Get,
                new Dictionary<string, object> { { "symbol", symbol }, { "limit", limit }, { "fromId", fromId } });

            return result;
        }

        /// <summary>
        ///     | Limit               | Weight  |.
        ///     <para />
        ///     | -------------       |---------|.
        ///     <para />
        ///     | 5, 10, 20, 50, 100  | 1       |.
        ///     <para />
        ///     | 500                 | 5       |.
        ///     <para />
        ///     | 1000                | 10      |.
        ///     <para />
        ///     | 5000                | 50      |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="limit"></param>
        /// <returns>Order book.</returns>
        public async Task<string> OrderBook(string symbol, int? limit = null)
        {
            string result = await this.SendPublicAsync<string>(
                ORDER_BOOK,
                HttpMethod.Get,
                new Dictionary<string, object> { { "symbol", symbol }, { "limit", limit } });

            return result;
        }

        /// <summary>
        ///     Get recent trades.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns>Trade list.</returns>
        public async Task<string> RecentTradesList(string symbol, int? limit = null)
        {
            string result = await this.SendPublicAsync<string>(
                RECENT_TRADES_LIST,
                HttpMethod.Get,
                new Dictionary<string, object> { { "symbol", symbol }, { "limit", limit } });

            return result;
        }

        /// <summary>
        ///     Best price/qty on the order book for a symbol or symbols.
        ///     <para />
        ///     - If the symbol is not sent, bookTickers for all symbols will be returned in an array.
        ///     <para />
        ///     Weight:.
        ///     <para />
        ///     1 for a single symbol;.
        ///     <para />
        ///     2 when the symbol parameter is omitted.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <returns>Order book ticker.</returns>
        public async Task<string> SymbolOrderBookTicker(string symbol = null)
        {
            string result = await this.SendPublicAsync<string>(
                SYMBOL_ORDER_BOOK_TICKER,
                HttpMethod.Get,
                new Dictionary<string, object> { { "symbol", symbol } });

            return result;
        }

        /// <summary>
        ///     Latest price for a symbol or symbols.
        ///     <para />
        ///     - If the symbol is not sent, prices for all symbols will be returned in an array.
        ///     <para />
        ///     Weight:.
        ///     <para />
        ///     `1` for a single symbol;.
        ///     <para />
        ///     `2` when the symbol parameter is omitted.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <returns>Price ticker.</returns>
        public async Task<string> SymbolPriceTicker(string symbol = null)
        {
            string result = await this.SendPublicAsync<string>(
                SYMBOL_PRICE_TICKER,
                HttpMethod.Get,
                new Dictionary<string, object> { { "symbol", symbol } });

            return result;
        }

        /// <summary>
        ///     Test connectivity to the Rest API.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <returns>OK.</returns>
        public async Task<string> TestConnectivity()
        {
            string result = await this.SendPublicAsync<string>(
                TEST_CONNECTIVITY,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     24 hour rolling window price change statistics. Careful when accessing this with no symbol.
        ///     <para />
        ///     - If the symbol is not sent, tickers for all symbols will be returned in an array.
        ///     <para />
        ///     Weight:.
        ///     <para />
        ///     `1` for a single symbol;.
        ///     <para />
        ///     `40` when the symbol parameter is omitted.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <returns>24hr ticker.</returns>
        public async Task<string> TwentyFourHrTickerPriceChangeStatistics(string symbol = null)
        {
            string result = await this.SendPublicAsync<string>(
                TWENTY_FOUR_HR_TICKER_PRICE_CHANGE_STATISTICS,
                HttpMethod.Get,
                new Dictionary<string, object> { { "symbol", symbol } });

            return result;
        }
    }
}