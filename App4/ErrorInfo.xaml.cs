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
using App4.model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ErrorInfo : Page
    {
        Node test = null;
        public Model.Node Node { get { return this.DataContext as Model.Node; } }
        public ErrorInfo()
        {
            this.InitializeComponent();

            //NodeEvent[] no = Node.getNodeEvent(test.id);

        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            test = (Node)e.Parameter;
        }
    }
}
