namespace Binance.Common
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    ///     Binance exception class for any errors throw as a result of the misuse of the API or the library.
    /// </summary>
    public class BinanceClientException : BinanceHttpException
    {
        public BinanceClientException()
        {
        }

        public BinanceClientException(string message, int code)
            : base(message)
        {
            this.Code = code;
            this.Message = message;
        }

        public BinanceClientException(string message, int code, Exception innerException)
            : base(message, innerException)
        {
            this.Code = code;
            this.Message = message;
        }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public new string Message { get; protected set; }
    }
}