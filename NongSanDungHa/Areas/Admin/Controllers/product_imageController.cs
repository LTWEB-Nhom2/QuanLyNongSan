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
    public class product_imageController : Controller
    {
        // GET: Admin/product_image
        DBConnection db = new DBConnection();
        // GET: Admin/product
        public ActionResult Index(int? page)
        {
            ListProductImage proImg = new ListProductImage();
            ViewBag.TotalProductImage = proImg.getData().Count();
            List<product_image> list = proImg.getData().ToList();
            //Page List
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<product_image>(list, pageNumber, pageSize);
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
        public ActionResult CreateNew( product_image proImg)
        {
            ListProductImage list = new ListProductImage();
            list.insert(proImg);

            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            ListProductImage list = new ListProductImage();
             product_image proImg = list.Details(id).FirstOrDefault();
           
            return View(proImg);
        }
        public ActionResult Edit(int id)
        {
            ListProductImage list = new ListProductImage();
             product_image item = list.Details(id).FirstOrDefault();
            ListProduct pro = new ListProduct();

            SelectList cateList = new SelectList(pro.getData().ToList(), "product_id", "product_name");
            ViewBag.ProductList = cateList;
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit( product_image proImg)
        {
            ListProductImage list = new ListProductImage();
            list.update(proImg);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ListProductImage list = new ListProductImage();

            list.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SearchResult(int searchKey)
        {
            ListProductImage list = new ListProductImage();
            List<product_image> lstSearch = list.getImageProduct(searchKey).ToList();
            ViewBag.searchKey = searchKey;
            return View(lstSearch);
        }
    }
}