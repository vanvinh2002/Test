using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BBM_CampaignPromo.Models.CampaignPromo
{
    public class HeaderItem
    {
        public string id { set; get; }
        public string storeNo { set; get; }
        public string Name { set; get; }
        public string startDate { set; get; }
        public string endDate { set; get; }
        public string ActivedDayOfWeek { set; get; }
        public string Description { set; get; }
        public string maximumGanranti { set; get; }
        public string MainProductType { set; get; }
        public string PromoProductType { set; get; }
        public string status { set; get; }
        public string createdBy { set; get; }
        public string createdDate { set; get; }
        public string modifyBy { set; get; }
        public string modifyDate { set; get; }
    }
}
