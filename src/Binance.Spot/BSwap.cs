namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;

    public class BSwap : SpotService
    {
        private const string LIST_ALL_SWAP_POOLS = "/sapi/v1/bswap/pools";

        private const string GET_LIQUIDITY_INFORMATION_OF_A_POOL = "/sapi/v1/bswap/liquidity";

        private const string ADD_LIQUIDITY = "/sapi/v1/bswap/liquidityAdd";

        private const string REMOVE_LIQUIDITY = "/sapi/v1/bswap/liquidityRemove";

        private const string GET_LIQUIDITY_OPERATION_RECORD = "/sapi/v1/bswap/liquidityOps";

        private const string REQUEST_QUOTE = "/sapi/v1/bswap/quote";

        private const string SWAP = "/sapi/v1/bswap/swap";

        private const string GET_SWAP_HISTORY = "/sapi/v1/bswap/swap";

        private const string POOL_CONFIGURE = "/sapi/v1/bswap/poolConfigure";

        private const string ADD_LIQUIDITY_PREVIEW = "/sapi/v1/bswap/addLiquidityPreview";

        private const string GET_UNCLAIMED_REWARDS_RECORD = "/sapi/v1/bswap/unclaimedRewards";

        private const string CLAIM_REWARDS = "/sapi/v1/bswap/claimRewards";

        private const string GET_CLAIMED_HISTORY = "/sapi/v1/bswap/claimedHistory";

        public BSwap(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public BSwap(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     Add liquidity to a pool.
        ///     <para />
        ///     Weight: 2.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="asset"></param>
        /// <param name="quantity"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Operation Id.</returns>
        public async Task<string> AddLiquidity(long poolId, string asset, decimal quantity, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                ADD_LIQUIDITY,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "asset", asset },
                    { "quantity", quantity },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Calculate expected share amount for adding liquidity in single or dual token.
        ///     <para />
        ///     Weight(IP): 150.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="type">"SINGLE" for adding a single token;"COMBINATION" for adding dual tokens.</param>
        /// <param name="quoteAsset"></param>
        /// <param name="quoteQty"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Add Liquidity Preview.</returns>
        public async Task<string> AddLiquidityPreview(
            long poolId,
            string type,
            string quoteAsset,
            decimal quoteQty,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                ADD_LIQUIDITY_PREVIEW,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "type", type },
                    { "quoteAsset", quoteAsset },
                    { "quoteQty", quoteQty },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Claim swap rewards or liquidity rewards.
        ///     <para />
        ///     .
        ///     <para />
        ///     Weight(UID): 1000.
        /// </summary>
        /// <param name="type">0: Swap rewards, 1: Liquidity rewards, default to 0.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Result of claim.</returns>
        public async Task<string> ClaimRewards(int? type = null, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                CLAIM_REWARDS,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get history of claimed rewards.
        ///     <para />
        ///     .
        ///     <para />
        ///     Weight(UID): 1000.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="assetRewards"></param>
        /// <param name="type">0: Swap rewards, 1: Liquidity rewards, default to 0.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 3, max 100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Claimed History.</returns>
        public async Task<string> GetClaimedHistory(
            long? poolId = null,
            string assetRewards = null,
            int? type = null,
            long? startTime = null,
            long? endTime = null,
            int? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_CLAIMED_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "assetRewards", assetRewards },
                    { "type", type },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get liquidity information and user share of a pool.
        ///     <para />
        ///     Weight:.
        ///     <para />
        ///     `1`  for one pool.
        ///     <para />
        ///     `10` when the poolId parameter is omitted.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Pool Liquidation information.</returns>
        public async Task<string> GetLiquidityInformationOfAPool(long? poolId = null, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_LIQUIDITY_INFORMATION_OF_A_POOL,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get liquidity operation (add/remove) records.
        ///     <para />
        ///     Weight: 2.
        /// </summary>
        /// <param name="operationId"></param>
        /// <param name="poolId"></param>
        /// <param name="operation"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Liquidity Operation Record.</returns>
        public async Task<string> GetLiquidityOperationRecord(
            long? operationId = null,
            long? poolId = null,
            LiquidityOperation? operation = null,
            long? startTime = null,
            long? endTime = null,
            long? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_LIQUIDITY_OPERATION_RECORD,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "operationId", operationId },
                    { "poolId", poolId },
                    { "operation", operation },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get swap history.
        ///     <para />
        ///     Weight: 2.
        /// </summary>
        /// <param name="swapId"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="status">0: pending for swap, 1: success, 2: failed.</param>
        /// <param name="quoteAsset"></param>
        /// <param name="baseAsset"></param>
        /// <param name="limit">default 3, max 100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Swap History.</returns>
        public async Task<string> GetSwapHistory(
            long? swapId = null,
            long? startTime = null,
            long? endTime = null,
            SwapStatus? status = null,
            string quoteAsset = null,
            string baseAsset = null,
            long? limit = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_SWAP_HISTORY,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "swapId", swapId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "status", status },
                    { "quoteAsset", quoteAsset },
                    { "baseAsset", baseAsset },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get unclaimed rewards record.
        ///     <para />
        ///     .
        ///     <para />
        ///     Weight(UID): 1000.
        /// </summary>
        /// <param name="type">0: Swap rewards, 1: Liquidity rewards, default to 0.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Unclaimed rewards record.</returns>
        public async Task<string> GetUnclaimedRewardsRecord(int? type = null, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                GET_UNCLAIMED_REWARDS_RECORD,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Get metadata about all swap pools.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <returns>List of Swap Pools.</returns>
        public async Task<string> ListAllSwapPools()
        {
            string result = await this.SendPublicAsync<string>(
                LIST_ALL_SWAP_POOLS,
                HttpMethod.Get);

            return result;
        }

        /// <summary>
        ///     Weight(IP): 150.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Pool Information.</returns>
        public async Task<string> PoolConfigure(long? poolId = null, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                POOL_CONFIGURE,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Remove liquidity from a pool, `type` include `SINGLE` and `COMBINATION`, asset is mandatory for single asset
        ///     removal.
        ///     <para />
        ///     Weight: 2.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="type">Can be `SINGLE` for single asset removal, `COMBINATION` for combination of all coins removal.</param>
        /// <param name="shareAmount"></param>
        /// <param name="asset">Mandatory for single asset removal.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Operation Id.</returns>
        public async Task<string> RemoveLiquidity(
            long poolId,
            LiquidityRemovalType type,
            decimal shareAmount,
            string[] asset = null,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                REMOVE_LIQUIDITY,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "type", type },
                    { "asset", asset },
                    { "shareAmount", shareAmount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Request a quote for swap quote asset (selling asset) for base asset (buying asset), essentially price/exchange
        ///     rates.
        ///     <para />
        ///     quoteQty is quantity of quote asset (to sell).
        ///     <para />
        ///     Please be noted the quote is for reference only, the actual price will change as the liquidity changes, it's
        ///     recommended to swap immediate after request a quote for slippage prevention.
        ///     <para />
        ///     Weight: 2.
        /// </summary>
        /// <param name="quoteAsset"></param>
        /// <param name="baseAsset"></param>
        /// <param name="quoteQty"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Quote Info.</returns>
        public async Task<string> RequestQuote(
            string quoteAsset,
            string baseAsset,
            decimal quoteQty,
            long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                REQUEST_QUOTE,
                HttpMethod.Get,
                new Dictionary<string, object>
                {
                    { "quoteAsset", quoteAsset },
                    { "baseAsset", baseAsset },
                    { "quoteQty", quoteQty },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }

        /// <summary>
        ///     Swap `quoteAsset` for `baseAsset`.
        ///     <para />
        ///     Weight: 2.
        /// </summary>
        /// <param name="quoteAsset"></param>
        /// <param name="baseAsset"></param>
        /// <param name="quoteQty"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Swap Id.</returns>
        public async Task<string> Swap(string quoteAsset, string baseAsset, decimal quoteQty, long? recvWindow = null)
        {
            string result = await this.SendSignedAsync<string>(
                SWAP,
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "quoteAsset", quoteAsset },
                    { "baseAsset", baseAsset },
                    { "quoteQty", quoteQty },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                });

            return result;
        }
    }
}