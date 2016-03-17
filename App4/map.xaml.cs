using System;
using System.Collections.Generic;
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
using Windows.UI.Popups;

using Bing.Maps;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Shapes;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class map : Page
    {
        public map()
            {
            this.InitializeComponent();
            InitializeMap();

        }

        void InitializeMap()
        {
            myMap.Center = new Location(16.785264, 102.270741); 
            myMap.ZoomLevel = 12;
            myMap.MapType = MapType.Aerial;
            myMap.Width = 800;
            myMap.Height = 800;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private async void pushpinTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Nation Center");
            await dialog.ShowAsync();
        }
        private async void pushpinTappedNode1(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("<!--Node1-->");
            await dialog.ShowAsync();
        }
        private async void pushpinTappedNode2(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("<!--Node2-->");
            await dialog.ShowAsync();
        }
        private async void pushpinTappedNode3(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("<!--Node3-->");
            await dialog.ShowAsync();
        }
        private async void pushpinTappedNode4(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("<!--Node4-->");
            await dialog.ShowAsync();
        }
    }
}