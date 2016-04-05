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
using App4.controls;
using Windows.UI.Popups;
using NotificationsExtensions.Toasts;
using Windows.UI.Notifications;
using App4.Model;
using System.Collections.ObjectModel;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserAround : Page
    {
        private ObservableCollection<User> usersItems;
        
        public UserAround()
        {
            this.InitializeComponent();
        }

        //recieve Node id
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Node test = (Node)e.Parameter;
            //txttest.Text = "Hi, " + test.id;
            getNodeId(test);
        }

        private void getNodeId(Node test)
        {
            if (test != null)
            {
                usersItems = new ObservableCollection<User>();
                int id = test.id;
                User.addUserbyNode("Tourist", usersItems, id);
            }
       }

        private User user = null;
        private void GridView_UserClick(object sender, ItemClickEventArgs e)
        {
            // this.Frame.Navigate(typeof(map));
            user = (User)e.ClickedItem;
            this.Frame.Navigate(typeof(map), User.getNearbyNode(user.id));
        }

    }
}

