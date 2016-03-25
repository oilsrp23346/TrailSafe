using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App4.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HambergerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (home.IsSelected) {
                MyFrame.Navigate(typeof(Tourist));
                TitleTextBlock.Text = "Tourist";
            }
            else if (node.IsSelected)
            {
                MyFrame.Navigate(typeof(ShowNode));
                TitleTextBlock.Text = "Node Information";
            }
            else if (addTourist.IsSelected) {
                MyFrame.Navigate(typeof(AddInfo));
                TitleTextBlock.Text = "Tourist Information";
            }
            else if (map.IsSelected)
            {
                MyFrame.Navigate(typeof(map));
                TitleTextBlock.Text = "Map";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            home.IsSelected = true;
        }
    }
}
