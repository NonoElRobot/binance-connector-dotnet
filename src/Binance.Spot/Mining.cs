namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Mining : SpotService
    {
        private const string ACQUIRING_ALGORITHM = "/sapi/v1/mining/pub/algoList";

        private const string ACQUIRING_COINNAME = "/sapi/v1/mining/pub/coinList";

        private const string REQUEST_FOR_DETAIL_MINER_LIST = "/sapi/v1/mining/worker/detail";

        private const string REQUEST_FOR_MINER_LIST = "/sapi/v1/mining/worker/list";

        private const string EARNINGS_LIST = "/sapi/v1/mining/payment/list";

        private const string EXTRA_BONUS_LIST = "/sapi/v1/mining/payment/other";

        private const string HASHRATE_RESALE_LIST = "/sapi/v1/mining/hash-transfer/config/details/list";

        private const string HASHRATE_RESALE_DETAIL = "/sapi/v1/mining/hash-transfer/profit/details";

        private const string HASHRATE_RESALE_REQUEST = "/sapi/v1/mining/hash-transfer/config";

        private const string CANCEL_HASHRATE_RESALE_CONFIGURATION = "/sapi/v1/mining/hash-transfer/config/cancel";

        private const string STATISTIC_LIST = "/sapi/v1/mining/statistics/user/status";

        private const string ACCOUNT_LIST = "/sapi/v1/mining/statistics/user/list";

        private const string MINING_ACCOUNT_EARNING = "/sapi/v1/mining/payment/uid";

        public Mining(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public Mining(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>List of mining accounts.</returns>
        public async Task<string> AccountList()
        {
            string result = await this.SendSignedAsync<string>(
                ACCOUNT_LIST,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Algorithm information.</returns>
        public async Task<string> AcquiringAlgorithm(long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                ACQUIRING_ALGORITHM,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow }, { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Coin information.</returns>
        public async Task<string> AcquiringCoinname(long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                ACQUIRING_COINNAME,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow }, { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>Success flag.</returns>
        public async Task<string> CancelHashrateResaleConfiguration()
        {
            string result = await this.SendSignedAsync<string>(
                CANCEL_HASHRATE_RESALE_CONFIGURATION,
                HttpMethod.Post);

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>List of earnings.</returns>
        public async Task<string> EarningsList()
        {
            string result = await this.SendSignedAsync<string>(
                EARNINGS_LIST,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>List of extra bonuses.</returns>
        public async Task<string> ExtraBonusList()
        {
            string result = await this.SendSignedAsync<string>(
                EXTRA_BONUS_LIST,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>List of hashrate resale details.</returns>
        public async Task<string> HashrateResaleDetail()
        {
            string result = await this.SendSignedAsync<string>(
                HASHRATE_RESALE_DETAIL,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>List of hashrate resales.</returns>
        public async Task<string> HashrateResaleList()
        {
            string result = await this.SendSignedAsync<string>(
                HASHRATE_RESALE_LIST,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>Mining Account Id.</returns>
        public async Task<string> HashrateResaleRequest()
        {
            string result = await this.SendSignedAsync<string>(
                HASHRATE_RESALE_REQUEST,
                HttpMethod.Post);

            return result;
        }

        /// <summary>
        ///     Weight(IP): 5.
        /// </summary>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="startDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="endDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="pageIndex">Page number, default is first page, start form 1.</param>
        /// <param name="pageSize">Number of pages, minimum 10, maximum 200.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Mining account earnings.</returns>
        public async Task<string> MiningAccountEarning(
            string algo,
            string startDate = null,
            string endDate = null,
            int? pageIndex = null,
            string pageSize = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                MINING_ACCOUNT_EARNING,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "algo", algo },
                    { "startDate", startDate },
                    { "endDate", endDate },
                    { "pageIndex", pageIndex },
                    { "pageSize", pageSize },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>List of workers' hashrates'.</returns>
        public async Task<string> RequestForDetailMinerList()
        {
            string result = await this.SendSignedAsync<string>(
                REQUEST_FOR_DETAIL_MINER_LIST,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>List of workers.</returns>
        public async Task<string> RequestForMinerList()
        {
            string result = await this.SendSignedAsync<string>(
                REQUEST_FOR_MINER_LIST,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Weight: 5.
        /// </summary>
        /// <returns>Mining account statistics.</returns>
        public async Task<string> StatisticList()
        {
            string result = await this.SendSignedAsync<string>(
                STATISTIC_LIST,
                HttpMethod.Get);

            return result;
        }
    }
}