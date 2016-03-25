
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
        private void genInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserinNode));
        }   
        private void useraround_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserAround));
        }

        private void errorInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ErrorInfo));
        }

        private void registerInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterInfo));
        }
        //get latitude from map 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            double la = (double)e.Parameter;
            if (la == 16.831196)
            // if (e.Parameter is Node)
            {
                txtLat.Text = "Hi, " + e.Parameter.ToString();
            }
            else
            {
                txtLong.Text = "Hi!++" + e.Parameter.ToString();
            }
            base.OnNavigatedTo(e);
        }
    }
}
