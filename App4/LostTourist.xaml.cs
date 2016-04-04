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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    public sealed partial class LostTourist : Page
    {
        private User user = null;
        private ObservableCollection<User> usersItems;
        public LostTourist()
        {
            this.InitializeComponent();
            usersItems = new ObservableCollection<User>();
            User.addLostTourist("Tourist", usersItems);
        }
        private async void GridView_UserClick(object sender, ItemClickEventArgs e)
        {
            MessageDialog showDialog = new MessageDialog("Do you want to respond ?");
            showDialog.Commands.Add(new UICommand("Yes")
            {
                Id = 0
            });
            showDialog.Commands.Add(new UICommand("No")
            {
                Id = 1
            });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                user = (User)e.ClickedItem;
                User.responseEmergency(user.wristbandID);
                this.Frame.Navigate(typeof(map),User.getNearbyNode(user.id));
                
            }
        }
    }
}