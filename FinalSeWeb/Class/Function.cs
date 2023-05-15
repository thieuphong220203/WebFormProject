using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;
using FinalSeWeb.Models;

namespace FinalSeWeb.Class
{
	
	public static class Function
	{
		private static FINAL_SEEntities db = new FINAL_SEEntities();
		//Ham tang id cho Agent
		public static string AUTOID_AGENT()
		{
			string res = null;
			string maxAgentId = db.AGENTs.Max(a => a.Agent_ID);
			if (maxAgentId == null)
			{
				res = "AG" + "000000001";
			}
			else
			{
				int temp = int.Parse(maxAgentId.Substring(2, 9));
				temp++;
				res = String.Format("AG{0:000000000}", temp);
			}
			return res;
		}

        public static string AUTOID_OL()
        {
            string res = null;
            string maxOL = db.ORDER_LIST.Max(a => a.OrderList_ID);
            if (maxOL == null)
            {
                res = "OR" + "00000001";
            }
            else
            {
                int temp = int.Parse(maxOL.Substring(2, 8));
                temp++;
                res = String.Format("OR{0:00000000}", temp);
            }
            return res;
        }

		// =================<<describe>>====================
		public static string getMaxOrderList(string username)
		{
			string maxOrderList = db.ORDER_LIST.Where(o => o.UserName_Agent == username && o.Date_Created_OrderList == null).Max(o => o.OrderList_ID);
			return maxOrderList;
		}

		public static MOBILE_PRODUCT getProduct(string productID)
		{
			MOBILE_PRODUCT mb = db.MOBILE_PRODUCT.Where(o => o.Product_ID == productID).FirstOrDefault();
			return mb;
		}

		public static string getMaxOrderListIDNoNULL(string username)
		{
            string maxOrderList = db.ORDER_LIST.Where(o => o.UserName_Agent == username).Max(o => o.OrderList_ID);
            return maxOrderList;
        }

		public static bool checkDuplicateProduct(string productID, string maxOL)
		{
			ORDER_LIST_DETAILS dupPro = db.ORDER_LIST_DETAILS.Where(o => o.Product_ID == productID && o.OrderList_ID == maxOL).FirstOrDefault();
			if (dupPro != null)
			{
				return true;
			}
			return false;
		}

		public static ORDER_LIST_DETAILS GetORDER_LIST_DETAILS(string productID, string maxOL)
		{
			ORDER_LIST_DETAILS od = db.ORDER_LIST_DETAILS.Where(o => o.Product_ID == productID && o.OrderList_ID == maxOL).FirstOrDefault();

            return od;
		}

		public static AGENT getAgent(string agentID)
		{
			AGENT ag = db.AGENTs.Where(o => o.Agent_ID == agentID).FirstOrDefault();
			return ag;
		}

		

        public static List<ORDER_LIST_DETAILS> GetORDER_LIST(string agentName)
		{
            string max_order_list = getMaxOrderList(agentName);
            List<ORDER_LIST_DETAILS> od = db.ORDER_LIST_DETAILS.Where(o => o.ORDER_LIST.UserName_Agent == agentName
            && o.ORDER_LIST.Date_Created_OrderList == null && o.ORDER_LIST.OrderList_ID == max_order_list).ToList();
            return od;
		}

		public static MOBILE_PRODUCT getMobileProduct(string product_ID)
		{
			MOBILE_PRODUCT mb = db.MOBILE_PRODUCT.Where(o => o.Product_ID == product_ID).FirstOrDefault();
			return mb;
		}

		public static int getRemainProduct(string product_ID, int Quan)
		{
			
			MOBILE_PRODUCT mb = getMobileProduct(product_ID);
            int product_Quan = (int)mb.Product_Quantities;
			//int product_Quan = product_Quantities;
			int remain_Quan = product_Quan - Quan;
			return remain_Quan;
		}

