namespace Binance.Spot
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class UserDataStreams : SpotService
    {
        private const string CREATE_SPOT_LISTEN_KEY = "/api/v3/userDataStream";

        private const string PING_SPOT_LISTEN_KEY = "/api/v3/userDataStream";

        private const string CLOSE_SPOT_LISTEN_KEY = "/api/v3/userDataStream";

        private const string CREATE_MARGIN_LISTEN_KEY = "/sapi/v1/userDataStream";

        private const string PING_MARGIN_LISTEN_KEY = "/sapi/v1/userDataStream";

        private const string CLOSE_MARGIN_LISTEN_KEY = "/sapi/v1/userDataStream";

        private const string CREATE_ISOLATED_MARGIN_LISTEN_KEY = "/sapi/v1/userDataStream/isolated";

        private const string PING_ISOLATED_MARGIN_LISTEN_KEY = "/sapi/v1/userDataStream/isolated";

        private const string CLOSE_ISOLATED_MARGIN_LISTEN_KEY = "/sapi/v1/userDataStream/isolated";

        public UserDataStreams(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
            : this(new HttpClient(), baseUrl, apiKey, apiSecret)
        {
        }

        public UserDataStreams(
            HttpClient httpClient,
            string baseUrl = DEFAULT_SPOT_BASE_URL,
            string apiKey = null,
            string apiSecret = null)
            : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        /// <summary>
        ///     Close out a user data stream.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="listenKey">User websocket listen key.</param>
        /// <returns>OK.</returns>
        public async Task<string> CloseIsolatedMarginListenKey(string listenKey)
        {
            string result = await this.SendPublicAsync<string>(
                CLOSE_ISOLATED_MARGIN_LISTEN_KEY,
                HttpMethod.Delete,
                new Dictionary<string, object> { { "listenKey", listenKey } });

            return result;
        }

        /// <summary>
        ///     Close out a user data stream.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="listenKey">User websocket listen key.</param>
        /// <returns>OK.</returns>
        public async Task<string> CloseMarginListenKey(string listenKey)
        {
            string result = await this.SendPublicAsync<string>(
                CLOSE_MARGIN_LISTEN_KEY,
                HttpMethod.Delete,
                new Dictionary<string, object> { { "listenKey", listenKey } });

            return result;
        }

        /// <summary>
        ///     Close out a user data stream.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="listenKey">User websocket listen key.</param>
        /// <returns>OK.</returns>
        public async Task<string> CloseSpotListenKey(string listenKey)
        {
            string result = await this.SendPublicAsync<string>(
                CLOSE_SPOT_LISTEN_KEY,
                HttpMethod.Delete,
                new Dictionary<string, object> { { "listenKey", listenKey } });

            return result;
        }

        /// <summary>
        ///     Start a new user data stream.
        ///     <para />
        ///     The stream will close after 60 minutes unless a keepalive is sent. If the account has an active `listenKey`, that
        ///     `listenKey` will be returned and its validity will be extended for 60 minutes.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <returns>Isolated margin listen key.</returns>
        public async Task<string> CreateIsolatedMarginListenKey()
        {
            string result = await this.SendPublicAsync<string>(
                CREATE_ISOLATED_MARGIN_LISTEN_KEY,
                HttpMethod.Post);

            return result;
        }

        /// <summary>
        ///     Start a new user data stream.
        ///     <para />
        ///     The stream will close after 60 minutes unless a keepalive is sent. If the account has an active `listenKey`, that
        ///     `listenKey` will be returned and its validity will be extended for 60 minutes.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <returns>Margin listen key.</returns>
        public async Task<string> CreateMarginListenKey()
        {
            string result = await this.SendPublicAsync<string>(
                CREATE_MARGIN_LISTEN_KEY,
                HttpMethod.Post);

            return result;
        }

        /// <summary>
        ///     Start a new user data stream.
        ///     <para />
        ///     The stream will close after 60 minutes unless a keepalive is sent. If the account has an active `listenKey`, that
        ///     `listenKey` will be returned and its validity will be extended for 60 minutes.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <returns>Listen key.</returns>
        public async Task<string> CreateSpotListenKey()
        {
            string result = await this.SendPublicAsync<string>(
                CREATE_SPOT_LISTEN_KEY,
                HttpMethod.Post);

            return result;
        }

        /// <summary>
        ///     Keepalive a user data stream to prevent a time out. User data streams will close after 60 minutes. It's recommended
        ///     to send a ping about every 30 minutes.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="listenKey">User websocket listen key.</param>
        /// <returns>OK.</returns>
        public async Task<string> PingIsolatedMarginListenKey(string listenKey)
        {
            string result = await this.SendPublicAsync<string>(
                PING_ISOLATED_MARGIN_LISTEN_KEY,
                HttpMethod.Put,
                new Dictionary<string, object> { { "listenKey", listenKey } });

            return result;
        }

        /// <summary>
        ///     Keepalive a user data stream to prevent a time out. User data streams will close after 60 minutes. It's recommended
        ///     to send a ping about every 30 minutes.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="listenKey">User websocket listen key.</param>
        /// <returns>OK.</returns>
        public async Task<string> PingMarginListenKey(string listenKey)
        {
            string result = await this.SendPublicAsync<string>(
                PING_MARGIN_LISTEN_KEY,
                HttpMethod.Put,
                new Dictionary<string, object> { { "listenKey", listenKey } });

            return result;
        }

        /// <summary>
        ///     Keepalive a user data stream to prevent a time out. User data streams will close after 60 minutes. It's recommended
        ///     to send a ping about every 30 minutes.
        ///     <para />
        ///     Weight: 1.
        /// </summary>
        /// <param name="listenKey">User websocket listen key.</param>
        /// <returns>OK.</returns>
        public async Task<string> PingSpotListenKey(string listenKey)
        {
            string result = await this.SendPublicAsync<string>(
                PING_SPOT_LISTEN_KEY,
                HttpMethod.Put,
                new Dictionary<string, object> { { "listenKey", listenKey } });

            return result;
        }
    }
}