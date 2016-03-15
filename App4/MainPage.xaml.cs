using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
           
            ApplicationView.PreferredLaunchViewSize = new Size(700, 1000);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            MyFrame.Navigate(typeof(Home));
            TitleTextBlock.Text = "Home";
            BackButton.Visibility = Visibility.Collapsed;
            home.IsSelected = true;

        }

        private void HambergerButton_Click(object sender, RoutedEventArgs e)
        {
            MysplitView.IsPaneOpen = !MysplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                home.IsSelected = true;
            }
        }

        private void IconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (home.IsSelected)
            {
                MyFrame.Navigate(typeof(Home));
                TitleTextBlock.Text = "Home";
                BackButton.Visibility = Visibility.Collapsed;
            }
            else if (map.IsSelected)
            {
                MyFrame.Navigate(typeof(map));
                TitleTextBlock.Text = "Map";
                BackButton.Visibility = Visibility.Visible;
            }
            else if (addTourist.IsSelected)
            {
                MyFrame.Navigate(typeof(AddInfo));
                TitleTextBlock.Text = "Add Tourist";
                BackButton.Visibility = Visibility.Visible;
            }
            else if (tourist.IsSelected)
            {
                MyFrame.Navigate(typeof(Tourist));
                TitleTextBlock.Text = "Tourist";
                BackButton.Visibility = Visibility.Visible;
            }
        }
        

    }
}
