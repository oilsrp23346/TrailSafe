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
            BasicGeoposition Center = new BasicGeoposition() { Latitude = 16.791274, Longitude = 102.275468 };
            Geopoint snCentermap = new Geopoint(Center);
            MapIcon mapIcon2 = new MapIcon();
            mapIcon2.Location = snPoint2;
            mapIcon2.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon2.Title = "Center";
            mapIcon2.Image = mapIconStreamReference;
            mapIcon2.ZIndex = 0;
            myMap.MapElements.Add(mapIcon2);
            //node 0 1 2 3
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
            
           
            myMap.Center = snCentermap;
            myMap.ZoomLevel = 12;

            //node 0 : 16.789774,102.235653
            //node 1 :16.831196,102.244084
            //node 2 :16.791274,102.275468
            //node 3 :16.764741,102.304295
            //center : 16.734522,102.285402
            //line
            double centerLatitude1 = 16.734522;double centerLongitude1 = 102.285402;
            double centerLatitude2 = 16.789774;double centerLongitude2 = 102.235653;
            double centerLatitude3 = 16.831196; double centerLongitude3 = 102.244084;
            double centerLatitude4 = 16.791274; double centerLongitude4 = 102.275468;
            double centerLatitude5 = 16.764741; double centerLongitude5 = 102.304295;

            Windows.UI.Xaml.Controls.Maps.MapPolyline mapPolyline = new Windows.UI.Xaml.Controls.Maps.MapPolyline();
            mapPolyline.Path = new Geopath(new List<BasicGeoposition>() {
         new BasicGeoposition() {Latitude=centerLatitude1, Longitude=centerLongitude1 },
         new BasicGeoposition() {Latitude=centerLatitude2, Longitude=centerLongitude2 },

         new BasicGeoposition() {Latitude=centerLatitude2, Longitude=centerLongitude2},
         new BasicGeoposition() {Latitude=centerLatitude3, Longitude= centerLongitude3},

         new BasicGeoposition() {Latitude=centerLatitude3, Longitude=centerLongitude3},
         new BasicGeoposition() {Latitude=centerLatitude4, Longitude= centerLongitude4},

         new BasicGeoposition() {Latitude=centerLatitude4, Longitude=centerLongitude4},
         new BasicGeoposition() {Latitude=centerLatitude5, Longitude= centerLongitude5},

         new BasicGeoposition() {Latitude=centerLatitude5, Longitude=centerLongitude5},
         new BasicGeoposition() {Latitude=centerLatitude1, Longitude= centerLongitude1},
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
            double lo = myClickedIcon.Location.Position.Longitude;
            // this.Frame.Navigate(typeof(menuNode), la);

            Node ndEqual = null;

            Node node = Node.getNodeByCoordinate(la, lo);

            this.Frame.Navigate(typeof(menuNode), node);

            /*

            foreach (Node nodeid in Node.getAllNode())
            {
                int id = nodeid.id;          
                this.Frame.Navigate(typeof(menuNode), la);
            }

             foreach (User user in User.getAllUser())
            {
                User[] us = User.getUserArounfNode(0);
                int id = user.id;
                string name = user.name;
                int identifier = user.identifier;
                int profilePic = user.profilePic;
                int status = user.status;
                int wristbandID = user.wristbandID;
                //Window.Current.Content = new User(id,name, identifier, profilePic, status, wristbandID);
                this.Frame.Navigate(typeof(menuNode),id);
            }

            if (la == 16.789774)
            {
                User[] userAr =  User.getUserArounfNode(0);
                this.Frame.Navigate(typeof(menuNode));
            }
            else if (la == 16.831196)
            {
                this.Frame.Navigate(typeof(menuNode));
            }
            else if (la == 16.791274)
            {
                this.Frame.Navigate(typeof(menuNode));
            }
            else if (la == 16.764741)
            {
                this.Frame.Navigate(typeof(menuNode));
            }
            */

            // foreach (Node no2 in Node.getAllNode())
            // {
            //     MessageDialog ms = new MessageDialog("ID : "+no.id + "Status : " + no.online_status); 
            // }
        }
    }
}