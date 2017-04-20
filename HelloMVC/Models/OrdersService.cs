using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using static HelloMVC.Controllers.OrdersController;

namespace HelloMVC.Models
{
    public class OrdersService
    {
        Model1 db = new Model1();
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="order"></param>
        public void InsertOrder(Models.Orders order)
        {
            //todo
        }
        /// <summary>
        /// 依照Id 取得訂單資料
        /// </summary>
        /// <returns></returns>
        public Models.Orders GetOrderById(int orderId)
        {
            return db.Orders.Where(x => x.OrderID == orderId).FirstOrDefault();
        }
        /// <summary>
        /// 依照條件取得訂單資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Orders> GetOrderByCondition(SearchCondition sc)
        {
            
            return  db.Orders
                    .Where(x => sc.OrderID == null || x.OrderID == sc.OrderID)
                    .Where(x => sc.CustomerID == null || x.CustomerID == sc.CustomerID)
                    .Where(x => sc.EmployeeID == null || x.EmployeeID == sc.EmployeeID)
                    .Where(x => sc.ShipperID == null || x.ShipperID == sc.ShipperID)
                    .Where(x => sc.OrderDate == null || x.OrderDate == sc.OrderDate)
                    .Where(x => sc.RequiredDate == null || x.RequiredDate == sc.RequiredDate)
                    .ToList();
        }
        /// <summary>
        /// 刪除訂單
        /// </summary>
        public void DeleteOrderById(string orderId)
        {
            //todo
        }
        /// <summary>
        /// 更新訂單
        /// </summary>
        public int UpdateOrder(Models.Orders updateOrder)
        {
            var original = db.Orders.Where(x => x.OrderID == updateOrder.OrderID).FirstOrDefault();
            PropertyInfo[] properties = typeof(Models.Orders).GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(updateOrder) == null)
                    continue;
                property.SetValue(original, property.GetValue(updateOrder));
            }
            try
            {
                return db.SaveChanges();
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}