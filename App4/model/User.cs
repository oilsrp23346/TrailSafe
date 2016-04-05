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
using Newtonsoft.Json;
using Windows.UI.Xaml.Media.Imaging;
using App4.model;

namespace App4.Model
{
    public class User
    {
        private string Topic = "Tourist";
        public int id { get; set; }
        public string name { get; set; }
        public int identifier { get; set; }
        public string profilePic { get; set; }
        public int status { get; set; }
        public int wristbandID { get; set; }
        public BitmapImage bitmap { get; set; }

        public User()
        {

            this.id = -1;
            this.name = "";
            this.identifier = -1;
            this.profilePic = "";
            this.status = -1;
            this.wristbandID = -1;
            this.bitmap = null;
        }

        public User(int id, string name, int identifier, string profilePic, int status, int wristbandID)
        {
            this.id = id;
            this.name = name;
            this.identifier = identifier;
            this.profilePic = profilePic;
            this.status = status;
            this.wristbandID = wristbandID;
        }

        public User(int id, string name, int identifier, string profilePic, int status, int wristbandID, BitmapImage bitmap)
        {
            this.id = id;
            this.name = name;
            this.identifier = identifier;
            this.profilePic = profilePic;
            this.status = status;
            this.wristbandID = wristbandID;
            this.bitmap = bitmap;
        }
        public User(string name, int identifier, string profilePic, int wristbandID)
        {
            this.name = name;
            this.identifier = identifier;
            this.profilePic = profilePic;
            this.wristbandID = wristbandID;
        }

        public User(int wristbandID)
        {
            this.wristbandID = wristbandID;
        }

