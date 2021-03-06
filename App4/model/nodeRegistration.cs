﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.Model
{
    public class NodeRegistration
    {
        public string Topic = "NodeRegister";
        public int id { get; set; }
        public int node_id { get; set; }
        public string path { get; set; }
        public int registration_node_id { get; set; }
        public string created_at { get; set; }
        
        public NodeRegistration()
        {
            id = -1;
            node_id = -1;
            path = "";
            registration_node_id = -1;
            created_at = "";
        }

        public NodeRegistration(int id, int node_id, string path, int registration_node_id, string created_at)
        {
            this.id = id;
            this.node_id = node_id;
            this.path = path;
            this.registration_node_id = registration_node_id;
            this.created_at = created_at;
        }
    }
}
