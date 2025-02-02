namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;

    public class Fiat : SpotService
    {
        private const string GET_FIAT_DEPOSIT_WITHDRAW_HISTORY = "/sapi/v1/fiat/orders";

        private const string GET_FIAT_PAYMENTS_HISTORY = "/sapi/v1/fiat/payments";

        public Fiat(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public Fiat(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     - If beginTime and endTime are not sent, the recent 30-day data will be returned.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="transactionType">0-deposit, 1-withdraw.</param>
        /// <param name="beginTime"></param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="rows">Default 100, max 500.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>History of deposit/withdraw orders.</returns>
        public async Task<string> GetFiatDepositWithdrawHistory(
            FiatOrderTransactionType transactionType,
            long? beginTime = null,
            long? endTime = null,
            int? page = null,
            int? rows = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_FIAT_DEPOSIT_WITHDRAW_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "transactionType", transactionType },
                    { "beginTime", beginTime },
                    { "endTime", endTime },
                    { "page", page },
                    { "rows", rows },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     - If beginTime and endTime are not sent, the recent 30-day data will be returned.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="transactionType">0-deposit, 1-withdraw.</param>
        /// <param name="beginTime"></param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="rows">Default 100, max 500.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>History of fiat payments.</returns>
        public async Task<string> GetFiatPaymentsHistory(
            FiatPaymentTransactionType transactionType,
            long? beginTime = null,
            long? endTime = null,
            int? page = null,
            int? rows = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_FIAT_PAYMENTS_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "transactionType", transactionType },
                    { "beginTime", beginTime },
                    { "endTime", endTime },
                    { "page", page },
                    { "rows", rows },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }
    }
}