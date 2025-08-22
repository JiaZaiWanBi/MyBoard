using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBoard.Model;

public class ServerInfoModel
{
    public string Name { get; set; } = "";
    public string ConnectionType { get; set; } = "";

    public string Latency { get; set; } = "";

    public SolidColorBrush LatencyBrush
    {
        get
        {
            int latencyValue = 0;

            // 去掉可能的 "ms" 后缀再解析
            if (!string.IsNullOrEmpty(Latency))
            {
                var numeric = Latency.Replace("ms", "").Trim();
                int.TryParse(numeric, out latencyValue);
            }

            if (latencyValue < 100)
                return new SolidColorBrush(Colors.Green);
            else if (latencyValue <= 400)
                return new SolidColorBrush(Colors.Yellow);
            else
                return new SolidColorBrush(Colors.Red);
        }
    }
}
