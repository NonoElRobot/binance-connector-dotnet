namespace Binance.Spot
{
    using System.Net.Http;
    using Common;

    public abstract class SpotService : BinanceService
    {
        protected const string DEFAULT_SPOT_BASE_URL = "https://api.binance.com";

        protected SpotService(
            HttpClient httpClient,
            string apiKey,
            string apiSecret,
            string baseUrl = DEFAULT_SPOT_BASE_URL)
            : base(httpClient, baseUrl, apiKey, apiSecret)
        {
        }
    }
}