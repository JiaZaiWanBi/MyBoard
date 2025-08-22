using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using MyBoard.Model;
using MyBoard.Pages;
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
    public MainWindow()
    {
        InitializeComponent();
        OverlappedPresenter presenter = OverlappedPresenter.Create();

        presenter.IsResizable = false;
        AppWindow.SetPresenter(presenter);

        AppWindow.Resize(new Windows.Graphics.SizeInt32(1200, 800));
        AppWindow.Title = "MyBoard";

    }
    private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            contentFrame.Navigate(typeof(SettingPage));
        }
        else
        {
            var selectedItem = (NavigationViewItem)args.SelectedItem;
            string selectedItemTag = ((string)selectedItem.Tag);
            string pageName = "MyBoard.Pages." + selectedItemTag;
            Type pageType = Type.GetType(pageName);
            contentFrame.Navigate(pageType);
        }
    }

    public void Navigate(Type pageType, object targetPageArguments = null, NavigationTransitionInfo navigationTransitionInfo = null)
    {
        RootFrame.Navigate(pageType, targetPageArguments, navigationTransitionInfo);
    }
    public Frame RootFrame => contentFrame;
}
