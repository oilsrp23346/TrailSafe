
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
using App4.Model;
using Windows.UI.Notifications;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>


    public sealed partial class menuNode : Page
    {

        public menuNode()
        {
            this.InitializeComponent();
        }
        
        private void useraround_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserAround), node);
        }

        private void errorInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ErrorInfo), node);
        }

        private void registerInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterInfo), node);
        }
        //get latitude from map 
        Node node = null;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null) {
                node = (Node)e.Parameter;
                nodeID.Text = "NODE : " + node.id;
                base.OnNavigatedTo(e);
            }
        }

        private void notify_Click(object sender, RoutedEventArgs e)
        {
            if (node != null) {
                Node.warnNode(node.id);
            }
        }
        private void unnotify_Click(object sender, RoutedEventArgs e)
        {
            if (node != null)
            {
                Node.cancelWarningNode(node.id);
            }
        }       
    }  
}
