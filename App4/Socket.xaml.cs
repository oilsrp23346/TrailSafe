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

        public Socket()
        {
            this.InitializeComponent();
            PopulateAdapterList();
        }
        public async void tcpConnection(LocalHostItem selectedLocalHost)
        {
            try
            {
                //Create the StreamSocket and establish a connection to the echo server.
                StreamSocket socket = new StreamSocket();

                //The server hostname that we will be establishing a connection to. We will be running the server and client locally,
                //so we will use localhost as the hostname.
                HostName serverHost = selectedLocalHost.LocalHost;
                adapter = selectedLocalHost.LocalHost.IPInformation.NetworkAdapter;

                //Every protocol typically has a standard port number. For example HTTP is typically 80, FTP is 20 and 21, etc.
                //For the echo server/client application we will use a random port 1337.
                string serverPort = "22112";
                await socket.ConnectAsync(serverHost, serverPort, SocketProtectionLevel.PlainSocket,adapter);

                //Write data to the echo server.
                Stream streamOut = socket.OutputStream.AsStreamForWrite();
                StreamWriter writer = new StreamWriter(streamOut);
                string request = "hello";
                await writer.WriteLineAsync(request);
                await writer.FlushAsync();

                //Read data from the echo server.
                Stream streamIn = socket.InputStream.AsStreamForRead();
                StreamReader reader = new StreamReader(streamIn);
                string response = await reader.ReadLineAsync();
                responseTxt.Text = response;
            }
            catch (Exception e)
            {
                //Handle exception here.            
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

        private async void connClick(object sender, RoutedEventArgs e)
        {
            LocalHostItem selectedLocalHost = (LocalHostItem)AdapterList.SelectedItem;
            StreamSocketListener listener = new StreamSocketListener();
            listener.ConnectionReceived += SocketListener_ConnectionReceived;
            listener.Control.KeepAlive = false;
            try
            {
                await listener.BindEndpointAsync(selectedLocalHost.LocalHost, "22112");
            }
            catch(Exception ex)
            {
                //
            }
            tcpConnection(selectedLocalHost);
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
}
