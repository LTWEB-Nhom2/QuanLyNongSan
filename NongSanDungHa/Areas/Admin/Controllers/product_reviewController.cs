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
    public class product_reviewController : Controller
    {
        // GET: Admin/product_review
        DBConnection db = new DBConnection();
        // GET: Admin/product
        public ActionResult Index(int? page)
        {
            ListProduct_review proRe = new ListProduct_review();
            ViewBag.TotalProductReview = proRe.getData().Count();
            List< product_review> list = proRe.getData().ToList();
            //Page List
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<product_review>(list, pageNumber, pageSize);
            return View(lst);
        }
        //public ActionResult CreateNew()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult CreateNew( product_review proRe)
        //{
        //    ListProduct_review list = new ListProduct_review();
        //    list.insert(proRe);

        //    return RedirectToAction("Index");
        //}
        public ActionResult Detail(int id)
        {
            ListProduct_review list = new ListProduct_review();
             product_review proRe = list.Details(id).FirstOrDefault();
            return View(proRe);
        }
        //public ActionResult Edit(int id)
        //{
        //    ListProduct_review list = new ListProduct_review();
        //     product_review item = list.Details(id).FirstOrDefault();

        //    return View(item);
        //}
        //[HttpPost]
        //public ActionResult Edit( product_review proRe)
        //{
        //    ListProduct_review list = new ListProduct_review();
        //    list.update(proRe);
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id)
        {
            ListProduct_review list = new ListProduct_review();

            list.delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult SearchResult(int searchKey)
        {
            ListProduct_review list = new ListProduct_review();
            List<product_review> lstSearch = list.getProductReview(searchKey).ToList();
            ViewBag.searchKey = searchKey;
            return View(lstSearch);
        }
    }
}