		// ( 1 )
		public static void updateMobileProduct(string product_ID, int remain_Quan)
        {
			MOBILE_PRODUCT mb_product = new MOBILE_PRODUCT();

			MOBILE_PRODUCT mb = db.MOBILE_PRODUCT.Where(o => o.Product_ID == product_ID).FirstOrDefault();

            mb_product.Product_ID = mb.Product_ID;
            mb_product.Product_Name = mb.Product_Name;
            mb_product.TypeProduct_ID = mb.TypeProduct_ID;
            mb_product.Supplier_ID = mb.Supplier_ID;
            mb_product.Unit = mb.Unit;
            mb_product.Price = mb.Price;
            mb_product.Product_Quantities = remain_Quan;//
            mb_product.Image_Product = mb.Image_Product;
			db.Set<MOBILE_PRODUCT>().AddOrUpdate(mb_product);
			db.SaveChanges();

        }

		// ( 2 ) (1, 2)
		public static void updateOrderDetailsList(string orderID, string product_ID, int Quan)
        {

			int remain_quan = getRemainProduct(product_ID, Quan);
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

			ORDER_LIST_DETAILS od_List = new ORDER_LIST_DETAILS();

			ORDER_LIST_DETAILS od = db.ORDER_LIST_DETAILS.Where(o => o.OrderList_ID == orderID && o.Product_ID == product_ID).FirstOrDefault();

			od_List.Product_ID = od.Product_ID;
			od_List.OrderList_ID = od.OrderList_ID;
			od_List.Quantities = od.Quantities;
			od_List.Delivery_Date = tomorrow; //
			od_List.Total_Money = od.Total_Money;
			od_List.Remain_Quantities = remain_quan; //

			db.Set<ORDER_LIST_DETAILS>().AddOrUpdate(od_List);
			db.SaveChanges();

			updateMobileProduct(product_ID, remain_quan);

        }

        public static string AUTOID_IV()
        {
            string res = null;
            string maxOL = db.ORDER_LIST.Max(a => a.OrderList_ID);
            if (maxOL == null)
            {
                res = "IV" + "00000001";
            }
            else
            {
                int temp = int.Parse(maxOL.Substring(2, 8));
                temp++;
                res = String.Format("IV{0:00000000}", temp);
            }
            return res;
        }

        public static string AUTOID_TR()
        {
            string res = null;
            string maxOL = db.ORDER_LIST.Max(a => a.OrderList_ID);
            if (maxOL == null)
            {
                res = "TR" + "00000001";
            }
            else
            {
                int temp = int.Parse(maxOL.Substring(2, 8));
                temp++;
                res = String.Format("TR{0:00000000}", temp);
            }
            return res;
        }
        public static string AUTOID_GD()
        {
            string res = null;
            string maxOL = db.ORDER_LIST.Max(a => a.OrderList_ID);
            if (maxOL == null)
            {
                res = "GD" + "00000001";
            }
            else
            {
                int temp = int.Parse(maxOL.Substring(2, 8));
                temp++;
                res = String.Format("GD{0:00000000}", temp);
            }
            return res;
        }


        // (3) (3, 4, 5)
        public static void insertInvoice(string orderList_ID, string payment_ID)
		{
			INVOICE inv = new INVOICE();
            DateTime today = DateTime.Today;

            inv.Invoice_ID = AUTOID_IV();
			inv.OrderList_ID = orderList_ID;
			inv.Date_Created_Invoice = today;
			inv.Status_Invoice = "Completed";
            db.INVOICEs.Add(inv);
            db.SaveChanges();

			insertTransaction(inv.Invoice_ID, payment_ID, orderList_ID);
        }

		// 4
		public static void insertTransaction(string invoice_ID, string payment_ID, string orderList_ID)
		{
			TRANSACTION trans = new TRANSACTION();
            DateTime today = DateTime.Today;

            trans.Transaction_ID = AUTOID_TR();
			trans.PaymentMethod_ID = payment_ID;
			trans.Date_Created_Transaction = today;
			trans.Status_Transaction = "Finished";
			trans.Invoice_ID = invoice_ID;
			db.TRANSACTIONs.Add(trans);
			db.SaveChanges();

			insertGoodDelivery(trans.Transaction_ID, orderList_ID);

        }

		// 5

