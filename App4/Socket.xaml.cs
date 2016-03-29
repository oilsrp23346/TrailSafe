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
using Windows.Networking.Sockets;
using Windows.Networking;
using Windows.Networking.Connectivity;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.Data.Json;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Socket : Page
    {
        private List<LocalHostItem> localHostItems = new List<LocalHostItem>();
        private NetworkAdapter adapter = null;
        private double latitude = 0;
        private double longitude = 0;

        public Socket()
        {
            this.InitializeComponent();
            PopulateAdapterList();
        }
        public async void tcpConnection(LocalHostItem selectedLocalHost, int port, double latitude, double longitude)
        {
            try
            {
                //Create the StreamSocket and establish a connection to the echo server.
                StreamSocket socket = new StreamSocket();

                //The server hostname that we will be establishing a connection to. We will be running the server and client locally,
                //so we will use localhost as the hostname.
                HostName serverHost = new HostName("192.168.1.1");
                adapter = selectedLocalHost.LocalHost.IPInformation.NetworkAdapter;

                //Every protocol typically has a standard port number. For example HTTP is typically 80, FTP is 20 and 21, etc.
                //For the echo server/client application we will use a random port 1337.
                string serverPort = port.ToString();
                await socket.ConnectAsync(serverHost, serverPort);//, SocketProtectionLevel., adapter);
                
                //Write data to the echo server.
                Stream streamOut = socket.OutputStream.AsStreamForWrite();
                StreamWriter writer = new StreamWriter(streamOut);
                GeoLoacation location = new GeoLoacation("130", "Send coordinate", latitude, longitude);
                string request = "{\"process-code\": \"" + location.process_code + "\",\"process-description\": \"" + location.process_description + "\",\"latitude\":" + location.latitude + ",\"longitude\":" + location.longitude + "}";
                await writer.WriteLineAsync(request);
                await writer.FlushAsync();

                //Read data from the echo server.
                Stream streamIn = socket.InputStream.AsStreamForRead();
                StreamReader reader = new StreamReader(streamIn);
                string response = await reader.ReadLineAsync();
                var messageDialog = new MessageDialog(response);
                await messageDialog.ShowAsync(); 
            }
            catch (Exception e)
            {
                var messageDialog = new MessageDialog(e.ToString());
                await messageDialog.ShowAsync();
            }
        }

        private async void SocketListener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            //Read line from the remote client.
            Stream inStream = args.Socket.InputStream.AsStreamForRead();
            StreamReader reader = new StreamReader(inStream);
            string request = await reader.ReadLineAsync();

            //Send the line back to the remote client.
            Stream outStream = args.Socket.OutputStream.AsStreamForWrite();
            StreamWriter writer = new StreamWriter(outStream);
            await writer.WriteLineAsync(request);
            await writer.FlushAsync();
        }

        private void PopulateAdapterList()
        {
            localHostItems.Clear();
            AdapterList.ItemsSource = localHostItems;
            AdapterList.DisplayMemberPath = "DisplayString";      
            foreach (HostName localHostInfo in NetworkInformation.GetHostNames())
            {
                if (localHostInfo.IPInformation != null)
                {
                    LocalHostItem adapterItem = new LocalHostItem(localHostInfo);
                    localHostItems.Add(adapterItem);
                }
            }
        }

        private void connClick(object sender, RoutedEventArgs e)
        {
            LocalHostItem selectedLocalHost = (LocalHostItem)AdapterList.SelectedItem;
            /*StreamSocketListener listener = new StreamSocketListener();
            listener.ConnectionReceived += SocketListener_ConnectionReceived;
            listener.Control.KeepAlive = false;
            try
            {
                await listener.BindEndpointAsync(selectedLocalHost.LocalHost, "22112");
            }
            catch(Exception ex)
            {
                //
            }*/
            tcpConnection(selectedLocalHost, 12345, latitude, longitude);
        }

        private async void getGPS_click(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            PopulateAdapterList();
            AdapterList.IsEnabled = true;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                     maximumAge: TimeSpan.FromMinutes(5),
                     timeout: TimeSpan.FromSeconds(10)
                    );

                //With this 2 lines of code, the app is able to write on a Text Label the Latitude and the Longitude, given by {{Icode|geoposition}}
                geolocation.Text = "GPS:" + geoposition.Coordinate.Point.Position.Latitude.ToString("0.0000") + ", " + geoposition.Coordinate.Point.Position.Longitude.ToString("0.0000");
                latitude = Math.Round(geoposition.Coordinate.Point.Position.Latitude, 4);
                longitude = Math.Round(geoposition.Coordinate.Point.Position.Longitude,4 );
            }
            //If an error is catch 2 are the main causes: the first is that you forgot to include ID_CAP_LOCATION in your app manifest. 
            //The second is that the user doesn't turned on the Location Services
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog(ex.ToString());
                await messageDialog.ShowAsync();
            }
        }

        private void enableConnection(object sender, SelectionChangedEventArgs e)
        {
            connect_btn.IsEnabled = true;
        }
    }
    public class LocalHostItem
    {
        public string DisplayString
        {
            get;
            private set;
        }

        public HostName LocalHost
        {
            get;
            private set;
        }

        public LocalHostItem(HostName localHostName)
        {
            if (localHostName == null)
            {
                throw new ArgumentNullException("localHostName");
            }

            if (localHostName.IPInformation == null)
            {
                throw new ArgumentException("Adapter information not found");
            }

            this.LocalHost = localHostName;
            this.DisplayString = "Address: " + localHostName.DisplayName +
                " Adapter: " + localHostName.IPInformation.NetworkAdapter.NetworkAdapterId;
        }
    }

    public class GeoLoacation
    {
        public string process_code { get; set; }
        public string process_description { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public GeoLoacation(string process_code, string process_description ,double latitude, double longitude)
        {
            this.process_code = process_code;
            this.process_description = process_description;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
