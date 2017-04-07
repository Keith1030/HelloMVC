﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
{
    public class OrdersController : Controller
    {
        /// <summary>
        /// 訂單管理系統首頁    
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 搜尋條件類別
        /// </summary>
        public class SearchCondition
        {
            public int OrderID { get; set; }
            public int CustomerID { get; set; }
            //public int EmployeeID { get; set; }
            //public string ShipCity { get; set; }
            //public DateTime OrderDate { get; set; }
            //public DateTime RequiredDate { get; set; }
        }
        /// <summary>
        /// 訂單管理系統首頁
        /// </summary>
        /// <returns></returns>
        public JsonResult Search(SearchCondition sc)
        {
            Models.OrdersService ordersService = new Models.OrdersService();
            if(sc.OrderID == 0)
                return Json(null, JsonRequestBehavior.AllowGet);
            List<Models.Orders> orders = ordersService.GetOrderByCondition(sc.OrderID);
            List<Object> results = new List<Object>();
            for (int i = 0; i < orders.Count; i++) {
                Models.Orders order = orders[i];
                results.Add(new
                {
                    OrderID = order.OrderID,
                    CustomerID = order.CustomerID,
                    EmployeeID = order.EmployeeID,
                    OrderDate = order.OrderDate.ToLongDateString(),
                    RequiredDate = order.RequiredDate.ToLongDateString(),
                    ShippedDate = order.ShippedDate,
                    ShipperID = order.ShipperID,
                    Freight = order.Freight,
                    ShipName = order.ShipName,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipRegion = order.ShipRegion,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipCountry = order.ShipCountry
                });
            }           
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增訂單的畫面
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertOrder()
        {
            return View();
        }
        /// <summary>
        /// 新增訂單存檔的Action
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult InsertOrder(Models.Orders order)
        {
            Models.OrdersService orderService = new Models.OrdersService();
            orderService.InsertOrder(order);
            return View("index");
        }
    }
}