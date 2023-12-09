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
    public class user_order_productController : Controller
    {
        // GET: Admin/user_order_product
        DBConnection db = new DBConnection();
        // GET: Admin/product
        public ActionResult Index(int? page)
        {
            ListUser_Order_Product proRe = new ListUser_Order_Product();
            ViewBag.TotalUserOrderProduct = proRe.getData().Count();
            List<user_order_product> list = proRe.getData().ToList();
            //Page List
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<user_order_product>(list, pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult CreateNew()
        {
            ListProduct pro = new ListProduct();
            SelectList cateList = new SelectList(pro.getData().ToList(), "product_id", "product_name");
            ViewBag.ProductList = cateList;
            return View();
        }
        [HttpPost]
        public ActionResult CreateNew(user_order_product proRe)
        {
            ListProduct listP = new ListProduct();
            proRe.product_name = listP.getData().SingleOrDefault(x=> x.product_id == proRe.product_id).product_name;
            ListUser_Order_Product list = new ListUser_Order_Product();
            list.insert(proRe);

            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id, int product_id)
        {
            ListUser_Order_Product list = new ListUser_Order_Product();
            user_order_product proRe = list.Details(id, product_id).FirstOrDefault();
            return View(proRe);
        }
        public ActionResult Edit(int id, int product_id)
        {
            ListUser_Order_Product list = new ListUser_Order_Product();
            user_order_product item = list.Details(id, product_id).FirstOrDefault();

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(user_order_product proRe)
        {
            ListUser_Order_Product list = new ListUser_Order_Product();
            list.update(proRe);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id, int product_id)
        {
            ListUser_Order_Product list = new ListUser_Order_Product();

            list.delete(id, product_id);
            return RedirectToAction("Index");
        }
        public ActionResult SearchResult(int searchKey)
        {
            ListUser_Order_Product list = new ListUser_Order_Product();
            List<user_order_product> lstSearch = list.getUserOrderProduct(searchKey).ToList();
            ViewBag.searchKey = searchKey;
            return View(lstSearch);
        }
    }
}