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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using App4.Model;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App4
{
    public sealed partial class Node_form : UserControl
    {
        public Node Node { get { return this.DataContext as Node; } }

        public Node_form()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
            
            //show image status
            String imagesource = "";
           // if (Node.online_status == 1)
           // {
                imagesource = "ms-appx:///image/feature-buttons-system-status.jpg";
           // }
           // else
           // {
           //     imagesource = "ms-appx:///image/red-pin.jpg";
           // }
           // MyImage.Source = new BitmapImage(new Uri(imagesource, UriKind.Absolute));
        }
    }
}
