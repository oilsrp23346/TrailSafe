using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI.Popups;
using Windows.Data.Json;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace App4.Model
{
    public class User
    {
       private string Topic = "Tourist";
        // private string text;
        // private int v1;
        // private int v2;
        //public string Topic { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int identifier { get; set; }
        public int profilePic { get; set; }
        public int status { get; set; }
        public int wristbandID { get; set; }

        public User()
        {

            this.id = -1;
            this.name = "";
            this.identifier = -1;
            this.profilePic = -1;
            this.status = -1;
            this.wristbandID = -1;
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
        //add_list
        public static void add(string topic, ObservableCollection<User> usersItems)
        {
            var allItems = getUsersItems();
            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();
            usersItems.Clear();
            filteredNewsItems.ForEach(p => usersItems.Add(p));
        }
        private static List<User> getUsersItems()
        {
            var users = new List<User>();
            User[] user = User.getAllUser();
            foreach(User us in user)
            {
                users.Add(us);
            }
            return users;
        }
        //save
        public async void registerUser()
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

        public static User getSingleOfUser(string url)
        {
            Uri uri = new Uri("http://207.46.230.196/user/" + url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonValue json = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString());
            int id_pri = -1;
            string name = "";
            int identifier = -1;
            int profilePic = -1;
            int status = -1;
            int wristbandID = -1;
            if (json.GetObject()["id"].ValueType != JsonValueType.Null)
                id_pri = Int32.Parse(json.GetObject().GetNamedString("id"));
            if (json.GetObject()["name"].ValueType != JsonValueType.Null)
                name = json.GetObject().GetNamedString("name");
            if (json.GetObject()["identifier"].ValueType != JsonValueType.Null)
                identifier = Int32.Parse(json.GetObject().GetNamedString("identifier"));
            if (json.GetObject()["profile_pic"].ValueType != JsonValueType.Null)
                profilePic = Int32.Parse(json.GetObject().GetNamedString("profile_pic"));
            if (json.GetObject()["status"].ValueType != JsonValueType.Null)
                status = Int32.Parse(json.GetObject().GetNamedString("status"));
            if (json.GetObject()["wristband_id"].ValueType != JsonValueType.Null)
                wristbandID = Int32.Parse(json.GetObject().GetNamedString("wristband_id"));
            User user = new User(id_pri, name, identifier, profilePic, status, wristbandID);
            return user;
        }
        public static User[] getAllUser()
        {
            ArrayList userArr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/user/get_all_user");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonArray jsonArr = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString()).GetArray();
            for (uint i = 0; i < jsonArr.Count; i++)
            {
                int id = -1;
                string name = "";
                int identifier = -1;
                int profilePic = -1;
                int status = -1;
                int wristbandID = -1;
                if (jsonArr.GetObjectAt(i)["id"].ValueType != JsonValueType.Null)
                    id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("id"));
                if (jsonArr.GetObjectAt(i)["name"].ValueType != JsonValueType.Null)
                    name = jsonArr.GetObjectAt(i).GetNamedString("name");
                if (jsonArr.GetObjectAt(i)["identifier"].ValueType != JsonValueType.Null)
                    identifier = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("identifier"));
                if (jsonArr.GetObjectAt(i)["profile_pic"].ValueType != JsonValueType.Null)
                    profilePic = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("profile_pic"));
                if (jsonArr.GetObjectAt(i)["status"].ValueType != JsonValueType.Null)
                    status = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("status"));
                if (jsonArr.GetObjectAt(i)["wristband_id"].ValueType != JsonValueType.Null)
                    wristbandID = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("wristband_id"));
                User user = new User(id, name, identifier, profilePic, status, wristbandID);
                userArr.Add(user);
            }
            User[] userReturn = new User[userArr.Count];
            int index = 0;
            foreach (User user in userArr)
            {
                userReturn[index++] = user;
            }
            return userReturn;
        }
        public static User getUserbyID(int id)
        {
            Uri uri = new Uri("http://207.46.230.196/user/find_by_id?user-id=" + id);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonValue json = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString());
            int id_pri = -1;
            string name = "";
            int identifier = -1;
            int profilePic = -1;
            int status = -1;
            int wristbandID = -1;
            if (json.GetObject()["id"].ValueType != JsonValueType.Null)
                id_pri = Int32.Parse(json.GetObject().GetNamedString("id"));
            if (json.GetObject()["name"].ValueType != JsonValueType.Null)
                name = json.GetObject().GetNamedString("name");
            if (json.GetObject()["identifier"].ValueType != JsonValueType.Null)
                identifier = Int32.Parse(json.GetObject().GetNamedString("identifier"));
            if (json.GetObject()["profile_pic"].ValueType != JsonValueType.Null)
                profilePic = Int32.Parse(json.GetObject().GetNamedString("profile_pic"));
            if (json.GetObject()["status"].ValueType != JsonValueType.Null)
                status = Int32.Parse(json.GetObject().GetNamedString("status"));
            if (json.GetObject()["wristband_id"].ValueType != JsonValueType.Null)
                wristbandID = Int32.Parse(json.GetObject().GetNamedString("wristband_id"));
            User user = new User(id_pri, name, identifier, profilePic, status, wristbandID);
            return user;
        }
        public static async void unRegisterUser(int id)
        {
            Uri uri = new Uri("http://207.46.230.196/user/unregister?user-id=" + id);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            string message = "";
            if (response.IsSuccessStatusCode)
            {
                message = "Successful unregister user!";
            }
            else
            {
                message = "Failed unregister user!";
            }
            var messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }
        public static User[] getUserArounfNode(int device_id)
        {
            return getArrayOfUser("find_by_node?device-id=" + device_id);
        }
        public static User[] getArrayOfUser(string url)
        {
            ArrayList userArr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/user/" + url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonArray jsonArr = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString()).GetArray();
            for (uint i = 0; i < jsonArr.Count; i++)
            {
                int id = -1;
                string name = "";
                int identifier = -1;
                int profilePic = -1;
                int status = -1;
                int wristbandID = -1;
                if (jsonArr.GetObjectAt(i)["id"].ValueType != JsonValueType.Null)
                    id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("id"));
                if (jsonArr.GetObjectAt(i)["name"].ValueType != JsonValueType.Null)
                    name = jsonArr.GetObjectAt(i).GetNamedString("name");
                if (jsonArr.GetObjectAt(i)["identifier"].ValueType != JsonValueType.Null)
                    identifier = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("identifier"));
                if (jsonArr.GetObjectAt(i)["profile_pic"].ValueType != JsonValueType.Null)
                    profilePic = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("profile_pic"));
                if (jsonArr.GetObjectAt(i)["status"].ValueType != JsonValueType.Null)
                    status = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("status"));
                if (jsonArr.GetObjectAt(i)["wristband_id"].ValueType != JsonValueType.Null)
                    wristbandID = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("wristband_id"));
                User user = new User(id, name, identifier, profilePic, status, wristbandID);
                userArr.Add(user);
            }
            User[] userReturn = new User[userArr.Count];
            int index = 0;
            foreach (User user in userArr)
            {
                userReturn[index++] = user;
            }
            return userReturn;
        }

    }
}