using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;

namespace BackgroundTask
{
    public sealed class User
    {
        private string Topic = "Tourist";
        public int id { get; set; }
        public string name { get; set; }
        public double identifier { get; set; }
        public string profilePic { get; set; }
        public int status { get; set; }
        public int wristbandID { get; set; }
        public BitmapImage bitmap { get; set; }
        public object JsonConvert { get; private set; }

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

        public User(int id, string name, double identifier, string profilePic, int status, int wristbandID)
        {
            this.id = id;
            this.name = name;
            this.identifier = identifier;
            this.profilePic = profilePic;
            this.status = status;
            this.wristbandID = wristbandID;
        }

        public User(int id, string name, double identifier, string profilePic, int status, int wristbandID, BitmapImage bitmap)
        {
            this.id = id;
            this.name = name;
            this.identifier = identifier;
            this.profilePic = profilePic;
            this.status = status;
            this.wristbandID = wristbandID;
            this.bitmap = bitmap;
        }

        public User(string name, double identifier, string profilePic, int wristbandID)
        {
            this.name = name;
            this.identifier = identifier;
            this.profilePic = profilePic;
            this.wristbandID = wristbandID;
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
                    double identifier = -1;
                    string profilePic = "";
                    int status = -1;
                    int wristbandID = -1;
                    if (jsonArr.GetObjectAt(i)["id"].ValueType != JsonValueType.Null)
                        id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("id"));
                    if (jsonArr.GetObjectAt(i)["name"].ValueType != JsonValueType.Null)
                        name = jsonArr.GetObjectAt(i).GetNamedString("name");
                    if (jsonArr.GetObjectAt(i)["identifier"].ValueType != JsonValueType.Null)
                        identifier = Double.Parse(jsonArr.GetObjectAt(i).GetNamedString("identifier"));
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
            catch (Exception e)
            {
                return null;
            }
        }

        public static User getSingleOfUser(string url)
        {
            try {
                Uri uri = new Uri("http://207.46.230.196/user/" + url);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(uri).Result;
                JsonValue json = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString());
                int id_pri = -1;
                string name = "";
                double identifier = -1;
                string profilePic = "";
                int status = -1;
                int wristbandID = -1;
                if (json.GetObject()["id"].ValueType != JsonValueType.Null)
                    id_pri = Int32.Parse(json.GetObject().GetNamedString("id"));
                if (json.GetObject()["name"].ValueType != JsonValueType.Null)
                    name = json.GetObject().GetNamedString("name");
                if (json.GetObject()["identifier"].ValueType != JsonValueType.Null)
                    identifier = Double.Parse(json.GetObject().GetNamedString("identifier"));
                if (json.GetObject()["profile_pic"].ValueType != JsonValueType.Null)
                    profilePic = json.GetObject().GetNamedString("profile_pic");
                if (json.GetObject()["status"].ValueType != JsonValueType.Null)
                    status = Int32.Parse(json.GetObject().GetNamedString("status"));
                if (json.GetObject()["wristband_id"].ValueType != JsonValueType.Null)
                    wristbandID = Int32.Parse(json.GetObject().GetNamedString("wristband_id"));
                User user = new User(id_pri, name, identifier, profilePic, status, wristbandID);
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
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

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
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

        public static User[] getLostUser()
        {
            return getArrayOfUser("get_lost_users");
        }
    }
}
