using App4.Model;
using System.Collections.ObjectModel;
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
    public sealed partial class ShowNode : Page
    {

        private ObservableCollection<Node> nodesItems;

        public ShowNode()
        {
            this.InitializeComponent();
            nodesItems = new ObservableCollection<Node>();
            Node.GetNodes("Node", nodesItems);
           // cars = CarManager.GetCars();
        }

        //link to map include Node's id 
        private void GridView_NodeClick(object sender, ItemClickEventArgs e)
        {
            ItemClickEventArgs myClickedIcon;
            this.Frame.Navigate(typeof(menuNode));
            //var cars = (Node)e.ClickedItem;
            //ResultTextBlock.Text = "You Selected--->>" + cars.Category + "--->>Model_ " + cars.Model;
        }
    }
}
