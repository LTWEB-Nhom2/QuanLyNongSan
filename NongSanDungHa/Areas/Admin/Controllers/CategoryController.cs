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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        DBConnection db = new DBConnection();
        // GET: Admin/product
        public ActionResult Index(int? page)
        {
            ListProductCategory pro = new ListProductCategory();
            ViewBag.TotalCategory = pro.getData().Count();
            List<product_category> list = pro.getData().ToList();
            //Page List
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<product_category>(list, pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult CreateNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateNew( product_category cate)
        {
            ListProductCategory list = new ListProductCategory();
            list.insert(cate);

            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            ListProductCategory cate = new ListProductCategory();
             product_category category = cate.Details(id).FirstOrDefault();
            return View(category);
        }
        public ActionResult Edit(int id)
        {
            ListProductCategory list = new ListProductCategory();
             product_category item = list.Details(id).FirstOrDefault();

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit( product_category cate)
        {
            ListProductCategory list = new ListProductCategory();
            list.update(cate);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ListProductCategory list = new ListProductCategory();
            product_category cate = list.Details(id).FirstOrDefault();
            return View(cate);
        }
        [HttpPost]
        public ActionResult Delete(product_category cate)
        {
            ListProductCategory list = new ListProductCategory();

            var rs = list.delete(cate.product_category_id);
            if (rs == 1)
            {
                return RedirectToAction("Index");
            }
            ViewBag.KT = 0;
            ViewBag.Message = "Xóa thất bại do dữ liệu đang được sử dụng";
            product_category cate1 = list.Details(cate.product_category_id).FirstOrDefault();
            return View(cate1);
           
        }
        public ActionResult SearchResult(int searchKey)
        {
            ListProductCategory list = new ListProductCategory();
            List<product_category> lstSearch = list.search(searchKey).ToList();
            ViewBag.searchKey = searchKey;
            return View(lstSearch);
        }
    }
}