using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class CustomersService
    {
        Model1 db = new Model1();
        /// <summary>
        /// 查詢顧客
        /// </summary>
        public List<Models.Customers> GetCustomers()
        {
            return db.Customers.ToList();
        }
    }
}