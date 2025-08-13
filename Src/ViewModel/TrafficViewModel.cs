using CommunityToolkit.Mvvm.ComponentModel;
using MyBoard.Model;
using System;
using System.Text.Json;

namespace MyBoard.ViewModel
{
    public partial class TrafficViewModel : WebSocketBase
    {
        [ObservableProperty]
        private string trafficText = "等待数据...";


        public TrafficViewModel() : base("ws://127.0.0.1:9090/traffic") { }

        protected override void HandleMessage(string json)
        {
            var data = JsonSerializer.Deserialize<TrafficData>(json);
            if (data != null)
            {
                TrafficText = $"上行: {data.up} B/s, 下行: {data.down} B/s";
            }
        }

        protected override void HandleError(Exception ex)
        {
            TrafficText = "连接失败: " + ex.Message;
        }
    }
}
