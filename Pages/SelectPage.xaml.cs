using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MyBoard.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyBoard.Pages;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class SelectPage : Page
{
    public List<ServerInfoModel> LeftServerList { get; set; } = new();
    public List<ServerInfoModel> RightServerList { get; set; } = new();

    public SelectPage()
    {
        InitializeComponent();
        OverlappedPresenter presenter = OverlappedPresenter.Create();

        presenter.IsResizable = false;

        LoadSampleServers();
    }

    private void LoadSampleServers()
    {
        var allServers = new List<ServerInfoModel>
            {
                new ServerInfoModel { Name = "Server 1", ConnectionType = "Wi-Fi", Latency = "20ms" },
                new ServerInfoModel { Name = "Server 2", ConnectionType = "Ethernet", Latency = "50ms" },
                new ServerInfoModel { Name = "Server 3", ConnectionType = "Wi-Fi", Latency = "120ms" },
                new ServerInfoModel { Name = "Server 4", ConnectionType = "5G", Latency = "35ms" },
                new ServerInfoModel { Name = "Server 5", ConnectionType = "Ethernet", Latency = "180ms" },
                new ServerInfoModel { Name = "Server 6", ConnectionType = "Wi-Fi", Latency = "290ms" },
                new ServerInfoModel { Name = "Server 7", ConnectionType = "LTE", Latency = "420ms" },
                new ServerInfoModel { Name = "Server 8", ConnectionType = "Ethernet", Latency = "80ms" },
                new ServerInfoModel { Name = "Server 9", ConnectionType = "Wi-Fi", Latency = "150ms" },
                new ServerInfoModel { Name = "Server 10", ConnectionType = "5G", Latency = "25ms" },
                new ServerInfoModel { Name = "Server 11", ConnectionType = "Ethernet", Latency = "95ms" },
                new ServerInfoModel { Name = "Server 12", ConnectionType = "Wi-Fi", Latency = "340ms" }
            };

        for (int i = 0; i < allServers.Count; i++)
        {
            if (i % 2 == 0)
            {
                LeftServerList.Add(allServers[i]);
            }
            else
            {
                RightServerList.Add(allServers[i]);
            }
        }
    }
}
