using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace BackgroundTask
{
    public sealed class MyBackgroundTask : IBackgroundTask
    {

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            while(true)
            {
                Task.Delay(15000).Wait();
                User[] users = User.getAllUser();
                foreach (User user in users)
                {
                    if (user.status == 2)
                    {
                        SendToast(user.identifier.ToString());
                    }
                }
            }
        }

        public static void SendToast(string msg)
        {
            // template to load for showing Toast Notification
            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                     "<visual>" +
                                       "<binding template =\"ToastGeneric\">" +
                                         "<text>TrailSafe</text>" +
                                         "<text>" +
                                           "Tourist who has id " + msg + " is lost." +
                                         "</text>" +
                                       "</binding>" +
                                     "</visual>" +
                                     "<audio src = \"ms-winsoundevent:Notification.Reminder\" loop = \"false\" />" +
                                    "</toast>";

            // load the template as XML document
            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
            xmlDocument.LoadXml(xmlToastTemplate);

            // create the toast notification and show to user
            var toastNotification = new ToastNotification(xmlDocument);
            var notification = ToastNotificationManager.CreateToastNotifier();
            notification.Show(toastNotification);
        }
    }
}
