using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.Model
{
    public class Node
    {
        public string Topic { get; set; }
        public int id { get; set; }
        public string node_type { get; set; }
        public int online_status { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

    }

    public class NodesManager
    {
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

            nodes.Add(new Node { Topic = "Node", id = 0, node_type = "INTERNAL", online_status = 0, latitude = "1.45737" ,longitude = "1.45737"  });
            nodes.Add(new Node { Topic = "Node", id = 1, node_type = "INTERNAL", online_status = 1, latitude = "1.45737", longitude = "1.45737" });
            nodes.Add(new Node { Topic = "Node", id = 2, node_type = "INTERNAL", online_status =1, latitude = "1.45737", longitude = "1.45737" });
            nodes.Add(new Node { Topic = "Node", id = 3, node_type = "INTERNAL", online_status = 0, latitude = "1.45737",longitude = "1.45737"});
           
            return nodes;
        }
    }
}
