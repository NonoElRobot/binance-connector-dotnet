namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Bvlt : SpotService
    {
        private const string GET_Bvlt_INFO = "/sapi/v1/Bvlt/tokenInfo";

        private const string SUBSCRIBE_Bvlt = "/sapi/v1/Bvlt/subscribe";

        private const string QUERY_SUBSCRIPTION_RECORD = "/sapi/v1/Bvlt/subscribe/record";

        private const string REDEEM_Bvlt = "/sapi/v1/Bvlt/redeem";

        private const string QUERY_REDEMPTION_RECORD = "/sapi/v1/Bvlt/redeem/record";

        private const string GET_Bvlt_USER_LIMIT_INFO = "/sapi/v1/Bvlt/userLimit";

        public Bvlt(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public Bvlt(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <returns>List of token information.</returns>
        public async Task<string> GetBvltInfo(string tokenName = null)
        {
            string result = await this.SendPublicAsync<string>(
                GET_Bvlt_INFO,
                HttpMethod.Get,
                new Dictionary<string, object> { { "tokenName", tokenName } });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of token limits.</returns>
        public async Task<string> GetBvltUserLimitInfo(string tokenName = null, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_Bvlt_USER_LIMIT_INFO,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     - Only the data of the latest 90 days is available.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="id"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">default 1000, max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of redemption record.</returns>
        public async Task<string> QueryRedemptionRecord(
            string tokenName = null,
            long? id = null,
            long? startTime = null,
            long? endTime = null,
            int? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                QUERY_REDEMPTION_RECORD,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "id", id },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     - Only the data of the latest 90 days is available.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="id"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of subscription record.</returns>
        public async Task<string> QuerySubscriptionRecord(
            string tokenName = null,
            long? id = null,
            long? startTime = null,
            long? endTime = null,
            int? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                QUERY_SUBSCRIPTION_RECORD,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "id", id },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="amount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Redemption record.</returns>
        public async Task<string> RedeemBvlt(string tokenName, decimal amount, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                REDEEM_Bvlt,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="cost">Spot balance.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Subscription Info.</returns>
        public async Task<string> SubscribeBvlt(string tokenName, decimal cost, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                SUBSCRIBE_Bvlt,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "cost", cost },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }
    }
}