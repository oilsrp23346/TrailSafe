using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.Data.Json;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using App4.model;

namespace App4.Model
{
    public class NodeEvent
    {
        public string Topic = "NodeEvent";
        public int id { get; set; }
        public int node_id { get; set; }
        public int type { get; set; }
        public string detail { get; set; }
        public string sys_info { get; set; }
        public string created_at { get; set; }

        //errorEvent
        public NodeEvent()
        {
            id = -1;
            node_id = -1;
            type = -1;
            detail = "";
            sys_info = "";
            created_at = "";
        }

        public NodeEvent(int id, int node_id, int type, string detail, string sys_info, string created_at)
        {
            this.id = id;
            this.node_id = node_id;
            this.detail = detail;
            this.sys_info = sys_info;
            this.created_at = created_at;
        }

        

    }
}
