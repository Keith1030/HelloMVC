using System;
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
        /// 訂單管理系統首頁
        /// </summary>
        /// <returns></returns>
        //[HttpGet()]
        public JsonResult Search(string id)
        {
            Models.Orders order;
            //if (id != null)
            //{
                Models.OrdersService ordersService = new Models.OrdersService();
                order = ordersService.GetOrderById("10248");
            //}
            var result = new
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                EmployeeID = order.EmployeeID,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipperID = order.ShipperID,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            };
            return Json(result, JsonRequestBehavior.AllowGet);
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