		public static void insertGoodDelivery(string transaction_ID, string orderlist_ID)
		{
			GOOD_DELIVERY gd = new GOOD_DELIVERY();
            DateTime today = DateTime.Today;

			gd.Good_Delivery_ID = AUTOID_GD();
			gd.Transaction_ID = transaction_ID;
			gd.Accountant_ID = null;
			gd.OrderList_ID = orderlist_ID;
			gd.Date_Created_Good_Delivery = today;

			db.GOOD_DELIVERY.Add(gd);
			db.SaveChanges();

		}
		
		// 6

		public static void updateOrderListDate(string agent_Name)
		{
			ORDER_LIST ol = new ORDER_LIST();
            DateTime today = DateTime.Today;
			string max_ID = getMaxOrderList(agent_Name);

			ORDER_LIST ol_db = db.ORDER_LIST.Where(o => o.UserName_Agent == agent_Name && o.OrderList_ID == max_ID).FirstOrDefault();

            ol.OrderList_ID = max_ID;
			ol.UserName_Customer = null;
			ol.UserName_Agent = ol_db.UserName_Agent;
			ol.Date_Created_OrderList = today;
			ol.Note = null;
			ol.Status_OrderList = null;

            db.Set<ORDER_LIST>().AddOrUpdate(ol);
            db.SaveChanges();
        }

		public static bool checkDateOrderList(string agent_Name)
		{
            string max_order_id = getMaxOrderList(agent_Name);
			ORDER_LIST or = db.ORDER_LIST.Where(o => o.UserName_Agent == agent_Name && o.Date_Created_OrderList == null && o.OrderList_ID == max_order_id).FirstOrDefault();
			if(or != null)
			{
				return true;
			}
			return false;
        }


        public static void deleteOrdeList(string agent_Name)
		{
			if (checkDateOrderList(agent_Name))
			{
				string max_order_id = getMaxOrderList(agent_Name);
				//            ORDER_LIST OrderDe = db.ORDER_LIST.FirstOrDefault(x => x.OrderList_ID == max_order_id);
				//            if (OrderDe != null)
				//            {
				//                db.ORDER_LIST.Remove(OrderDe);
				//                db.SaveChanges();
				//}
				var sqlCommand = "DELETE FROM ORDER_LIST WHERE OrderList_ID = @Id";
                var parameters = new SqlParameter[] { new SqlParameter("@Id", max_order_id) };
                db.Database.ExecuteSqlCommand(sqlCommand, parameters);

            }
		}

		public static bool checkOrderListDetails(string agent_Name)
		{
			ORDER_LIST ol = db.ORDER_LIST.Where(o => o.UserName_Agent == agent_Name && o.Date_Created_OrderList != null).FirstOrDefault();

			
			if(ol != null)
			{
				return true;
			}
			return false;
		} 

		public static bool checkAgentOD(string agent_Name) 
		{
			//ORDER_LIST ol = db.ORDER_LIST.Where(o => o.UserName_Agent == agent_Name
			//&& o.Date_Created_OrderList == null).FirstOrDefault();
			var query = (from ol in db.ORDER_LIST
						join old in db.ORDER_LIST_DETAILS on ol.OrderList_ID equals old.OrderList_ID
						where ol.UserName_Agent == agent_Name && ol.Date_Created_OrderList == null
						select new { OrderList = ol, OrderListDetails = old }).FirstOrDefault();
			//query = query.FirstOrDefault();



            //ORDER_LIST_DETAILS od = new ORDER_LIST_DETAILS();
            //foreach(var i in ol)
            //{
            //od = db.ORDER_LIST_DETAILS.Where(o => o.OrderList_ID == ol.OrderList_ID).FirstOrDefault();

            //}

            //var sqlCommand = "select * from ORDER_LIST, ORDER_LIST_DETAILS where ORDER_LIST.OrderList_ID = ORDER_LIST_DETAILS.OrderList_ID and ORDER_LIST.UserName_Agent = @username and ORDER_LIST.Date_Created_OrderList is null";
            //var parameters = new SqlParameter[] { new SqlParameter("@username", agent_Name) };
            //db.Database.ExecuteSqlCommand(sqlCommand, parameters);


            if (query != null)
			{
				return true;
			}
			return false;
		}
	}
}