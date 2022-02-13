namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;

    public class Futures : SpotService
    {
        private const string NEW_FUTURE_ACCOUNT_TRANSFER = "/sapi/v1/futures/transfer";

        private const string GET_FUTURE_ACCOUNT_TRANSACTION_HISTORY_LIST = "/sapi/v1/futures/transfer";

        private const string BORROW_FOR_CROSSCOLLATERAL = "/sapi/v1/futures/loan/borrow";

        private const string CROSSCOLLATERAL_BORROW_HISTORY = "/sapi/v1/futures/loan/borrow/history";

        private const string REPAY_FOR_CROSSCOLLATERAL = "/sapi/v1/futures/loan/repay";

        private const string CROSSCOLLATERAL_REPAYMENT_HISTORY = "/sapi/v1/futures/loan/repay/history";

        private const string CROSSCOLLATERAL_WALLET = "/sapi/v1/futures/loan/wallet";

        private const string CROSSCOLLATERAL_WALLET_V2 = "/sapi/v2/futures/loan/wallet";

        private const string CROSSCOLLATERAL_INFORMATION = "/sapi/v1/futures/loan/configs";

        private const string CROSSCOLLATERAL_INFORMATION_V2 = "/sapi/v2/futures/loan/configs";

        private const string CALCULATE_RATE_AFTER_ADJUST_CROSSCOLLATERAL_LTV = "/sapi/v1/futures/loan/calcAdjustLevel";

        private const string CALCULATE_RATE_AFTER_ADJUST_CROSSCOLLATERAL_LTV_V2 =
            "/sapi/v2/futures/loan/calcAdjustLevel";

        private const string GET_MAX_AMOUNT_FOR_ADJUST_CROSSCOLLATERAL_LTV =
            "/sapi/v1/futures/loan/calcMaxAdjustAmount";

        private const string GET_MAX_AMOUNT_FOR_ADJUST_CROSSCOLLATERAL_LTV_V2 =
            "/sapi/v2/futures/loan/calcMaxAdjustAmount";

        private const string ADJUST_CROSSCOLLATERAL_LTV = "/sapi/v1/futures/loan/adjustCollateral";

        private const string ADJUST_CROSSCOLLATERAL_LTV_V2 = "/sapi/v2/futures/loan/adjustCollateral";

        private const string ADJUST_CROSSCOLLATERAL_LTV_HISTORY = "/sapi/v1/futures/loan/adjustCollateral/history";

        private const string CROSSCOLLATERAL_LIQUIDATION_HISTORY = "/sapi/v1/futures/loan/liquidationHistory";

        private const string CHECK_COLLATERAL_REPAY_LIMIT = "/sapi/v1/futures/loan/collateralRepayLimit";

        private const string GET_COLLATERAL_REPAY_QUOTE = "/sapi/v1/futures/loan/collateralRepay";

        private const string REPAY_WITH_COLLATERAL = "/sapi/v1/futures/loan/collateralRepay";

        private const string COLLATERAL_REPAYMENT_RESULT = "/sapi/v1/futures/loan/collateralRepayResult";

        private const string CROSSCOLLATERAL_INTEREST_HISTORY = "/sapi/v1/futures/loan/interestHistory";

        public Futures(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public Futures(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     Adjust Cross-Collateral LTV.
        /// </summary>
        /// <param name="collateralCoin"></param>
        /// <param name="amount"></param>
        /// <param name="direction">"ADDITIONAL", "REDUCED".</param>
        /// <param name="recvWindow"></param>
        /// <returns>Adjust Cross-Collateral LTV.</returns>
        public async Task<string> AdjustCrosscollateralLtv(
            string collateralCoin,
            decimal amount,
            LoanDirection direction,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                ADJUST_CROSSCOLLATERAL_LTV,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "collateralCoin", collateralCoin },
                    { "amount", amount },
                    { "direction", direction },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Adjust Cross-Collateral LTV History.
        /// </summary>
        /// <param name="loanCoin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">default 500, max 1000.</param>
        /// <param name="recvWindow"></param>
        /// <returns>Adjust Cross-Collateral LTV History.</returns>
        public async Task<string> AdjustCrosscollateralLtvHistory(
            string loanCoin = null,
            string collateralCoin = null,
            long? startTime = null,
            long? endTime = null,
            long? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                ADJUST_CROSSCOLLATERAL_LTV_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "loanCoin", loanCoin },
                    { "collateralCoin", collateralCoin },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Adjust Cross-Collateral LTV V2.
        /// </summary>
        /// <param name="loanCoin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="amount"></param>
        /// <param name="direction">"ADDITIONAL", "REDUCED".</param>
        /// <param name="recvWindow"></param>
        /// <returns>Adjust Cross-Collateral LTV.</returns>
        public async Task<string> AdjustCrosscollateralLtvV2(
            string loanCoin,
            string collateralCoin,
            decimal amount,
            LoanDirection direction,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                ADJUST_CROSSCOLLATERAL_LTV_V2,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "loanCoin", loanCoin },
                    { "collateralCoin", collateralCoin },
                    { "amount", amount },
                    { "direction", direction },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Borrow asset for Cross-Collateral.
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="amount"></param>
        /// <param name="collateralAmount"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Borrow Transaction.</returns>
        public async Task<string> BorrowForCrosscollateral(
            string coin,
            string collateralCoin,
            decimal? amount = null,
            decimal? collateralAmount = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                BORROW_FOR_CROSSCOLLATERAL,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "amount", amount },
                    { "collateralCoin", collateralCoin },
                    { "collateralAmount", collateralAmount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Calculate Collateral Rate after adjust Cross-Collateral LTV.
        /// </summary>
        /// <param name="collateralCoin"></param>
        /// <param name="amount"></param>
        /// <param name="direction">"ADDITIONAL", "REDUCED".</param>
        /// <param name="recvWindow"></param>
        /// <returns>Collateral Rate.</returns>
        public async Task<string> CalculateRateAfterAdjustCrosscollateralLtv(
            string collateralCoin,
            decimal amount,
            LoanDirection direction,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CALCULATE_RATE_AFTER_ADJUST_CROSSCOLLATERAL_LTV,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "collateralCoin", collateralCoin },
                    { "amount", amount },
                    { "direction", direction },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Calculate Collateral Rate after adjust Cross-Collateral LTV V2.
        /// </summary>
        /// <param name="loanCoin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="amount"></param>
        /// <param name="direction">"ADDITIONAL", "REDUCED".</param>
        /// <param name="recvWindow"></param>
        /// <returns>Collateral Rate.</returns>
        public async Task<string> CalculateRateAfterAdjustCrosscollateralLtvV2(
            string loanCoin,
            string collateralCoin,
            decimal amount,
            LoanDirection direction,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CALCULATE_RATE_AFTER_ADJUST_CROSSCOLLATERAL_LTV_V2,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "loanCoin", loanCoin },
                    { "collateralCoin", collateralCoin },
                    { "amount", amount },
                    { "direction", direction },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Collateral Repay Limit.
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Collateral Repay Limit.</returns>
        public async Task<string> CheckCollateralRepayLimit(string coin, string collateralCoin, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CHECK_COLLATERAL_REPAY_LIMIT,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "collateralCoin", collateralCoin },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Check collateral repayment result.
        /// </summary>
        /// <param name="quoteId"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Collateral Repayment Result.</returns>
        public async Task<string> CollateralRepaymentResult(string quoteId, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                COLLATERAL_REPAYMENT_RESULT,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "quoteId", quoteId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Cross-Collateral Borrow History.
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">default 500, max 1000.</param>
        /// <param name="recvWindow"></param>
        /// <returns>Cross-Collateral Borrow History.</returns>
        public async Task<string> CrosscollateralBorrowHistory(
            string coin = null,
            long? startTime = null,
            long? endTime = null,
            long? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CROSSCOLLATERAL_BORROW_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Cross-Collateral Information.
        /// </summary>
        /// <param name="collateralCoin"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Cross-Collateral Information.</returns>
        public async Task<string> CrosscollateralInformation(string collateralCoin = null, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CROSSCOLLATERAL_INFORMATION,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "collateralCoin", collateralCoin },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Cross-Collateral Information V2.
        /// </summary>
        /// <param name="loanCoin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Cross-Collateral Information.</returns>
        public async Task<string> CrosscollateralInformationV2(
            string loanCoin = null,
            string collateralCoin = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CROSSCOLLATERAL_INFORMATION_V2,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "loanCoin", loanCoin },
                    { "collateralCoin", collateralCoin },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Cross-Collateral Interest History.
        /// </summary>
        /// <param name="collateralCoin"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="current">Currently querying page. Start from 1. Default:1.</param>
        /// <param name="limit">Default:500 Max:1000.</param>
        /// <param name="recvWindow"></param>
        /// <returns>Cross-Collateral Interest History.</returns>
        public async Task<string> CrosscollateralInterestHistory(
            string collateralCoin = null,
            long? startTime = null,
            long? endTime = null,
            long? current = null,
            long? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CROSSCOLLATERAL_INTEREST_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "collateralCoin", collateralCoin },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Cross-Collateral Liquidation History.
        /// </summary>
        /// <param name="loanCoin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">default 500, max 1000.</param>
        /// <param name="recvWindow"></param>
        /// <returns>Cross-Collateral Liquidation History.</returns>
        public async Task<string> CrosscollateralLiquidationHistory(
            string loanCoin = null,
            string collateralCoin = null,
            long? startTime = null,
            long? endTime = null,
            long? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CROSSCOLLATERAL_LIQUIDATION_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "loanCoin", loanCoin },
                    { "collateralCoin", collateralCoin },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Cross-Collateral Repayment History.
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">default 500, max 1000.</param>
        /// <param name="recvWindow"></param>
        /// <returns>Cross-Collateral Repayment History.</returns>
        public async Task<string> CrosscollateralRepaymentHistory(
            string coin = null,
            long? startTime = null,
            long? endTime = null,
            long? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CROSSCOLLATERAL_REPAYMENT_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Cross-Collateral Wallet.
        /// </summary>
        /// <param name="recvWindow"></param>
        /// <returns>Cross-Collateral Wallet.</returns>
        public async Task<string> CrosscollateralWallet(long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CROSSCOLLATERAL_WALLET,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow }, { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Cross-Collateral Wallet V2.
        /// </summary>
        /// <param name="recvWindow"></param>
        /// <returns>Cross-Collateral Wallet.</returns>
        public async Task<string> CrosscollateralWalletV2(long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CROSSCOLLATERAL_WALLET_V2,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow }, { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get quote before repay with collateral is mandatory, the quote will be valid within 25 seconds.
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="amount">repay amount.</param>
        /// <param name="recvWindow"></param>
        /// <returns>Collateral Repay Quote.</returns>
        public async Task<string> GetCollateralRepayQuote(
            string coin,
            string collateralCoin,
            decimal amount,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_COLLATERAL_REPAY_QUOTE,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "collateralCoin", collateralCoin },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Future Account Transaction History.
        ///     <para />
        ///     - Support query within the last 6 months only.
        ///     <para />
        ///     - If `startTime` and `endTime` not sent, return records of the last 7 days by default.
        ///     <para />
        ///     Weight(IP): 10.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="current">Currently querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="recvWindow"></param>
        /// <returns>Future Account Transaction History.</returns>
        public async Task<string> GetFutureAccountTransactionHistoryList(
            string asset,
            long startTime,
            long? endTime = null,
            long? current = null,
            long? size = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_FUTURE_ACCOUNT_TRANSACTION_HISTORY_LIST,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "size", size },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Max Amount for Adjust Cross-Collateral LTV.
        /// </summary>
        /// <param name="collateralCoin"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Max Amount for Adjust Cross-Collateral LTV.</returns>
        public async Task<string> GetMaxAmountForAdjustCrosscollateralLtv(
            string collateralCoin,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_MAX_AMOUNT_FOR_ADJUST_CROSSCOLLATERAL_LTV,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "collateralCoin", collateralCoin },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get Max Amount for Adjust Cross-Collateral LTV V2.
        /// </summary>
        /// <param name="loanCoin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Max Amount for Adjust Cross-Collateral LTV.</returns>
        public async Task<string> GetMaxAmountForAdjustCrosscollateralLtvV2(
            string loanCoin,
            string collateralCoin,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_MAX_AMOUNT_FOR_ADJUST_CROSSCOLLATERAL_LTV_V2,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "loanCoin", loanCoin },
                    { "collateralCoin", collateralCoin },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Execute transfer between spot account and futures account.
        /// </summary>
        /// <param name="asset">The asset being transferred, e.g., USDT.</param>
        /// <param name="amount">The amount to be transferred.</param>
        /// <param name="type">
        ///     1: transfer from spot account to USDT-Ⓜ futures account. 2: transfer from USDT-Ⓜ futures account to
        ///     spot account. 3: transfer from spot account to COIN-Ⓜ futures account. 4: transfer from COIN-Ⓜ futures account to
        ///     spot account.
        /// </param>
        /// <param name="recvWindow"></param>
        /// <returns>Transaction Id.</returns>
        public async Task<string> NewFutureAccountTransfer(
            string asset,
            decimal amount,
            FuturesTransferType type,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                NEW_FUTURE_ACCOUNT_TRANSFER,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "amount", amount },
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Repay Transaction.
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="collateralCoin"></param>
        /// <param name="amount"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Repay Transaction.</returns>
        public async Task<string> RepayForCrosscollateral(
            string coin,
            string collateralCoin,
            decimal amount,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                REPAY_FOR_CROSSCOLLATERAL,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "collateralCoin", collateralCoin },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Repay with collateral. Get quote before repay with collateral is mandatory, the quote will be valid within 25
        ///     seconds.
        /// </summary>
        /// <param name="quoteId"></param>
        /// <param name="recvWindow"></param>
        /// <returns>Transaction.</returns>
        public async Task<string> RepayWithCollateral(string quoteId, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                REPAY_WITH_COLLATERAL,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "quoteId", quoteId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }
    }
}