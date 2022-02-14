namespace Binance.Common
{
    using System.Net.Http;
    using System.Threading;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     Binance message processing logging handler.
    ///     <para />
    ///     A middlewear to listen and log any request or response.
    /// </summary>
    public class BinanceLoggingHandler : MessageProcessingHandler
    {
        private readonly ILogger _logger;

        public BinanceLoggingHandler(ILogger logger)
            : base(new HttpClientHandler())
        {
            this._logger = logger;
        }

        public BinanceLoggingHandler(ILogger logger, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            this._logger = logger;
        }

        protected override HttpRequestMessage ProcessRequest(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            this._logger.LogInformation(request.ToString());

            if (null != request.Content)
            {
                string content = AsyncHelper.RunSync(() => request.Content.ReadAsStringAsync());
                this._logger.LogInformation(content);
            }

            return request;
        }

        protected override HttpResponseMessage ProcessResponse(
            HttpResponseMessage response,
            CancellationToken cancellationToken)
        {
            this._logger.LogInformation(response.ToString());

            if (null != response.Content)
            {
                string content = AsyncHelper.RunSync(() => response.Content.ReadAsStringAsync());
                this._logger.LogInformation(content);
            }

            return response;
        }
    }
}