﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.Data.Json;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace App4.Model
{
    public class Node
    {
        private string Topic = "Node";
        public int id { get; set; }
        public string node_type { get; set; }
        public int online_status { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Node()
        {
            this.id = -1;
            this.node_type = "";
            this.online_status = -1;
            this.latitude = -1;
            this.longitude = -1;
        }

        public Node(int id, string node_type, int online_status, double latitude, double longitude)
        {
            this.id = id;
            this.node_type = node_type;
            this.online_status = online_status;
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
            for (uint i = 0; i < jsonArr.Count; i++)
            {
                int id = -1;
                int onlineStatus = -1;
                string nodeType = "";
                double latitude = -1;
                double longitude = -1;
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
                Node node = new Node(id, nodeType, onlineStatus, latitude, longitude);
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

        public static Node getNodeByID(int id)
        {
            Uri uri = new Uri("http://207.46.230.196/node/find_by_id?device-id=" + id);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonValue json = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString());
            int id_pri = -1;
            int onlineStatus = -1;
            string nodeType = "";
            double latitude = -1;
            double longitude = -1;
            if (json.GetObject()["id"].ValueType != JsonValueType.Null)
                id_pri = Int32.Parse(json.GetObject().GetNamedString("id"));
            if (json.GetObject()["node_type"].ValueType != JsonValueType.Null)
                nodeType = json.GetObject().GetNamedString("node_type");
            if (json.GetObject()["online_status"].ValueType != JsonValueType.Null)
                onlineStatus = Int32.Parse(json.GetObject().GetNamedString("online_status"));
            if (json.GetObject()["latitude"].ValueType != JsonValueType.Null)
                latitude = Double.Parse(json.GetObject().GetNamedString("latitude"));
            if (json.GetObject()["longitude"].ValueType != JsonValueType.Null)
                longitude = Double.Parse(json.GetObject().GetNamedString("longitude"));
            Node node = new Node(id_pri, nodeType, onlineStatus, latitude, longitude);
            return node;
        }

        public static Node[] getAllOfflineNode()
        {
            ArrayList nodeArr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/node/getofflinenodes");
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
                Node node = new Node(id, nodeType, onlineStatus, latitude, longitude);
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

        public static Node[] getAllOnlineNode()
        {
            ArrayList nodeArr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/node/getonlinenodes");
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
                Node node = new Node(id, nodeType, onlineStatus, latitude, longitude);
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


        //list
        public static void GetNodes(string topic, ObservableCollection<Node> nodesItems)
        {
            var allItems = getNodesItems();

            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();

            nodesItems.Clear();

            filteredNewsItems.ForEach(p => nodesItems.Add(p));
        }
        private static List<Node> getNodesItems()
        {
            var nodes = new List<Node>();
            Node[] node = Node.getAllNode();

            foreach (Node no in node)
            {
                nodes.Add(no);
            }
            return nodes;
        }
    }
}