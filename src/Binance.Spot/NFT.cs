namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Nft : SpotService
    {
        private const string GET_NFT_TRANSACTION_HISTORY = "/sapi/v1/nft/history/transactions";

        private const string GET_NFT_DEPOSIT_HISTORY = "/sapi/v1/nft/history/deposit";

        private const string GET_NFT_WITHDRAW_HISTORY = "/sapi/v1/nft/history/withdraw";

        private const string GET_NFT_ASSET = "/sapi/v1/nft/user/getAsset";

        public Nft(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public Nft(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     Weight(UID): 3000.
        /// </summary>
        /// <param name="limit">Default 50, Max 50.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Asset Information.</returns>
        public async Task<string> GetNftAsset(int? limit = null, int? page = null, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_NFT_ASSET,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "limit", limit },
                    { "page", page },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     - The max interval between startTime and endTime is 90 days.
        ///     <para />
        ///     - If startTime and endTime are not sent, the recent 7 days' data will be returned.
        ///     <para />
        ///     Weight(UID): 3000.
        /// </summary>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 50, Max 50.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>NFT Deposit History.</returns>
        public async Task<string> GetNftDepositHistory(
            long? startTime = null,
            long? endTime = null,
            int? limit = null,
            int? page = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_NFT_DEPOSIT_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "page", page },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     - The max interval between startTime and endTime is 90 days.
        ///     <para />
        ///     - If startTime and endTime are not sent, the recent 7 days' data will be returned.
        ///     <para />
        ///     Weight(UID): 3000.
        /// </summary>
        /// <param name="orderType">0: purchase order, 1: sell order, 2: royalty income, 3: primary market order, 4: mint fee.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 50, Max 50.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>NFT Transaction History.</returns>
        public async Task<string> GetNftTransactionHistory(
            int orderType,
            long? startTime = null,
            long? endTime = null,
            int? limit = null,
            int? page = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_NFT_TRANSACTION_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "orderType", orderType },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "page", page },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     - The max interval between startTime and endTime is 90 days.
        ///     <para />
        ///     - If startTime and endTime are not sent, the recent 7 days' data will be returned.
        ///     <para />
        ///     Weight(UID): 3000.
        /// </summary>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 50, Max 50.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>NFT Withdraw History.</returns>
        public async Task<string> GetNftWithdrawHistory(
            long? startTime = null,
            long? endTime = null,
            int? limit = null,
            int? page = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_NFT_WITHDRAW_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "page", page },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }
    }
}