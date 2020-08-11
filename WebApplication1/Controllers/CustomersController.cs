using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            CustomersModel model = new CustomersModel();
            model.CustomerList = model.GetCustomerList();
            return View(model);
        }

        [HttpGet]//新增頁面
        public ActionResult Create()
        {
            CustomersModel model = new CustomersModel();
            return View(model);
        }

        [HttpPost]//執行新增
        public ActionResult Create(CustomersModel model)
        {
            model.Add(model.Form);
            return RedirectToAction("index");
        }

        [HttpGet]//更新頁面
        public ActionResult Details(string id)
        {
            CustomersModel model = new CustomersModel();
            model.Form = model.GetCustomer(id);
            return View(model);
        }

        [HttpPost]//執行更新
        public ActionResult Update(CustomersModel model)
        {
            model.Update(model.Form);
            return RedirectToAction("index");
        }

        [HttpGet]//刪除頁面
        public ActionResult Delete(string id)
        {
            CustomersModel model = new CustomersModel();
            model.Form = model.GetCustomer(id);
            return View(model);
        }

        [HttpPost]//執行刪除
        public ActionResult Delete(CustomersModel model)
        {
            model.Delete(model.Form.CustomerID);
            return RedirectToAction("index");
        }
    }
}