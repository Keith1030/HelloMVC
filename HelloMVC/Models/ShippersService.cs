using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class ShippersService
    {
        Model1 db = new Model1();
        /// <summary>
        /// 查詢出貨公司
        /// </summary>
        public List<Models.Shippers> GetShippers()
        {
            return db.Shippers.ToList();
        }
    }
}