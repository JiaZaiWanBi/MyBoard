using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel;
using MyBoard.Src.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBoard.Src.Component;

public sealed partial class MemoryText : UserControl
{
    public MemoryViewModel ViewModel { get; set; } = new();
    public MemoryText()
    {
        this.InitializeComponent();
    }
}
