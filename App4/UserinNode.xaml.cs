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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserinNode : Page
    {
        Node test = null;
        private ObservableCollection<Node> nodesItems;
        public UserinNode()
        {
            this.InitializeComponent();
        }

        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Node node = (Node)e.Parameter;
            getNodeId(node);
        }
        private void getNodeId(Node node)
        {
            nodesItems = new ObservableCollection<Node>();
            int id = test.id;
            Node.addGeneral("NodeEvent", nodesItems, id);
        }*/
    }
  
}
