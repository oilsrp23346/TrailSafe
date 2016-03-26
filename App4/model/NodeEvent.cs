using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.model
{
    public class NodeEvent
    {
        private int id { get; set; }
        private int node_id { get; set; }
        private int type { get; set; }
        private string detail { get; set; }
        private string sys_info { get; set; }
        private string created_at { get; set; }

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
