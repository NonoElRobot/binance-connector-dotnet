namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;

    public class Savings : SpotService
    {
        private const string GET_FLEXIBLE_PRODUCT_LIST = "/sapi/v1/lending/daily/product/list";

        private const string GET_LEFT_DAILY_PURCHASE_QUOTA_OF_FLEXIBLE_PRODUCT = "/sapi/v1/lending/daily/userLeftQuota";

        private const string PURCHASE_FLEXIBLE_PRODUCT = "/sapi/v1/lending/daily/purchase";

        private const string GET_LEFT_DAILY_REDEMPTION_QUOTA_OF_FLEXIBLE_PRODUCT =
            "/sapi/v1/lending/daily/userRedemptionQuota";

        private const string REDEEM_FLEXIBLE_PRODUCT = "/sapi/v1/lending/daily/redeem";

        private const string GET_FLEXIBLE_PRODUCT_POSITION = "/sapi/v1/lending/daily/token/position";

        private const string GET_FIXED_AND_ACTIVITY_PROJECT_LIST = "/sapi/v1/lending/project/list";

        private const string PURCHASE_FIXED_ACTIVITY_PROJECT = "/sapi/v1/lending/customizedFixed/purchase";

        private const string GET_FIXED_ACTIVITY_PROJECT_POSITION = "/sapi/v1/lending/project/position/list";

        private const string LENDING_ACCOUNT = "/sapi/v1/lending/union/account";

        private const string GET_PURCHASE_RECORD = "/sapi/v1/lending/union/purchaseRecord";

        private const string GET_REDEMPTION_RECORD = "/sapi/v1/lending/union/redemptionRecord";

        private const string GET_INTEREST_HISTORY = "/sapi/v1/lending/union/interestHistory";

        private const string CHANGE_FIXED_ACTIVITY_POSITION_TO_DAILY_POSITION = "/sapi/v1/lending/positionChanged";

        public Savings(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public Savings(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     - PositionId is mandatory parameter for fixed position.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="lot"></param>
        /// <param name="positionId"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Purchase information.</returns>
        public async Task<string> ChangeFixedActivityPositionToDailyPosition(
            string projectId,
            long lot,
            long? positionId = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CHANGE_FIXED_ACTIVITY_POSITION_TO_DAILY_POSITION,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "projectId", projectId },
                    { "lot", lot },
                    { "positionId", positionId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="projectId"></param>
        /// <param name="status">"ALL", "SUBSCRIBABLE", "UNSUBSCRIBABLE"; Default: 'ALL'.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of fixed project positions.</returns>
        public async Task<string> GetFixedActivityProjectPosition(
            string asset,
            string projectId = null,
            PositionStatus? status = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_FIXED_ACTIVITY_PROJECT_POSITION,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "projectId", projectId },
                    { "status", status },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="type">"ACTIVITY", "CUSTOMIZED_FIXED".</param>
        /// <param name="asset"></param>
        /// <param name="status">"ALL", "SUBSCRIBABLE", "UNSUBSCRIBABLE"; Default: 'ALL'.</param>
        /// <param name="isSortAsc">default "true".</param>
        /// <param name="sortBy">"START_TIME", "LOT_SIZE", "INTEREST_RATE", "DURATION"; default "START_TIME.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of fixed projects.</returns>
        public async Task<string> GetFixedAndActivityProjectList(
            FixedAndActivityProjectType type,
            string asset = null,
            ProductStatus? status = null,
            bool? isSortAsc = null,
            SortBy? sortBy = null,
            long? current = null,
            long? size = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_FIXED_AND_ACTIVITY_PROJECT_LIST,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "type", type },
                    { "status", status },
                    { "isSortAsc", isSortAsc },
                    { "sortBy", sortBy },
                    { "current", current },
                    { "size", size },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="status">"ALL", "SUBSCRIBABLE", "UNSUBSCRIBABLE"; Default: 'ALL'.</param>
        /// <param name="featured">"ALL", "TRUE"; Default: "ALL".</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of flexible products.</returns>
        public async Task<string> GetFlexibleProductList(
            ProductStatus? status = null,
            ProductFeatured? featured = null,
            long? current = null,
            long? size = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_FLEXIBLE_PRODUCT_LIST,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "status", status },
                    { "featured", featured },
                    { "current", current },
                    { "size", size },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of flexible product positions.</returns>
        public async Task<string> GetFlexibleProductPosition(string asset, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_FLEXIBLE_PRODUCT_POSITION,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     - The time between startTime and endTime cannot be longer than 30 days.
        ///     <para />
        ///     - If startTime and endTime are both not sent, then the last 30 days' data will be returned.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="lendingType">"DAILY" for flexible, "ACTIVITY" for activity, "CUSTOMIZED_FIXED" for fixed.</param>
        /// <param name="asset"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>History of interest.</returns>
        public async Task<string> GetInterestHistory(
            LendingType lendingType,
            string asset = null,
            long? startTime = null,
            long? endTime = null,
            long? current = null,
            long? size = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_INTEREST_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "lendingType", lendingType },
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
        ///     Weight: 1.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Daily purchase quote of flexible product left.</returns>
        public async Task<string> GetLeftDailyPurchaseQuotaOfFlexibleProduct(string productId, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_LEFT_DAILY_PURCHASE_QUOTA_OF_FLEXIBLE_PRODUCT,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "productId", productId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="type">"FAST", "NORMAL".</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Daily redemption quota of flexible product left.</returns>
        public async Task<string> GetLeftDailyRedemptionQuotaOfFlexibleProduct(
            string productId,
            RedemptionType type,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_LEFT_DAILY_REDEMPTION_QUOTA_OF_FLEXIBLE_PRODUCT,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "productId", productId },
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     - The time between startTime and endTime cannot be longer than 30 days.
        ///     <para />
        ///     - If startTime and endTime are both not sent, then the last 30 days' data will be returned.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="lendingType">"DAILY" for flexible, "ACTIVITY" for activity, "CUSTOMIZED_FIXED" for fixed.</param>
        /// <param name="asset"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of flexible or Fixed/Activity products.</returns>
        public async Task<string> GetPurchaseRecord(
            LendingType lendingType,
            string asset = null,
            long? startTime = null,
            long? endTime = null,
            long? current = null,
            long? size = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_PURCHASE_RECORD,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "lendingType", lendingType },
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
        ///     - The time between startTime and endTime cannot be longer than 30 days.
        ///     <para />
        ///     - If startTime and endTime are both not sent, then the last 30 days' data will be returned.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="lendingType">"DAILY" for flexible, "ACTIVITY" for activity, "CUSTOMIZED_FIXED" for fixed.</param>
        /// <param name="asset"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>History of Flexible or Fixed/Activity Redemptions.</returns>
        public async Task<string> GetRedemptionRecord(
            LendingType lendingType,
            string asset = null,
            long? startTime = null,
            long? endTime = null,
            long? current = null,
            long? size = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_REDEMPTION_RECORD,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "lendingType", lendingType },
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
        ///     Weight: 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Lending account.</returns>
        public async Task<string> LendingAccount(long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                LENDING_ACCOUNT,
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
        /// <param name="projectId"></param>
        /// <param name="lot"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Generated Purchase Id.</returns>
        public async Task<string> PurchaseFixedActivityProject(string projectId, long lot, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                PURCHASE_FIXED_ACTIVITY_PROJECT,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "projectId", projectId },
                    { "lot", lot },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Generated Purchase Id.</returns>
        public async Task<string> PurchaseFlexibleProduct(string productId, decimal amount, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                PURCHASE_FLEXIBLE_PRODUCT,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "productId", productId },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Weight: 1.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        /// <param name="type">"FAST", "NORMAL".</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>OK.</returns>
        public async Task<string> RedeemFlexibleProduct(
            string productId,
            decimal amount,
            RedemptionType type,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                REDEEM_FLEXIBLE_PRODUCT,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "productId", productId },
                    { "amount", amount },
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }
    }
}