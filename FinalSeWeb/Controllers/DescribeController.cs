using FinalSeWeb.Class;
using FinalSeWeb.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalSeWeb.Controllers
{
    public class DescribeController : Controller
    {
        FINAL_SEEntities db = new FINAL_SEEntities();
        // GET: Describe
        public ActionResult Describe()
        {
            var myValue = "";
            if (Request.QueryString["pID"] != null)
            {
                myValue = Request.QueryString["pID"];
                Session["product_ID"] = myValue;

            }
            myValue = Session["product_ID"].ToString();
            
            MOBILE_PRODUCT mobilePro = db.MOBILE_PRODUCT.FirstOrDefault(x => x.Product_ID == myValue);

            return View(mobilePro);
        }

       /* public ActionResult Add(string quanVal)
        {
            *//*ViewBag.Quantity = Quantity;
            return View(Quantity);*//*
            return RedirectToAction("OrderList", "List", new { quan = quanVal });
        }*/

        [HttpPost]
        public ActionResult Add()
        {
            string product_ID = Session["product_ID"].ToString();
            MOBILE_PRODUCT mb = Function.getProduct(product_ID);
            ORDER_LIST ol = new ORDER_LIST();
            ORDER_LIST_DETAILS od = new ORDER_LIST_DETAILS();
            string quantity = Request.Form["quantity"];
            string agentName = Session["agent_name"].ToString();
            // check product is out of stock
            if (mb.Product_Quantities < int.Parse(quantity))
            {
                return RedirectToAction("Describe", "Describe");
            }

            // check is paid ?
            if(Function.getMaxOrderList(agentName) == null)
            {
                string OL = Function.AUTOID_OL();
                ol.OrderList_ID = OL;
                ol.UserName_Agent = agentName;
                ol.UserName_Customer = null;
                ol.Date_Created_OrderList = null;
                ol.Note = null;
                ol.Status_OrderList = null;
                db.ORDER_LIST.Add(ol);
                db.SaveChanges();
            }

            // check order duplicate
            if(Function.checkDuplicateProduct(product_ID, Function.getMaxOrderListIDNoNULL(agentName)))
            {
                ORDER_LIST_DETAILS od_dup = Function.GetORDER_LIST_DETAILS(product_ID, Function.getMaxOrderListIDNoNULL(agentName));
                od.Product_ID = product_ID;
                od.OrderList_ID = Function.getMaxOrderListIDNoNULL(agentName);
                od.Quantities = od_dup.Quantities + int.Parse(quantity);//
                od.Delivery_Date = null;
                od.Total_Money = mb.Price * (od_dup.Quantities + int.Parse(quantity));//
                od.Remain_Quantities = mb.Product_Quantities;
                db.Set<ORDER_LIST_DETAILS>().AddOrUpdate(od);
                db.SaveChanges();
            }
            else
            {
                od.OrderList_ID = Function.getMaxOrderListIDNoNULL(agentName);
                od.Product_ID = product_ID;
                od.Quantities = int.Parse(quantity);
                od.Delivery_Date = null;
                od.Total_Money = mb.Price * int.Parse(quantity);
                od.Remain_Quantities = mb.Product_Quantities;
                db.ORDER_LIST_DETAILS.Add(od);
                db.SaveChanges();
            }
           
            
            return RedirectToAction("OrderList","List");
        }
        

    }
}