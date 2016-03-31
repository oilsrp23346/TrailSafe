using App4.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Unregister : Page
    {
        public Unregister()
        {
            this.InitializeComponent();
        }

        private void unregister_Click(object sender, RoutedEventArgs e)
        {
            //do something
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //send 
        }
        public void clearForm()
        {
            Whistband.Text = "";
        }

        private async void save_Click(object sender, RoutedEventArgs e)
        {
            if (Whistband.Text == "")
            {
                MessageDialog ms = new MessageDialog("Please fill the box below.");
                await ms.ShowAsync();
                clearForm();
            }
            else
            {
                User user = new User(Int32.Parse(Whistband.Text));
                //user.unRegisterUser();
                clearForm();
            }
        }
    }
}
