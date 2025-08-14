using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MyBoard.Src.ViewModel
{
    // 通用 WebSocket 基类
    public abstract class WebSocketBase : ObservableObject
    {
        private ClientWebSocket? ws;
        private readonly string _url;

        protected WebSocketBase(string url)
        {
            _url = url;
            ConnectWebSocket();
        }

        private async void ConnectWebSocket()
        {
            ws = new ClientWebSocket();
            try
            {
                await ws.ConnectAsync(new Uri(_url), CancellationToken.None);
                var buffer = new byte[1024];

                while (ws.State == WebSocketState.Open)
                {
                    var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var json = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        HandleMessage(json);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        protected abstract void HandleMessage(string json);

        protected virtual void HandleError(Exception ex)
        {
            Console.WriteLine($"WebSocket Error: {ex.Message}");
        }

        public async Task SendAsync(string message)
        {
            if (ws != null && ws.State == WebSocketState.Open)
            {
                var buffer = Encoding.UTF8.GetBytes(message);
                await ws.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
