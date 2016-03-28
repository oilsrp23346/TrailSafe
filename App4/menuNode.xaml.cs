﻿
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
            this.Frame.Navigate(typeof(UserinNode), node);
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
             node = (Node)e.Parameter;
            //txtLat.Text = "Hi, " + node.id;
            base.OnNavigatedTo(e);
        }
    }
}
