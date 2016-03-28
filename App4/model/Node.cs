using System;
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
        public string Topic = "Node";
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

        public static Node[] getArrayOdNode(string url)
        {
            ArrayList nodeArr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/node/" + url);
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

        public static Node getSingleOfNode(string url)
        {
            Uri uri = new Uri("http://207.46.230.196/node/" + url);
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

        public static Node[] getAllNode()
        {
            return getArrayOdNode("allnodes");
        }

        public static Node getNodeByID(int id)
        {
            return getSingleOfNode("find_by_id?device-id=" + id);
        }

        public static Node[] getAllOfflineNode()
        {
            return getArrayOdNode("getofflinenodes");
        }

        public static Node[] getAllOnlineNode()
        {
            return getArrayOdNode("getonlinenodes");
        }

        public static int[] getAllNodeStatus()
        {
            ArrayList statusArr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/node/getallnodesstatus");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonArray json = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString()).GetArray();
            for(uint i = 0;i < json.Count;i++)
            {
                int status = Int32.Parse(json.GetStringAt(i));
                statusArr.Add(status);
            }
            int[] statusReturn = new int[statusArr.Count];
            int index = 0;
            foreach(int status in statusArr)
            {
                statusReturn[index++] = status;
            }
            return statusReturn;
        }

        public static int getNodeStatus(int id)
        {
            Uri uri = new Uri("http://207.46.230.196/node/getstatus?device-id=" + id);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonValue json = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString());
            int status = (int)json.GetNumber();
            return status;
        }

        

        public static Node getNodeByCoordinate(double latitude, double longitude)
        {
            return getSingleOfNode("find_by_coordinate?latitude=" + latitude + "&longitude=" + longitude);
        }

        

        //add list
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

        public static NodeEvent[] getNodeEvent(int id)
        {
            ArrayList nodeRarr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/node/error_log?device-id=" + id);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonArray jsonArr = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString()).GetArray();
            for (uint i = 0; i < jsonArr.Count; i++)
            {
                int id_pri = -1;
                int node_id = -1;
                int type = -1;
                string detail = "";
                string sys_info = "";
                string created_at = "";
                if (jsonArr.GetObjectAt(i)["id"].ValueType != JsonValueType.Null)
                    id_pri = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("id"));
                if (jsonArr.GetObjectAt(i)["node_id"].ValueType != JsonValueType.Null)
                    node_id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("node_id"));
                if (jsonArr.GetObjectAt(i)["type"].ValueType != JsonValueType.Null)
                    type = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("type"));
                if (jsonArr.GetObjectAt(i)["detail"].ValueType != JsonValueType.Null)
                    detail = jsonArr.GetObjectAt(i).GetNamedString("detail");
                if (jsonArr.GetObjectAt(i)["sys_info"].ValueType != JsonValueType.Null)
                    sys_info = jsonArr.GetObjectAt(i).GetNamedString("sys_info");
                if (jsonArr.GetObjectAt(i)["created_at"].ValueType != JsonValueType.Null)
                    created_at = jsonArr.GetObjectAt(i).GetNamedString("created_at");
                NodeEvent nd = new NodeEvent(id_pri, node_id, type, detail, sys_info, created_at);
                nodeRarr.Add(nd);
            }
            NodeEvent[] ndReturn = new NodeEvent[nodeRarr.Count];
            int index = 0;
            foreach (NodeEvent nd in nodeRarr)
            {
                ndReturn[index++] = nd;
            }
            return ndReturn;
        }


        //add error
        public static void addError(string topic, ObservableCollection<NodeEvent> nodesItems, int nodeId)
        {
            var allItems = getNodesItems(nodeId);
            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();
            nodesItems.Clear();
            filteredNewsItems.ForEach(p => nodesItems.Add(p));
        }
        private static List<NodeEvent> getNodesItems(int nodeId)
        {
            var nodes = new List<NodeEvent>();
            NodeEvent[] node = Node.getNodeEvent(nodeId);

            foreach (NodeEvent no in node)
            {
                nodes.Add(no);
            }
            return nodes;
        }

        public static NodeRegistration[] getNodeRegistration(int id)
        {
            ArrayList nodeRarr = new ArrayList();
            Uri uri = new Uri("http://207.46.230.196/node/registration_log?device-id=" + id);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            JsonArray jsonArr = JsonValue.Parse(response.Content.ReadAsStringAsync().Result.ToString()).GetArray();
            for (uint i = 0; i < jsonArr.Count; i++)
            {
                int id_pri = -1;
                int node_id = -1;
                string path = "";
                int registration_node_id = -1;
                string created_at = "";
                if (jsonArr.GetObjectAt(i)["id"].ValueType != JsonValueType.Null)
                    id_pri = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("id"));
                if (jsonArr.GetObjectAt(i)["node_id"].ValueType != JsonValueType.Null)
                    node_id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("node_id"));
                if (jsonArr.GetObjectAt(i)["path"].ValueType != JsonValueType.Null)
                    path = jsonArr.GetObjectAt(i).GetNamedString("path");
                if (jsonArr.GetObjectAt(i)["registration_node_id"].ValueType != JsonValueType.Null)
                    registration_node_id = Int32.Parse(jsonArr.GetObjectAt(i).GetNamedString("registration_node_id"));
                if (jsonArr.GetObjectAt(i)["created_at"].ValueType != JsonValueType.Null)
                    created_at = jsonArr.GetObjectAt(i).GetNamedString("created_at");
                NodeRegistration nd = new NodeRegistration(id_pri, node_id, path, registration_node_id, created_at);
                nodeRarr.Add(nd);
            }
            NodeRegistration[] ndReturn = new NodeRegistration[nodeRarr.Count];
            int index = 0;
            foreach (NodeRegistration nd in nodeRarr)
            {
                ndReturn[index++] = nd;
            }
            return ndReturn;
        }
        //add Register
        public static void addRegister(string topic, ObservableCollection<NodeRegistration> nodesItems, int nodeId)
        {
            var allItems = getNodesRegister(nodeId);
            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();
            nodesItems.Clear();
            filteredNewsItems.ForEach(p => nodesItems.Add(p));
        }
        private static List<NodeRegistration> getNodesRegister(int nodeId)
        {
            var nodes = new List<NodeRegistration>();
            NodeRegistration[] node = Node.getNodeRegistration(nodeId);

            foreach (NodeRegistration no in node)
            {
                nodes.Add(no);
            }
            return nodes;
        }

        //add General
        /*public static void addGeneral(string topic, ObservableCollection<Node> nodesItems, int nodeId)
        {
            var allItems = getNodesGeneral(nodeId);
            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();
            nodesItems.Clear();
            filteredNewsItems.ForEach(p => nodesItems.Add(p));
        }
        private static List<Node> getNodesGeneral(int nodeId)
        {
            var nodes = new List<Node>();
            Node[] node = Node.getAllNode(nodeId);

            foreach (Node no in node)
            {
                nodes.Add(no);
            }
            return nodes;
        }*/
    }
}
