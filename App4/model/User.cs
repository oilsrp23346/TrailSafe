﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI.Popups;

namespace App4
{
    class User
    {
        private int id { get; set; }
        private string name { get; set; }
        private int identifier { get; set; }
        private int profilePic { get; set; }
        private int status { get; set; }
        private int wristbandID { get; set; }

        public User()
        {
            this.id = 0;
            this.name = null;
            this.identifier = 0;
            this.profilePic = 0;
            this.status = 0;
            this.wristbandID = 0;
        }

        public User(int id, string name, int identifier, int profilePic, int status, int wristbandID)
        {
            this.id = id;
            this.name = name;
            this.identifier = identifier;
            this.profilePic = profilePic;
            this.status = status;
            this.wristbandID = wristbandID;
        }

        public async void save()
        {
            Uri geturi = new Uri("http://207.46.230.196/user/register?name=" + this.name + "&identifier=" + this.identifier + "&profile-picture=" + this.profilePic + "&wristband-id=" + this.wristbandID); 
            HttpClient client = new HttpClient();
            string message = "";
            HttpResponseMessage response = await client.GetAsync(geturi);
            if(response.IsSuccessStatusCode)
            {
                message = "Complete!";
            }
            else
            {
                message = "Cannot save to database.";
            }
            var messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }
    }
}
