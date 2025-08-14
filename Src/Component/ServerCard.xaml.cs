using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MyBoard.Src.Model;
using MyBoard.Src.ViewModel;

namespace MyBoard.Src.Component;

public sealed partial class ServerCard : UserControl
{

    public ServerInfoViewModel ServerInfo { get; set; } = new();
    public ServerCard()
    {
        this.InitializeComponent();
    }
}
