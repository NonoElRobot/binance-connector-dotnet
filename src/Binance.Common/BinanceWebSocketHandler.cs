namespace Binance.Common
{
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Binance humble object for <see cref="System.Net.WebSockets.ClientWebSocket" />.
    /// </summary>
    public class BinanceWebSocketHandler : IBinanceWebSocketHandler
    {
        private readonly ClientWebSocket _webSocket;

        public BinanceWebSocketHandler(ClientWebSocket clientWebSocket)
        {
            this._webSocket = clientWebSocket;
        }

        public async Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string statusDescription,
            CancellationToken cancellationToken)
        {
            await this._webSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);
        }

        public async Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string statusDescription,
            CancellationToken cancellationToken)
        {
            await this._webSocket.CloseOutputAsync(closeStatus, statusDescription, cancellationToken);
        }

        public async Task ConnectAsync(Uri uri, CancellationToken cancellationToken)
        {
            await this._webSocket.ConnectAsync(uri, cancellationToken);
        }

        public void Dispose()
        {
            this._webSocket.Dispose();
        }

        public async Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            return await this._webSocket.ReceiveAsync(buffer, cancellationToken);
        }

        public async Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken)
        {
            await this._webSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);
        }

        public WebSocketState State => this._webSocket.State;
    }
}