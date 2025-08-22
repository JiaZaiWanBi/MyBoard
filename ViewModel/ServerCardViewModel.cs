using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using System;

namespace MyBoard.ViewModel;

public partial class ServerInfoViewModel : ObservableObject
{
    [ObservableProperty]
    private string name = "";

    
    [ObservableProperty]
    private string connectionType = "";

    [ObservableProperty]
    private string latency = "";



    partial void OnLatencyChanged(string value)
    {
        // 当 latency 改变时，通知 LatencyBrush 更新
        OnPropertyChanged(nameof(LatencyBrush));
    }

    public SolidColorBrush LatencyBrush
    {
        get
        {
            int latencyValue = 0;
            if (!string.IsNullOrEmpty(latency))
            {
                var numeric = latency.Replace("ms", "").Trim();
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
