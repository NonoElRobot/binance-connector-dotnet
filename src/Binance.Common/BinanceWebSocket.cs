namespace Binance.Common
{
    using System;
    using System.Collections.Generic;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Binance web socket wrapper.
    /// </summary>
    public class BinanceWebSocket : IDisposable
    {
        private readonly IBinanceWebSocketHandler _handler;
        private readonly List<CancellationTokenRegistration> _onMessageReceivedCancellationTokenRegistrations;
        private readonly List<Func<string, Task>> _onMessageReceivedFunctions;
        private readonly int _receiveBufferSize;
        private readonly Uri _url;
        private CancellationTokenSource _loopCancellationTokenSource;

        public BinanceWebSocket(IBinanceWebSocketHandler handler, string url, int receiveBufferSize = 8192)
        {
            this._handler = handler;
            this._url = new Uri(url);
            this._receiveBufferSize = receiveBufferSize;
            this._onMessageReceivedFunctions = new List<Func<string, Task>>();
            this._onMessageReceivedCancellationTokenRegistrations = new List<CancellationTokenRegistration>();
        }

        public void Dispose()
        {
            this.DisconnectAsync(CancellationToken.None).Wait();

            this._handler.Dispose();

            this._onMessageReceivedCancellationTokenRegistrations.ForEach(ct => ct.Dispose());

            this._loopCancellationTokenSource.Dispose();
        }

        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            if (this._handler.State != WebSocketState.Open)
            {
                this._loopCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                await this._handler.ConnectAsync(this._url, cancellationToken);
                await Task.Factory.StartNew(
                    () => this.ReceiveLoop(this._loopCancellationTokenSource.Token, this._receiveBufferSize),
                    this._loopCancellationTokenSource.Token,
                    TaskCreationOptions.LongRunning,
                    TaskScheduler.Default);
            }
        }

        public async Task DisconnectAsync(CancellationToken cancellationToken)
        {
            if (this._loopCancellationTokenSource != null)
            {
                this._loopCancellationTokenSource.Cancel();
            }

            if (this._handler.State == WebSocketState.Open)
            {
                await this._handler.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
                await this._handler.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
            }
        }

        public void OnMessageReceived(Func<string, Task> onMessageReceived, CancellationToken cancellationToken)
        {
            this._onMessageReceivedFunctions.Add(onMessageReceived);

            if (cancellationToken != CancellationToken.None)
            {
                CancellationTokenRegistration reg = cancellationToken.Register(
                    () => this._onMessageReceivedFunctions.Remove(onMessageReceived));

                this._onMessageReceivedCancellationTokenRegistrations.Add(reg);
            }
        }

        private async Task ReceiveLoop(CancellationToken cancellationToken, int receiveBufferSize = 8192)
        {
            WebSocketReceiveResult receiveResult = null;
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var buffer = new ArraySegment<byte>(new byte[receiveBufferSize]);
                    receiveResult = await this._handler.ReceiveAsync(buffer, cancellationToken);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    string content = Encoding.UTF8.GetString(buffer.ToArray());
                    this._onMessageReceivedFunctions.ForEach(omrf => omrf(content));
                }
            }
            catch (TaskCanceledException)
            {
                await this.DisconnectAsync(CancellationToken.None);
            }
        }

        public async Task SendAsync(string message, CancellationToken cancellationToken)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(message);

            await this._handler.SendAsync(
                new ArraySegment<byte>(byteArray),
                WebSocketMessageType.Text,
                true,
                cancellationToken);
        }
    }
}