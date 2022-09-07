using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BBM_CampaignPromo.Models.CampaignPromo
{
    public class ItemCore
    {
        public string storeNo { set; get; }
        public string itemNo { set; get; }
        public string stockQty { set; get; }
        public string itemName { set; get; }
        public string Uom { set; get; }
        public string divCode { set; get; }
        public string catCode { set; get; }
        public string groupCode { set; get; }
        public string funcCode { set; get; }
        public string isGift { set; get; }
        public string salePrice { set; get; }
    }
}
