using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class EmployeesService
    {
        Model1 db = new Model1();
        /// <summary>
        /// 查詢員工
        /// </summary>
        public List<Models.Employees> GetEmployees()
        {
            return db.Employees.ToList();
        }
    }
}