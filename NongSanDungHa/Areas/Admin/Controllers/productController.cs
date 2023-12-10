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
    public class productController : Controller
    {
        DBConnection db = new DBConnection();
        // GET: Admin/product
        public ActionResult Index(int ?page)
        {
            ListProduct pro = new ListProduct();
            ListProductCategory proCategory = new ListProductCategory();
            ViewBag.TotalProduct = pro.getData().Count();
            List<product> list = pro.getData().ToList();
            //Paged List
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<product>(list,pageNumber,pageSize);
            ViewBag.NameCategory = proCategory.getData().ToList();
            return View(lst);
        }
        public ActionResult CreateNew()
        {
            ListProductCategory category = new ListProductCategory();
            SelectList cateList = new SelectList(category.getData().ToList(), "product_category_id", "product_category_name");
            ViewBag.CategoryList = cateList;
            return View();
        }
        [HttpPost]
        public ActionResult CreateNew( product pro)
        {
            ListProduct list = new  ListProduct();
            pro.product_description = System.Net.WebUtility.HtmlDecode(pro.product_description);
           
            list.insert(pro);

            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id, int category_id)
        {
            ListProduct pro = new ListProduct();
             product product = pro.details(id,category_id).FirstOrDefault();
            return View(product);
        }
        public ActionResult Edit(int id, int category_id)
        {
           ListProduct list = new ListProduct();
            ListProductCategory category = new ListProductCategory();
            product item = list.details(id,category_id).FirstOrDefault();
            SelectList cateList = new SelectList(category.getData().ToList(), "product_category_id", "product_category_name");
            ViewBag.CategoryList = cateList;
            return View(item);
        }
        [HttpPost]
        
        public ActionResult Edit( product pro)
        {
            ListProduct list = new ListProduct();
            pro.product_description = System.Net.WebUtility.HtmlDecode(pro.product_description);
            list.update(pro);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id,int category_id)
        {
            ListProduct list = new ListProduct();
            product pro = list.details(id,category_id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Delete(product item)
        {
            ListProduct list = new ListProduct();
            
            var rs = list.delete(item.product_id);
            if (rs == 1)
            return RedirectToAction("Index");
            ViewBag.KT = 0;
            ViewBag.Message = "Dữ liệu này đang được sử dụng";
            product pro = list.details(item.product_id, item.product_category_id).SingleOrDefault();
            return View(pro);
        }
        public ActionResult SearchResult(int searchKey)
        {
            ListProduct list = new ListProduct();
            List<product> lstSearch = list.search(searchKey).ToList();
            ViewBag.searchKey = searchKey;
            return View(lstSearch);
        }
    }
}