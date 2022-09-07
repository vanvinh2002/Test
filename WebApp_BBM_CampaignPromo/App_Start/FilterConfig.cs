using System.Web;
using System.Web.Mvc;

namespace WebApp_BBM_CampaignPromo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
