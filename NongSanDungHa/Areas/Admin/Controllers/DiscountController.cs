using NongSanDungHa.Models.ADO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace NongSanDungHa.Areas.Admin.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Admin/Discount
        DBConnection db = new DBConnection();
        // GET: Admin/product
        public ActionResult Index(int? page)
        {
            ListDiscountEvent pro = new ListDiscountEvent();
            ViewBag.TotalDiscount = pro.getData().Count();
            List<product_discount_event> list = pro.getData().ToList();
            //Page List
            int pageSize = 3;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<product_discount_event>(list, pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult CreateNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateNew(product_discount_event disc)
        {
            ListDiscountEvent list = new ListDiscountEvent();
            list.insert(disc);

            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            ListDiscountEvent disc = new ListDiscountEvent();
            product_discount_event item = disc.Details(id).FirstOrDefault();
            return View(item);
        }
        public ActionResult Edit(int id)
        {
            ListDiscountEvent list = new ListDiscountEvent();
            product_discount_event item = list.Details(id).FirstOrDefault();

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(product_discount_event disc)
        {
            ListDiscountEvent list = new ListDiscountEvent();
            list.update(disc);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ListDiscountEvent list = new ListDiscountEvent();

            list.delete(id);
            return RedirectToAction("Index");
        }
    }
}