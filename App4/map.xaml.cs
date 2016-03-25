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
using Windows.Storage.Streams;
using Windows.Devices.Geolocation;
using Windows.UI;
using App4.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class map : Page
    {
        RandomAccessStreamReference mapIconStreamReference;
        public map()
        {
            this.InitializeComponent();
            myMap.Loaded += MyMap_Loaded;
            mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///image/mappin.png"));
        }
        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            BasicGeoposition snCenter = new BasicGeoposition() { Latitude = 16.734522, Longitude = 102.285402 };
            Geopoint snPoint2 = new Geopoint(snCenter);
            foreach (Node no in Node.getAllNode())
            {
                BasicGeoposition snPosition = new BasicGeoposition() { Latitude = no.latitude, Longitude = no.longitude  };
                Geopoint snPoint = new Geopoint(snPosition);
                // Create a MapIcon.
                MapIcon mapIcon1 = new MapIcon();
                mapIcon1.Location = snPoint;
                mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIcon1.Title = no.node_type;
                mapIcon1.Image = mapIconStreamReference;
                mapIcon1.ZIndex = 0;
                // Add the MapIcon to the map.
                myMap.MapElements.Add(mapIcon1);
            }
            myMap.Center = snPoint2;
            myMap.ZoomLevel = 12;
            //line
            double centerLatitude = myMap.Center.Position.Latitude;
            double centerLongitude = myMap.Center.Position.Longitude;
            double centerLatitude2 = myMap.Center.Position.Latitude;
            double centerLongitude2 = myMap.Center.Position.Longitude;
            Windows.UI.Xaml.Controls.Maps.MapPolyline mapPolyline = new Windows.UI.Xaml.Controls.Maps.MapPolyline();
            mapPolyline.Path = new Geopath(new List<BasicGeoposition>() {
         new BasicGeoposition() {Latitude=centerLatitude, Longitude=centerLongitude },
         new BasicGeoposition() {Latitude=centerLatitude+0.05, Longitude=centerLongitude-0.05 },

         new BasicGeoposition() {Latitude=centerLatitude2+0.05, Longitude=centerLongitude2-0.05 },
         new BasicGeoposition() {Latitude=centerLatitude2+0.05, Longitude= centerLongitude2+0.0000005},

         new BasicGeoposition() {Latitude=centerLatitude2+0.05, Longitude=centerLongitude2-0.0000005 },
         new BasicGeoposition() {Latitude=centerLatitude2, Longitude= centerLongitude2},
                  });
            mapPolyline.StrokeColor = Colors.White;
            mapPolyline.StrokeThickness = 3;
            mapPolyline.StrokeDashed = true;
            myMap.MapElements.Add(mapPolyline);
        }

        private void MyMap_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            
            MapIcon myClickedIcon = args.MapElements.FirstOrDefault(mapIcon => mapIcon is MapIcon) as MapIcon;
            double la = myClickedIcon.Location.Position.Latitude;
            this.Frame.Navigate(typeof(menuNode), la);
            
           // foreach (Node no2 in Node.getAllNode())
           // {
           //     MessageDialog ms = new MessageDialog("ID : "+no.id + "Status : " + no.online_status); 
           // }
        }
    }
}