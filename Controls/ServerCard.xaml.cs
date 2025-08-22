using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MyBoard.Model;

namespace MyBoard.Controls;

public sealed partial class ServerCard : UserControl
{
    public ServerInfoModel ServerInfo
    {
        get { return (ServerInfoModel)GetValue(ServerInfoProperty); }
        set { SetValue(ServerInfoProperty, value); }
    }

    public static readonly DependencyProperty ServerInfoProperty =
        DependencyProperty.Register(nameof(ServerInfo), typeof(ServerInfoModel), typeof(ServerCard), new PropertyMetadata(null));

    public ServerCard()
    {
        this.InitializeComponent();
    }
}
