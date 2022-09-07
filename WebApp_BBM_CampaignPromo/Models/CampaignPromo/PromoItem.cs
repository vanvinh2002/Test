
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BBM_CampaignPromo.Models.CampaignPromo
{
    public class PromoItem
    {
        public string id { set; get; }
        public string headerId { set; get; }
        public string itemNo { set; get; }
        public string itemName { set; get; }
        public string UoM { set; get; }
        public string salesPrices { set; get; }
        public string stockQty { set; get; }
        public string Quantity { set; get; }
        public string status { set; get; }
        public string createdBy { set; get; }
        public string createdDate { set; get; }
        public string modifyBy { set; get; }
        public string modifyDate { set; get; }
    }
}
