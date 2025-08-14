using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MyBoard.Src.Model;

namespace MyBoard.Src.Component;

public sealed partial class ServerCard : UserControl
{
    private ServerInfoModel serverInfo;
    public ServerCard()
    {
        this.InitializeComponent();
    }

    public ServerInfoModel ServerInfo
    {
        get => serverInfo;
        set => serverInfo = value;
    }

    public static readonly DependencyProperty CurrentServerProperty =
        DependencyProperty.Register(
            nameof(ServerInfo),
            typeof(ServerInfoModel),
            typeof(ServerCard),
            new PropertyMetadata(null));
}
