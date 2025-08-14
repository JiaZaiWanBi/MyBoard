using CommunityToolkit.Mvvm.ComponentModel;
using MyBoard.Src.Model;
using System;
using System.Text.Json;

namespace MyBoard.Src.ViewModel
{
    public partial class MemoryViewModel : WebSocketBase
    {
        [ObservableProperty]
        private string? memoryText= "等待数据...";

        public MemoryViewModel() : base("ws://127.0.0.1:9090/memory") { }

        protected override void HandleMessage(string json)
        {
            var data = JsonSerializer.Deserialize<MemoryData>(json);
            if (data != null)
            {
                MemoryText = $"内存使用: {data.inuse} B.";
            }
        }

        protected override void HandleError(Exception ex)
        {
            MemoryText = "连接失败: " + ex.Message;
        }
    }
}
