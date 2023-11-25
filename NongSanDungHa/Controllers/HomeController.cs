using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using NongSanDungHa.Models;
using PagedList;

namespace NongSanDungHa.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index(int? page)
        {
            ListDiscountEvent dis = new ListDiscountEvent();
            ListProduct pro = new ListProduct();
            List<product_discount_event> DiscountEvent = dis.getData().ToList();
            List<product> products = pro.getData().ToList();
            ViewBag.DiscountEvent = DiscountEvent;
            ViewBag.RauCuSachDaLat = products.Where(x => x.product_category_id == 1).ToList();
            ViewBag.RauCuSach = products.Where(x => x.product_category_id == 2).ToList();
            
            return View();
        }
        public ActionResult ShowDetailProduct(int id,int product_category_id)
        {
            ListProduct pro = new ListProduct();
            ListProductCategory cate = new ListProductCategory();
            ListProductImage image = new ListProductImage();
            List<product> Detail = pro.getData().Where(x => x.product_id == id).ToList();
            List<product_category> Category = cate.getData().Where(x => x.product_category_id == product_category_id).ToList();
            List<product_image> Images = image.getData().Where(x => x.product_id == id).ToList();
            ViewBag.NameCategory = Category;
            ViewBag.ImageCount = Images.Count;
            ViewBag.Image = Images;
           
            return View(Detail);
        }
        public ActionResult ShowCategory(int id)
        {
            ListProduct pro = new ListProduct();
            ListProductCategory cate = new ListProductCategory();
            List<product> ListCategory = pro.getData().Where(x=> x.product_category_id == id).ToList();
            List<product_category> Category = cate.getData().Where(x => x.product_category_id == id).ToList();
            ViewBag.NameCategory = Category;
              
            
            return View(ListCategory);
        }
        [HttpGet]
        public ActionResult SearchResult(string searchKey)
        {
            ListProduct pro = new ListProduct();
            List<product> list = new List<product>();
            if (!string.IsNullOrEmpty(searchKey))
            {
                list = pro.getData().Where(x => x.product_name.Contains(searchKey)).ToList();
            }
            ViewBag.SearchKey = searchKey;
            return View(list);
        }

    }
}