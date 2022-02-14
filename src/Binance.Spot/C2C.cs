namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;

    public class C2C : SpotService
    {
        // ReSharper disable once InconsistentNaming
        private const string GET_C2C_TRADE_HISTORY = "/sapi/v1/c2c/orderMatch/listUserOrderHistory";

        public C2C(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public C2C(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     - If startTimestamp and endTimestamp are not sent, the recent 30-day data will be returned.
        ///     <para />
        ///     - The max interval between startTimestamp and endTimestamp is 30 days.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="tradeType"></param>
        /// <param name="startTimestamp">UTC timestamp in ms.</param>
        /// <param name="endTimestamp">UTC timestamp in ms.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="rows">default 100, max 100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Trades history.</returns>
        public async Task<string> GetC2CTradeHistory(
            Side tradeType,
            long? startTimestamp = null,
            long? endTimestamp = null,
            int? page = null,
            int? rows = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_C2C_TRADE_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "tradeType", tradeType },
                    { "startTimestamp", startTimestamp },
                    { "endTimestamp", endTimestamp },
                    { "page", page },
                    { "rows", rows },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }
    }
}