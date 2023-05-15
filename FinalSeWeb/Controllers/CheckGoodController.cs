using FinalSeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalSeWeb.Controllers
{
    public class CheckGoodController : Controller
    {
        FINAL_SEEntities db = new FINAL_SEEntities();
        // GET: CheckGood
        public ActionResult Index()
        {
            string pID = Request.QueryString["pid"];
            string olID = Request.QueryString["ol"];
            ORDER_LIST_DETAILS od = db.ORDER_LIST_DETAILS.Where(o => o.Product_ID == pID && o.OrderList_ID == olID).FirstOrDefault();
            return View(od);
        }
    }
}