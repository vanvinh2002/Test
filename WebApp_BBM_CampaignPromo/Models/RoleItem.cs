using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BBM_CampaignPromo.Models
{
    public class RoleItem
    {
        public string roleCode { set; get; }
        public string controlCode { set; get; }
        public string create_act { set; get; }
        public string view_act { set; get; }
        public string edit_act { set; get; }
        public string accept_act { set; get; }
        public string root_act { set; get; }
    }
}
