using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using FinalSeWeb.Models;
using FinalSeWeb.Class;

namespace FinalSeWeb.Controllers
{
	public class HomeController : Controller
	{
		
        public ActionResult Index()
        {
            FINAL_SEEntities db = new FINAL_SEEntities();

            List<MOBILE_PRODUCT> products = db.MOBILE_PRODUCT.ToList();

            return View(products);
        }

       
        
        
    }
}