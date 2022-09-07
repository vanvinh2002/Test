using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApp_BBM_CampaignPromo.Models;
using WebApp_BBM_CampaignPromo.Models.CampaignPromo;

namespace WebApp_BBM_CampaignPromo.DataAccess
{
    public static class DataAccess
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strCon_51_BBM_CampaignPromo");

        public static List<PointItem> sp_BBM_Partner_Bixu_Account( PointItem it)
        {
            List<PointItem> its = new List<PointItem>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();


                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_Partner_Bixu_Account", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("AccountNo", it.AccountNo));
                    cmd.Parameters.Add(new SqlParameter("CardNo", it.CardNo));
                    cmd.Parameters.Add(new SqlParameter("PhoneNo", it.PhoneNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PointItem su = new PointItem
                        {
                            AccountNo = reader["AccountNo"].ToString(),
                            CardNo = reader["CardNo"].ToString(),
                            PhoneNo = reader["PhoneNo"].ToString(),
                            points = reader["points"].ToString()
                        };


                        its.Add(su);
                    }
                    con.Close();

                    return its;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_Partner_Bixu_Account");
                    return its;
                }
            }
        }


        #region CampaignPromo

        #region Action_Get
        public static List<HeaderItem> sp_BBM_CampaignPromo_Header_get( string uid, HeaderItem it)
        {
            List<HeaderItem> it_r = new List<HeaderItem>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_Header_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("status", it.status));
                    cmd.Parameters.Add(new SqlParameter("startDate", it.startDate));
                    cmd.Parameters.Add(new SqlParameter("endDate", it.endDate));
                    cmd.Parameters.Add(new SqlParameter("Description",it.Description));


                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HeaderItem it_ = new HeaderItem
                        {
                            id = reader["id"].ToString(),
                            storeNo = reader["storeNo"].ToString(),
                            Name = reader["Name"].ToString(),
                            startDate = reader["startDate"].ToString(),
                            endDate = reader["endDate"].ToString(),
                            ActivedDayOfWeek = reader["ActivedDayOfWeek"].ToString(),
                            Description = reader["Description"].ToString(),
                            maximumGanranti = reader["maximumGanranti"].ToString(),
                            MainProductType = reader["MainProductType"].ToString(),
                            PromoProductType = reader["PromoProductType"].ToString(),
                            status = reader["status"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),


                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_CampaignPromo_Header_get");
                    return it_r;
                }
            }
        }

        public static List<ItemCore> sp_BBM_CampaignPromo_ItemCore_get( string uid, ItemCore it)
        {
            List<ItemCore> it_r = new List<ItemCore>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_ItemCore_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ItemCore it_ = new ItemCore
                        {
                            storeNo = reader["storeNo"].ToString(),
                            itemNo = reader["itemNo"].ToString(),
                            stockQty = reader["stockQty"].ToString(),
                            itemName = reader["itemName"].ToString(),
                            Uom = reader["Uom"].ToString(),
                            divCode = reader["divCode"].ToString(),
                            catCode = reader["catCode"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            funcCode = reader["funcCode"].ToString(),
                            isGift = reader["isGift"].ToString(),
                            salePrice = reader["salePrice"].ToString(),

                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_CampaignPromo_ItemCore_get");
                    return it_r;
                }
            }
        }

        public static List<MainItem> sp_BBM_CampaignPromo_MainProduct_get( string uid, MainItem it)
        {
            List<MainItem> it_r = new List<MainItem>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_MainProduct_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.headerId));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MainItem it_ = new MainItem
                        {
                            id = reader["id"].ToString(),
                            headerId = reader["headerId"].ToString(),
                            itemNo = reader["itemNo"].ToString(),
                            itemName = reader["itemName"].ToString(), 
                            UoM = reader["UoM"].ToString(),
                            salesPrices = reader["salesPrices"].ToString(),
                            discountPrice = reader["discountPrice"].ToString(),
                            discountType = reader["discountType"].ToString(),
                            discountValue = reader["discountValue"].ToString(),
                            Quantity = reader["Quantity"].ToString(),
                            status = reader["status"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),

                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_CampaignPromo_MainProduct_get");
                    return it_r;
                }
            }
        }

        public static List<PromoItem> sp_BBM_CampaignPromo_PromoProduct_get( string uid, PromoItem it)
        {
            List<PromoItem> it_r = new List<PromoItem>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_PromoProduct_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.headerId));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PromoItem it_ = new PromoItem
                        {
                            id = reader["id"].ToString(),
                            headerId = reader["headerId"].ToString(),
                            itemNo = reader["itemNo"].ToString(),
                            itemName = reader["itemName"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            salesPrices = reader["salesPrices"].ToString(),
                            stockQty = reader["stockQty"].ToString(),
                            Quantity = reader["Quantity"].ToString(),
                            status = reader["status"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),


                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_CampaignPromo_PromoProduct_get");
                    return it_r;
                }
            }
        }

        public static List<RoleItem> sp_BBM_CampaignPromo_RoleControl_get( string uid)
        {
            List<RoleItem> it_r = new List<RoleItem>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_RoleControl_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        RoleItem it_ = new RoleItem
                        {
                            roleCode = reader["roleCode"].ToString(),
                            controlCode = reader["controlCode"].ToString(),
                            create_act = reader["create_act"].ToString(),
                            view_act = reader["view_act"].ToString(),
                            edit_act = reader["edit_act"].ToString(),
                            accept_act = reader["accept_act"].ToString(),
                            root_act = reader["root_act"].ToString(),

                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_CampaignPromo_RoleControl_get");
                    return it_r;
                }
            }
        }

        public static List<selectItem> sp_BBM_CampaignPromo_Store_get( string uid)
        {
            List<selectItem> it_r = new List<selectItem>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_Store_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        selectItem it_ = new selectItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),

                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_CampaignPromo_Store_get");
                    return it_r;
                }
            }
        }
        #endregion

        #region Modify

        public static bool sp_BBM_CampaignPromo_Header_add( string uid, HeaderItem it)
        {

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    
                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_Header_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.id));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("Name", it.Name));
                    cmd.Parameters.Add(new SqlParameter("startDate", it.startDate));
                    cmd.Parameters.Add(new SqlParameter("endDate", it.endDate));
                    cmd.Parameters.Add(new SqlParameter("ActivedDayOfWeek", it.ActivedDayOfWeek));
                    cmd.Parameters.Add(new SqlParameter("Description", it.Description));
                    cmd.Parameters.Add(new SqlParameter("maximumGanranti", it.maximumGanranti));
                    cmd.Parameters.Add(new SqlParameter("MainProductType", it.MainProductType));
                    cmd.Parameters.Add(new SqlParameter("PromoProductType", it.PromoProductType));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();

                    LogBuild.CreateLogger("Error: " + ex.ToString(), "sp_BBM_CampaignPromo_Header_add");
                    return false;
                }
            }
        }

        public static bool sp_BBM_CampaignPromo_MainProduct_add( string uid, MainItem it)
        {

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {


                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_MainProduct_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.headerId));
                    cmd.Parameters.Add(new SqlParameter("itemNo", it.itemNo));
                    cmd.Parameters.Add(new SqlParameter("UoM", it.UoM));
                    cmd.Parameters.Add(new SqlParameter("salesPrices", it.salesPrices));
                    cmd.Parameters.Add(new SqlParameter("discountPrice", it.discountPrice));
                    cmd.Parameters.Add(new SqlParameter("discountType", it.discountType));
                    cmd.Parameters.Add(new SqlParameter("discountValue", it.discountValue));
                    cmd.Parameters.Add(new SqlParameter("Quantity", it.Quantity));



                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();

                    LogBuild.CreateLogger("Error: " + ex.ToString(), "sp_BBM_CampaignPromo_MainProduct_add");
                    return false;
                }
            }
        }

        public static bool sp_BBM_CampaignPromo_PromoProduct_add( string uid, PromoItem it)
        {

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {


                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_PromoProduct_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.headerId));
                    cmd.Parameters.Add(new SqlParameter("itemNo", it.itemNo));
                    cmd.Parameters.Add(new SqlParameter("UoM", it.UoM));
                    cmd.Parameters.Add(new SqlParameter("salesPrices", it.salesPrices));
                    cmd.Parameters.Add(new SqlParameter("stockQty", it.stockQty));
                    cmd.Parameters.Add(new SqlParameter("Quantity", it.Quantity));




                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();

                    LogBuild.CreateLogger("Error: " + ex.ToString(), "sp_BBM_CampaignPromo_PromoProduct_add");
                    return false;
                }
            }
        }

        public static bool sp_BBM_CampaignPromo_Header_accept( string uid, HeaderItem it)
        {

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {


                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_Header_accept", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.id));
                    cmd.Parameters.Add(new SqlParameter("status", it.status));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();

                    LogBuild.CreateLogger("Error: " + ex.ToString(), "sp_BBM_CampaignPromo_Header_accept");
                    return false;
                }
            }
        }

        public static bool sp_BBM_CampaignPromo_MainProduct_clean( string uid, MainItem it,string ls_Item)
        {

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {


                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_MainProduct_clean", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.headerId));
                    cmd.Parameters.Add(new SqlParameter("ls_Item", ls_Item));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();

                    LogBuild.CreateLogger("Error: " + ex.ToString(), "sp_BBM_CampaignPromo_MainProduct_clean");
                    return false;
                }
            }
        }

        public static bool sp_BBM_CampaignPromo_PromoProduct_clean( string uid, PromoItem it, string ls_Item)
        {

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {


                    SqlCommand cmd = new SqlCommand("sp_BBM_CampaignPromo_PromoProduct_clean", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.headerId));
                    cmd.Parameters.Add(new SqlParameter("ls_Item", ls_Item));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();

                    LogBuild.CreateLogger("Error: " + ex.ToString(), "sp_BBM_CampaignPromo_PromoProduct_clean");
                    return false;
                }
            }
        }
        #endregion


        #endregion
    }
}
