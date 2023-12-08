using NongSanDungHa.Models.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NongSanDungHa.Areas.Admin.Controllers
{
    public class user_orderController : Controller
    {
        // GET: Admin/user_order
        DBConnection db = new DBConnection();
        // GET: Admin/product
        public ActionResult Index()
        {
            ListUser_Order proRe = new ListUser_Order();
            ViewBag.TotalUserOrder = proRe.getData().Count();
            List< user_order> list = proRe.getData().ToList();
            return View(list);
        }
        public ActionResult CreateNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateNew( user_order proRe)
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

        public ActionResult Edit_User_order(int id)
        {
            ListUser_Order list = new ListUser_Order();
            user_order item = list.Details(id).SingleOrDefault();

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit_User_order(user_order proRe)
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