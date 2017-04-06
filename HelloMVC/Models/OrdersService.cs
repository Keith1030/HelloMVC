using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public Models.Orders GetOrderById(string orderId)
        {
            int Id = Int32.Parse(orderId);
            var result = db.Orders.Where(x => x.OrderID == Id).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// 依照條件取得訂單資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Orders> GetOrderByCondition()
        {
            //todo
            List<Models.Orders> result = new List<Models.Orders>();
            return result;
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
        public void UpdateOrder(Models.Orders order)
        {
            //todo
        }
    }
}