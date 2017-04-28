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
            Models.CustomersService cs = new Models.CustomersService();
            ViewBag.customers= cs.GetCustomers();
            Models.EmployeesService es = new Models.EmployeesService();
            ViewBag.employees = es.GetEmployees();
            Models.ShippersService ss = new Models.ShippersService();
            ViewBag.shippers = ss.GetShippers();
            return View();
        }
        /// <summary>
        /// 搜尋條件類別
        /// </summary>
        public class SearchCondition
        {
            public int? OrderID { get; set; }
            public int? CustomerID { get; set; }
            public int? EmployeeID { get; set; }
            public int? ShipperID { get; set; }
            public DateTime? OrderDate { get; set; }
            public DateTime? RequiredDate { get; set; }
        }
        /// <summary>
        /// 訂單管理系統首頁
        /// </summary>
        /// <returns></returns>
        public JsonResult Search(SearchCondition sc)
        {
            Models.OrdersService ordersService = new Models.OrdersService();          
            List<Models.Orders> orders = ordersService.GetOrderByCondition(sc);
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
                    ShippedDate = (order.ShippedDate.HasValue)?order.ShippedDate.GetValueOrDefault().ToLongDateString():null,             
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
            Models.CustomersService cs = new Models.CustomersService();
            ViewBag.customers = cs.GetCustomers();
            Models.EmployeesService es = new Models.EmployeesService();
            ViewBag.employees = es.GetEmployees();
            Models.ShippersService ss = new Models.ShippersService();
            ViewBag.shippers = ss.GetShippers();
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
        /// <summary>
        /// 修改訂單的Action
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public ActionResult UpdateOrder(Models.Orders updateOrder)
        {
            Models.OrdersService orderService = new Models.OrdersService();
            int rows = orderService.UpdateOrder(updateOrder);
            var results = new { result = (rows > 0)?"成功":"失敗",
                                orderID = updateOrder.OrderID,
                                rows = rows};
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteOrder(int orderID)
        {
            Models.OrdersService orderService = new Models.OrdersService();
            int rows = orderService.DeleteOrderById(orderID);
            var results = new
            {
                result = (rows > 0) ? "成功" : "失敗",
                orderID = orderID,
                rows = rows
            };
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}