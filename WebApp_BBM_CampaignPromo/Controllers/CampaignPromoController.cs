using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_BBM_CampaignPromo.DataAccess;
using WebApp_BBM_CampaignPromo.Models.CampaignPromo;

namespace WebApp_BBM_CampaignPromo.Controllers
{
    public class CampaignPromoController : Controller
    {
        private string uid = "admin";
        // GET: CampaignPromo
        public ActionResult Index()
        {
            //get store
            var ls_store = DataAccess.DataAccess.sp_BBM_CampaignPromo_Store_get( uid);
            ViewBag.ls_store = ls_store;

            return View();
        }

        public ActionResult Create(string storeNo)
        {

            storeNo = "10002";

            ViewBag.storeNo = storeNo;

            //get store
            var ls_store = DataAccess.DataAccess.sp_BBM_CampaignPromo_Store_get( uid);
            ViewBag.ls_store = ls_store;

            //getItem
            var ls_all_it = DataAccess.DataAccess.sp_BBM_CampaignPromo_ItemCore_get( uid, new ItemCore { storeNo = storeNo });

            Session["ls_all_it"] = ls_all_it;

            var ls_mainPrd = ls_all_it.Where(s => s.isGift == "N").ToList();
            ViewBag.ls_mainPrd = ls_mainPrd;

            var ls_promoPrd = ls_all_it.Where(s => s.isGift == "Y").ToList();
            ViewBag.ls_promoPrd = ls_promoPrd;
            




            return View();


        }

        public ActionResult Detail(string id)
        {
            //get heeader
            var hd = DataAccess.DataAccess.sp_BBM_CampaignPromo_Header_get( uid, new HeaderItem { id = id });
            ViewBag.header = hd;

            //get mainPrd
            var m_prd = DataAccess.DataAccess.sp_BBM_CampaignPromo_MainProduct_get( uid, new MainItem { headerId = id });
            ViewBag.m_prd = m_prd;

            //get promoPrd
            var p_prd = DataAccess.DataAccess.sp_BBM_CampaignPromo_PromoProduct_get( uid, new PromoItem { headerId = id });
            ViewBag.p_prd = m_prd;

            return View();
        }

        public ActionResult Edit(string id)
        {
            //get heeader
            var hd = DataAccess.DataAccess.sp_BBM_CampaignPromo_Header_get( uid, new HeaderItem { id = id });
            ViewBag.header = hd;

            //get mainPrd
            var m_prd = DataAccess.DataAccess.sp_BBM_CampaignPromo_MainProduct_get( uid, new MainItem { headerId = id });
            ViewBag.m_prd = m_prd;

            //get promoPrd
            var p_prd = DataAccess.DataAccess.sp_BBM_CampaignPromo_PromoProduct_get( uid, new PromoItem { headerId = id });
            ViewBag.p_prd = m_prd;

            //getItem
            var ls_all_it = DataAccess.DataAccess.sp_BBM_CampaignPromo_ItemCore_get( uid, new ItemCore { storeNo = hd[0].storeNo });

            var ls_mainPrd = ls_all_it.Where(s => s.isGift == "N").ToList();
            ViewBag.ls_mainPrd = ls_mainPrd;

            var ls_promoPrd = ls_all_it.Where(s => s.isGift == "Y").ToList();
            ViewBag.ls_promoPrd = ls_promoPrd;

            return View();
        }

        public ActionResult Accept()
        {
            return View();
        }


        [HttpPost]
        public ActionResult getHeader(HeaderItem it)
        {
            try
            {
                var bn = DataAccess.DataAccess.sp_BBM_CampaignPromo_Header_get( uid, it);
                return Json(bn);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getHeader");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult getItem(ItemCore it)
        {
            try
            {
                //var bn = DataAccess.DataAccess.sp_BBM_CampaignPromo_ItemCore_get( uid, it);
                var ls_all_it = (List<ItemCore>)Session["ls_all_it"];
                var bn = ls_all_it.FirstOrDefault(s => s.itemNo == it.itemNo);

                return Json(bn);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getItem");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult createPromo(HeaderItem hea, List<MainItem> main, List<PromoItem> promo)
        {
            try
            {
                //add Header
                var add_hea = DataAccess.DataAccess.sp_BBM_CampaignPromo_Header_add( uid, hea);

                //add main
                foreach (var i in main)
                {
                    var add_main = DataAccess.DataAccess.sp_BBM_CampaignPromo_MainProduct_add( uid, i);
                }


                //add pro
                foreach (var j in promo)
                {
                    var add_pro = DataAccess.DataAccess.sp_BBM_CampaignPromo_PromoProduct_add( uid, j);
                }


                return Json(new { code = 0, content = "0" });
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "createPromo");
                return Json(new { code = 1, content = "1" });
            }
        }
    }
}