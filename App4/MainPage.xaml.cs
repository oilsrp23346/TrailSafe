using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.ApplicationModel.Background;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            lostTouristNotification();
        }

        private void HambergerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                //home.IsSelected = true;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (home.IsSelected) {
                MyFrame.Navigate(typeof(Tourist));
                TitleTextBlock.Text = "Tourist";
            }
            else if (node.IsSelected)
            {
                MyFrame.Navigate(typeof(ShowNode));
                TitleTextBlock.Text = "Node Information";
            }
            else if (addTourist.IsSelected) {
                MyFrame.Navigate(typeof(AddInfo));
                TitleTextBlock.Text = "Tourist Information";
            }
            else if (map.IsSelected)
            {
                MyFrame.Navigate(typeof(map));
                TitleTextBlock.Text = "Map";
            }
            else if (socket.IsSelected)
            {
                MyFrame.Navigate(typeof(Socket));
                TitleTextBlock.Text = "Socket";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //home.IsSelected = true;
            socket.IsSelected = true;
        }

        private async void lostTouristNotification()
        {
            var access = await BackgroundExecutionManager.RequestAccessAsync();
            bool taskRegistered = false;

            switch (access)
            {
                case BackgroundAccessStatus.Unspecified:
                    break;
                case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                    break;
                case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                    break;
                case BackgroundAccessStatus.Denied:
                    break;
                default:
                    break;
            }

            var task = new BackgroundTaskBuilder
            {
                Name = "lostTouristNotification",
                TaskEntryPoint = typeof(BackgroundTask.MyBackgroundTask).ToString()
            };

            var trigger = new ApplicationTrigger();
           // TimeTrigger time = new TimeTrigger(2, false);
        
            task.SetTrigger(trigger);
            

            foreach (var t in BackgroundTaskRegistration.AllTasks)
            {
                if (t.Value.Name == "lostTouristNotification")
                {
                    taskRegistered = true;
                    break;
                }
            }
            if(!taskRegistered)
            {
                await BackgroundExecutionManager.RequestAccessAsync();
                task.Register();
            }
            
            await trigger.RequestAsync();
        }
    }
}
