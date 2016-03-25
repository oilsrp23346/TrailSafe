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



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserAround : Page
    {
        public UserAround()
        {
            this.InitializeComponent();

        }
        // private void ButtonPopToast_Click(object sender, RoutedEventArgs e)
        // {
        //     ToastHelper.PopCustomToast(TextBoxPayload.Text);
        // }

            //noti
        private void Show(ToastContent content)
        {
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
        }
        private void ButtonPopToast_Click(object sender, RoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    TitleText = new ToastText() { Text = "Warning" },
                    BodyTextLine1 = new ToastText() { Text = "Tourist wants your help" }
                },

                Launch = "39",

                Scenario = ToastScenario.Alarm,
                Actions = new ToastActionsCustom()
                {
                   
                Buttons =
                    {
                    new ToastButtonSnooze("5 more mins plz"),
                        new ToastButtonDismiss("ok,help now")
                    }
                }
            });
        }

    }
 }

