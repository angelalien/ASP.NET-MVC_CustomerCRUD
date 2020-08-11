using CustomerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    /// <summary>
    /// 客戶資料模型
    /// </summary>
    public class CustomersModel
    {
        /// <summary>
        /// 北風資料庫實體
        /// </summary>
        private NorthwindEntities db = new NorthwindEntities();

        /// <summary>
        /// 客戶清單
        /// </summary>
        public List<Customers> CustomerList { get;set;}

        /// <summary>
        /// 建構子
        /// </summary>
        public CustomersModel()
        {
            CustomerList = new List<Customers>();
        }

        /// <summary>
        /// 取得所有客戶清單
        /// </summary>
        /// <returns></returns>
        public List<Customers> GetCustomerList()
        {
            return db.Customers.ToList();
        }

        /// <summary>
        /// 表單
        /// </summary>
        public Customers Form { get; set; }

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="item"></param>
        public void Add(Customers item)
        {
            db.Customers.Add(item);
            db.SaveChanges();
        }

        /// <summary>
        /// 取得指定客戶資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customers GetCustomer(string id)
        {
            return db.Customers.SingleOrDefault(q => q.CustomerID == id);
        }

        /// <summary>
        /// 更新客戶資料
        /// </summary>
        /// <param name="item"></param>
        public void Update(Customers item)
        {
            var entity = db.Customers.SingleOrDefault(q => q.CustomerID == item.CustomerID);
            entity.CompanyName = item.CompanyName;
            entity.ContactName = item.ContactName;
            entity.Phone = item.Phone;
            entity.Country = item.Country;
            db.SaveChanges();
        }

        /// <summary>
        /// 刪除指定客戶資料
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            var entity = db.Customers.SingleOrDefault(q => q.CustomerID == id);
            db.Customers.Remove(entity);
            db.SaveChanges();
        }
    }
}