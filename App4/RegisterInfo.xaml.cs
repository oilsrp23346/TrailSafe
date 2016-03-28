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
    public sealed partial class RegisterInfo : Page
    {
        Node test = null;
        private ObservableCollection<NodeRegistration> nodesItems;
        public RegisterInfo()
        {
            this.InitializeComponent();

            //NodeEvent[] no = Node.getNodeEvent(test.id);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            test = (Node)e.Parameter;
            getNodeId(test);
        }
        private void getNodeId(Node test)
        {
            nodesItems = new ObservableCollection<NodeRegistration>();
            int id = test.id;
            Node.addRegister("NodeRegister", nodesItems, id);

        }

    }
}
