using System.Linq;
using System.Web.Mvc;
using WebApp_BBM_CampaignPromo.DB;
using WebApp_BBM_CampaignPromo.Models;

namespace WebApp_BBM_CampaignPromo.Controllers
{
    public class TestController : Controller
    {
        DBTHUCTAP DB = new DBTHUCTAP();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult CHNR()
        {
            var list = DB.tbl_Bill.ToList();

            Test obj = new Test();
            obj.ListBill = list;

            return View(obj);
        }
    }
}