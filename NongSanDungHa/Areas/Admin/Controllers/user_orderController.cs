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
    public class user_orderController : Controller
    {
        // GET: Admin/user_order
        DBConnection db = new DBConnection();
        // GET: Admin/product
        public ActionResult Index(int? page)
        {
            ListUser_Order proRe = new ListUser_Order();
            ViewBag.TotalUserOrder = proRe.getData().Count();
            List<user_order> list = proRe.getData().ToList();
            //Page List
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<user_order>(list, pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult CreateNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateNew(user_order proRe)
        {
            ListUser_Order list = new ListUser_Order();
            list.insert(proRe);

            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            ListUser_Order_Product order_product = new ListUser_Order_Product();
            List<user_order_product> listSP = order_product.getSoSanPham(id).ToList();
            ListProduct pro = new ListProduct();
            ViewBag.Product = pro.getData().ToList();
            return View(listSP);
        }
        public ActionResult Edit(int id)
        {
            ListUser_Order list = new ListUser_Order();
            user_order item = list.Details(id).SingleOrDefault();

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(user_order proRe)
        {
            ListUser_Order list = new ListUser_Order();
            list.update(proRe);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ListUser_Order list = new ListUser_Order();

            list.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SearchResult(int searchKey)
        {
            ListUser_Order list = new ListUser_Order();
            List<user_order> lstSearch = list.getUserOrder(searchKey).ToList();
            ViewBag.searchKey = searchKey;
            return View(lstSearch);
        }

    }
}