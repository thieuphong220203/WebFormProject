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
	
	public class LoginController : Controller
    {
		FINAL_SEEntities db = new FINAL_SEEntities(); //Mo Ket Noi voi DB
		// GET: Login
		public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }else
            {
				return RedirectToAction("Index", "Home");
			}
			
		}

        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AGENT_ACCOUNT acc)
        {
            
            AGENT_ACCOUNT agent = db.AGENT_ACCOUNT.FirstOrDefault(x => x.UserName == acc.UserName
                                   && x.Account_Password == acc.Account_Password);
            if (acc != null)
            {
                Session["user"] = agent;

                //if (Session["agent_ID"] == null)
                //{
                //    TempData["Error"] = "Wrong password or UserName";
                //    return View();
                //}

                if (agent == null)
                {
                    TempData["Error"] = "Wrong password or UserName";
                    return View();
                }

                Session["agent_ID"] = agent.Agent_ID;
                Session["agent_name"] = agent.UserName;

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Username or Password is invalid!!";
                return View();
            }
        }


        public ActionResult Logout()
        {
            Session.Clear();
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
		public ActionResult Update()
        {
            
            var session = (AGENT_ACCOUNT)HttpContext.Session["user"];
            var user = db.AGENT_ACCOUNT.FirstOrDefault(x => x.UserName == session.UserName);

            if(user == null)
            {
                return RedirectToAction("Login");

            }
            List<string> AgentsID = db.AGENTs.Where(agent => agent.Agent_ID == user.Agent_ID)
                .Select(agent => agent.Agent_ID).ToList();
            ViewBag.listAgent = new SelectList(AgentsID);
            AGENT listAgents = db.AGENTs.FirstOrDefault(x=>x.Agent_ID == session.Agent_ID);
            ViewBag.listAgents = listAgents;
			return View(user);
        }

        [HttpPost]
        public ActionResult Update(AGENT_ACCOUNT acc ,AGENT agent)
        {
            try
            {
				
				var session = (AGENT_ACCOUNT)HttpContext.Session["user"];
				var user = db.AGENT_ACCOUNT.FirstOrDefault(x => x.UserName == session.UserName);
                var agentInfo = db.AGENTs.FirstOrDefault(x => x.Agent_ID == session.Agent_ID);
				if (user == null)
				{
					return RedirectToAction("Login");
				}

				user.Account_Password = acc.Account_Password;
                agentInfo.Agent_Name = agent.Agent_Name;
                agentInfo.Agent_Address = agent.Agent_Address;
                agentInfo.Agent_Email = agent.Agent_Email;
                agentInfo.Agent_Phone = agent.Agent_Phone;

				db.SaveChanges();
				TempData["SuccessMessage"] = "Update successful!";
				return RedirectToAction("Update", new { success = true });
			}
			catch (Exception ex)
            {
				TempData["errorMessage"] = "An error occurred while updating the account password.";
				return View();
            }
        }
        
		[HttpGet]
        public ActionResult Register()
        {
            TempData.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Register( AGENT_ACCOUNT acc,AGENT agent)
        {
			List<checkExistedAgent_Result> check = db.checkExistedAgent(acc.UserName).ToList();

                if (check.Count == 0)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    
                    string newUserID = Function.AUTOID_AGENT();

                    AGENT_ACCOUNT newAccount = new AGENT_ACCOUNT();
                    AGENT newAgent = new AGENT();
                    newAgent.Agent_ID = newUserID;
                    newAgent.Agent_Name = agent.Agent_Name;
                    newAgent.Agent_Address = agent.Agent_Address;
                    newAgent.Agent_Email = agent.Agent_Email;
                    newAgent.Agent_Phone = agent.Agent_Phone;

                    db.AGENTs.Add(newAgent);
				    db.SaveChanges();

                    newAccount.UserName = acc.UserName;
                    newAccount.Agent_ID = newUserID;
                    newAccount.Account_Password = acc.Account_Password;
                    newAccount.Agent_Level = 1;
                    db.AGENT_ACCOUNT.Add(newAccount);
                    db.SaveChanges();

                    TempData["SuccessRegister"] = "Register successful!";
                    /*TempData.Keep("SuccessRegister");*/
                    return RedirectToAction("Login");
            }
            else
                {
                    ViewBag.error = "Email or UserName exist! Try Again";
                }
            
            return View();
        }


    }
}