        //add_listUser_all
        public static void add(string topic, ObservableCollection<User> usersItems)
        {
            try { 
            var allItems = getUsersItems();
            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();
            usersItems.Clear();
            filteredNewsItems.ForEach(p => usersItems.Add(p));
            }
            catch(Exception e) {
               
            }
        }
        private static List<User> getUsersItems()
        {
            try { 
            var users = new List<User>();
                //-------------------------------show
                User[] user = User.getActiveUser();
                foreach (User us in user)
                {
                    us.bitmap = ImageConverter.byteArrayToBitmapImage(ImageConverter.Base64ToByteArray(us.profilePic)).Result;
                    users.Add(us);
                }
                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static User[] getLostUser()
        {
            return getArrayOfUser("get_lost_users");
        }
        //add_Lost user
        public static void addLostTourist(string topic, ObservableCollection<User> usersItems)
        {
            var allItems = getLost();
            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();
            usersItems.Clear();
            filteredNewsItems.ForEach(p => usersItems.Add(p));
        }
        private static List<User> getLost()
        {
            var users = new List<User>();
            //-------------------------------show
                User[] user = User.getLostUser();
            if (user != null)
            {
                foreach (User us in user)
                {
                    us.bitmap = ImageConverter.byteArrayToBitmapImage(ImageConverter.Base64ToByteArray(us.profilePic)).Result;
                    users.Add(us);
                }
            }
                return users;
            
        }

        //add_UserbyNode
        public static void addUserbyNode(string topic, ObservableCollection<User> usersItems,int nodeId)
        {
            var allItems = getUsersbyNode(nodeId);
            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();
            usersItems.Clear();
            filteredNewsItems.ForEach(p => usersItems.Add(p));
        }
        private static List<User> getUsersbyNode(int nodeId)
        {
            var users = new List<User>();
            //-------------------------------show
            User[] user = User.getUserArounfNode(nodeId);
            foreach (User us in user)
            {
                users.Add(us);
            }
            return users;
        }

        public static User[] getArrayOfUser(string url)
        {
            try {
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
                    string profilePic = "";
                    int status = -1;
                    int wristbandID = -1;
                    if (jsonArr.GetObjectAt(i)["id"].ValueType != JsonValueType.Null)
                        id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("id"));
                    if (jsonArr.GetObjectAt(i)["name"].ValueType != JsonValueType.Null)
                        name = jsonArr.GetObjectAt(i).GetNamedString("name");
                    if (jsonArr.GetObjectAt(i)["identifier"].ValueType != JsonValueType.Null)
                        identifier = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("identifier"));
                    if (jsonArr.GetObjectAt(i)["profile_pic"].ValueType != JsonValueType.Null)
                        profilePic = jsonArr.GetObjectAt(i).GetNamedString("profile_pic");
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
            catch(Exception e)
            {
                return null;
            }
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
            string profilePic = "";
            int status = -1;
            int wristbandID = -1;
            if (json.GetObject()["id"].ValueType != JsonValueType.Null)
                id_pri = Int32.Parse(json.GetObject().GetNamedString("id"));
            if (json.GetObject()["name"].ValueType != JsonValueType.Null)
                name = json.GetObject().GetNamedString("name");
            if (json.GetObject()["identifier"].ValueType != JsonValueType.Null)
                identifier = Int32.Parse(json.GetObject().GetNamedString("identifier"));
            if (json.GetObject()["profile_pic"].ValueType != JsonValueType.Null)
                profilePic = json.GetObject().GetNamedString("profile_pic");
            if (json.GetObject()["status"].ValueType != JsonValueType.Null)
                status = Int32.Parse(json.GetObject().GetNamedString("status"));
            if (json.GetObject()["wristband_id"].ValueType != JsonValueType.Null)
                wristbandID = Int32.Parse(json.GetObject().GetNamedString("wristband_id"));
            User user = new User(id_pri, name, identifier, profilePic, status, wristbandID);
            return user;
        }

        //save
        public async void registerUser()
        {
            try {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("name", name);
                parameters.Add("identifier", identifier.ToString());
                parameters.Add("wristband-id", wristbandID.ToString());
                parameters.Add("profile-picture", profilePic);

                string json = JsonConvert.SerializeObject(parameters);
                Uri geturi = new Uri("http://207.46.230.196/user/register");
                HttpClient client = new HttpClient();
                string message = "";
                HttpResponseMessage response = await client.PostAsync(geturi, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    message = "Register complete!.";
                }
                else
                {
                    message = "Failed to register!.";
                }
                var messageDialog = new MessageDialog(message);
                await messageDialog.ShowAsync();
            }
            catch (Exception e)
            {
                
            }
        }

        public static User[] getAllUser()
        {
            return getArrayOfUser("get_all_user");
        }
        public static User getUserbyID(int id)
        {
            return getSingleOfUser("find_by_id?user-id=" + id);
        }
        public static async void unRegisterUser(int id)
        {
            try {
                Uri uri = new Uri("http://207.46.230.196/user/unregister?device-id=" + id);
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
            catch (Exception e)
            {
                
            }
        }

         public static User[] getUserArounfNode(int device_id)
         {
           return getArrayOfUser("find_by_node?device-id=" + device_id);
         }

        
        public static User[] getActiveUser()
        {
            return getArrayOfUser("get_active_users");
        }
        public static Node[] getNearbyNode(int user_id)
        {
            try {
                ArrayList nodeArr = new ArrayList();
                Uri uri = new Uri("http://207.46.230.196/user/find_nearby_node?user-id=" + user_id);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(uri).Result;
                JsonArray jsonArr = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString()).GetArray();
                for (uint i = 0; i < jsonArr.Count; i++)
                {
                    int id = -1;
                    int onlineStatus = -1;
                    string nodeType = "";
                    double latitude = -1;
                    double longitude = -1;
                    int risk_status = -1;
                    double relative_humidity = -1;
                    double temperature = -1;
                    int smoke = -1;
                    int wildfire_risk_level = -1;
                    if (jsonArr.GetObjectAt(i)["id"].ValueType != JsonValueType.Null)
                        id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("id"));
                    if (jsonArr.GetObjectAt(i)["node_type"].ValueType != JsonValueType.Null)
                        nodeType = jsonArr.GetObjectAt(i).GetNamedString("node_type");
                    if (jsonArr.GetObjectAt(i)["online_status"].ValueType != JsonValueType.Null)
                        onlineStatus = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("online_status"));
                    if (jsonArr.GetObjectAt(i)["latitude"].ValueType != JsonValueType.Null)
                        latitude = Double.Parse(jsonArr.GetObjectAt(i).GetNamedString("latitude"));
                    if (jsonArr.GetObjectAt(i)["longitude"].ValueType != JsonValueType.Null)
                        longitude = Double.Parse(jsonArr.GetObjectAt(i).GetNamedString("longitude"));
                    if (jsonArr.GetObjectAt(i)["risk_status"].ValueType != JsonValueType.Null)
                        risk_status = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("risk_status"));
                    if (jsonArr.GetObjectAt(i)["relative_humidity"].ValueType != JsonValueType.Null)
                        relative_humidity = Double.Parse(jsonArr.GetObjectAt(i).GetNamedString("relative_humidity"));
                    if (jsonArr.GetObjectAt(i)["temperature"].ValueType != JsonValueType.Null)
                        temperature = Double.Parse(jsonArr.GetObjectAt(i).GetNamedString("temperature"));
                    if (jsonArr.GetObjectAt(i)["smoke"].ValueType != JsonValueType.Null)
                        smoke = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("smoke"));
                    if (jsonArr.GetObjectAt(i)["wildfire_risk_level"].ValueType != JsonValueType.Null)
                        wildfire_risk_level = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("wildfire_risk_level"));
                    Node node = new Node(id, nodeType, onlineStatus, latitude, longitude, risk_status, relative_humidity, temperature, smoke, wildfire_risk_level);
                    nodeArr.Add(node);

                }
                Node[] nodeReturn = new Node[nodeArr.Count];
                int index = 0;
                foreach (Node node in nodeArr)
                {
                    nodeReturn[index++] = node;
                }
                return nodeReturn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async void responseEmergency(int wristband_id)
        {
            try {
                Uri uri = new Uri("http://207.46.230.196/wristband/response_emergency?device-id=" + wristband_id);
                HttpClient client = new HttpClient();
                await client.GetAsync(uri);
            }
            catch (Exception e)
            {

            }
        }
    }
}
