﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.Data.Json;

namespace App4.model
{
    class Node
    {
        private int id { get; set; }
        private string nodeType { get; set; }
        private int onlineStatus { get; set; }
        private double latitude { get; set; }
        private double longitude { get; set; }

        public Node()
        {
            this.id = -1;
            this.nodeType = "";
            this.onlineStatus = -1;
            this.latitude = -1;
            this.longitude = -1;
        }

        public Node(int id, string nodeType, int onlineStatus, double latitude, double longitude)
        {
            this.id = id;
            this.nodeType = nodeType;
            this.onlineStatus = onlineStatus;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public static Node[] getAllNode()
        {
            ArrayList nodeArr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/node/allnodes");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonArray jsonArr = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString()).GetArray();
            for(uint i = 0;i < jsonArr.Count;i++)
            {
                int id = -1;
                int onlineStatus = -1;
                string nodeType = "";
                double latitude = -1;
                double longitude = -1;
                if(jsonArr.GetObjectAt(i)["id"].ValueType != JsonValueType.Null)
                    id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("id"));
                if (jsonArr.GetObjectAt(i)["node_type"].ValueType != JsonValueType.Null)
                    nodeType = jsonArr.GetObjectAt(i).GetNamedString("node_type");
                if (jsonArr.GetObjectAt(i)["online_status"].ValueType != JsonValueType.Null)
                    onlineStatus = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("online_status"));
                if (jsonArr.GetObjectAt(i)["latitude"].ValueType != JsonValueType.Null)
                    latitude = Double.Parse(jsonArr.GetObjectAt(i).GetNamedString("latitude"));
                if (jsonArr.GetObjectAt(i)["longitude"].ValueType != JsonValueType.Null)
                    longitude = Double.Parse(jsonArr.GetObjectAt(i).GetNamedString("longitude"));
                Node node = new Node(id, nodeType, onlineStatus, latitude, longitude);
                nodeArr.Add(node);
            }
            Node[] nodeReturn = new Node[nodeArr.Count];
            int index = 0;
            foreach(Node node in nodeArr)
            {
                nodeReturn[index++] = node;
            }
            return nodeReturn;
        }
    }
}
