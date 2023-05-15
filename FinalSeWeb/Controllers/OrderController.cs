using FinalSeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalSeWeb.Controllers
{
    public class OrderController : Controller
    {
        FINAL_SEEntities db = new FINAL_SEEntities();

        // GET: Order
        public ActionResult Index()
        {
            string agent_Name = Session["agent_name"].ToString();
            List<ORDER_LIST_DETAILS> od = db.ORDER_LIST_DETAILS.Where(o => o.ORDER_LIST.UserName_Agent == agent_Name).ToList();
            return View(od);
        }
    }
}