using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MyBoard.Src.Component;
using MyBoard.Src.Model;
using MyBoard.Src.ViewModel;
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

namespace MyBoard;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    //public TrafficViewModel TrafficViewModel { get; set; } = new();
    //public MemoryViewModel MemoryViewModel { get; set; } = new();

    public MainWindow()
    {
        InitializeComponent();
        OverlappedPresenter presenter = OverlappedPresenter.Create();

        presenter.IsResizable = false;
        AppWindow.SetPresenter(presenter);

        AppWindow.Resize(new Windows.Graphics.SizeInt32(800, 500));
        AppWindow.Title = "MyBoard";

        var servers = new List<ServerInfoModel>
            {
                new ServerInfoModel { Name = "Server 1", ConnectionType = "Wi-Fi", Latency = "20ms" },
                new ServerInfoModel { Name = "Server 2", ConnectionType = "Ethernet", Latency = "50ms" },
                new ServerInfoModel { Name = "Server 3", ConnectionType = "Wi-Fi", Latency = "120ms" }
            };

        foreach (var server in servers)
        {
            var card = new ServerCard
            {
                ServerInfo = server
            };
            ServerPanel.Children.Add(card);
        }
    }

}
