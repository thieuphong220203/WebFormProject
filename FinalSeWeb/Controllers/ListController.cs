using FinalSeWeb.Class;
using FinalSeWeb.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalSeWeb.Controllers
{
    public class ListController : Controller
    {
        FINAL_SEEntities db = new FINAL_SEEntities();
        // GET: List
        public ActionResult OrderList()
        {
            string agent_ID = Session["agent_ID"].ToString();

            AGENT agent = Function.getAgent(agent_ID);
            ViewBag.name = agent.Agent_Name;
            ViewBag.phone = agent.Agent_Phone;
            ViewBag.address = agent.Agent_Address;
            ViewBag.email = agent.Agent_Email;
            string agentName = Session["agent_name"].ToString();
            var myValue = Function.getMaxOrderList(agentName);
            List<ORDER_LIST_DETAILS> od = db.ORDER_LIST_DETAILS.Where(o => o.OrderList_ID == myValue).ToList();
            return View(od);
        }

        public ActionResult Remove()
        {
            string pID = Request.QueryString["pr"];
            string odID = Request.QueryString["od"];
            ORDER_LIST_DETAILS od = db.ORDER_LIST_DETAILS.Where(o => o.Product_ID == pID && o.OrderList_ID == odID).FirstOrDefault();
            db.ORDER_LIST_DETAILS.Remove(od);
            db.SaveChanges();
            return RedirectToAction("OrderList", "List");
        }

        public ActionResult OrderConfirm()
        {
            //var a = "";
            if (Request.QueryString["ol"] != null && Request.QueryString["PM"] != null)
            {
                string orderList_ID = Request.QueryString["ol"];
                string payment_ID = Request.QueryString["PM"];
                string agentName = Session["agent_name"].ToString();

                if(payment_ID == "PM001")
                {
                    return Redirect("https://sandbox.vnpayment.vn/merchant_webapi/api/transaction");
                }

                foreach (var item in Function.GetORDER_LIST(agentName))
                {
                    string proID = item.Product_ID;
                    int Quan = (int)item.Quantities;

                    Function.updateOrderDetailsList(orderList_ID, proID, Quan);
                }
                Function.insertInvoice(orderList_ID, payment_ID);

                Function.updateOrderListDate(agentName);

                return RedirectToAction("Index", "Order");

            }
            return RedirectToAction("OrderList", "List");

        }


    }
}