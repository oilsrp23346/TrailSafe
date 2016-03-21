﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI.Popups;
using System.Collections.ObjectModel;


namespace App4.Model
{
    public class User
    {
        private string Topic = "Tourist";
        private int id { get; set; }
        private string name { get; set; }
        private int identifier { get; set; }
        private int profilePic { get; set; }
        private int status { get; set; }
        private int wristbandID { get; set; }

        public User()
        {
            
            this.id = 0;
            this.name = "";
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

        public User(string name, int identifier, int wristbandID)
        {
            this.name = name;
            this.identifier = identifier;
            this.wristbandID = wristbandID;
        }

        public async void save()
        {
            Uri geturi = new Uri("http://207.46.230.196/user/register?name=" + this.name + "&identifier=" + this.identifier + "&profile-picture=" + this.profilePic + "&wristband-id=" + this.wristbandID);
            HttpClient client = new HttpClient();
            string message = "";
            HttpResponseMessage response = await client.GetAsync(geturi);
            if (response.IsSuccessStatusCode)
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
        //add_list
        public static void add(string topic,ObservableCollection<User> usersItems)
        {
            var allItems = getUsersItems();
            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();
            usersItems.Clear();
            filteredNewsItems.ForEach(p => usersItems.Add(p));

        }
        private static List<User> getUsersItems()
        {
            var users = new List<User>();
            //User user = new User();
            // users.Add(user);
            users.Add(new User { Topic = "Tourist", name = "aa" , wristbandID =1 , identifier =1234});
            users.Add(new User { Topic = "Tourist", name = "bb", wristbandID = 2, identifier = 1234 });
            return users;
        }
    }
}