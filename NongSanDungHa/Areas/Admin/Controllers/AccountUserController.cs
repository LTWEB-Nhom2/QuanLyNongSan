using NongSanDungHa.Models.ADO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace NongSanDungHa.Areas.Admin.Controllers
{
    public class AccountUserController : Controller
    {
        // GET: Admin/AccountUser
        DBConnection db = new DBConnection();
        
        public ActionResult Index(int? page)
        {
            ListUserAccount user = new ListUserAccount();
            ViewBag.TotalUser = user.getData().Count();
            List<user_account> list = user.getData().ToList();
            //Page List
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<user_account>(list, pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult CreateNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateNew( user_account user)
        {
            ListUserAccount list = new ListUserAccount();
            var res = list.CreateUserAccount(user);
            if (res == 0)
            {
                ViewBag.ErrorMessage = "Tài khoản đã tồn tại";
            }
           
                

            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            ListUserAccount list = new ListUserAccount();
            user_account user = list.Details(id).SingleOrDefault();
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            ListUserAccount list = new ListUserAccount();
            user_account item = list.Details(id).SingleOrDefault();

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit( user_account user)
        {
            ListUserAccount list = new ListUserAccount();
            list.update(user);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ListUserAccount list = new ListUserAccount();

            list.delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult SearchResult(int searchKey)
        {
            ListUserAccount list = new ListUserAccount();
            List<user_account> lstSearch = list.search(searchKey).ToList();
            ViewBag.searchKey = searchKey;
            return View(lstSearch);
        }
        //Ajax
        [HttpGet]
        public JsonResult GetData()
        {
            ListUserAccount user = new ListUserAccount();
            List<user_account> list = user.getData().ToList();

            return Json(new { data = list, TotalUser = list.Count() }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult JsonDetail(int id)
        {
            ListUserAccount list = new ListUserAccount();
            user_account user = list.Details(id).SingleOrDefault();
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult JsonEdit(user_account item)
        {
            ListUserAccount list = new ListUserAccount();
         
            var result = list.update(item);
            if(result > 0)
                return Json(new {Success = true}, JsonRequestBehavior.AllowGet);
            else 
                return Json(new {Success = false}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult JsonDelete(int id)
        {

            ListUserAccount user = new ListUserAccount();

            var rs = user.delete(id);
            if (rs > 0)
            {
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult JsonAdd(user_account user)
        {
            ListUserAccount list = new ListUserAccount();
            var result = list.CreateUserAccount(user);
            if (result == 0)
            return Json(new {Success = true},JsonRequestBehavior.AllowGet);
            else return Json(new {Success = false},JsonRequestBehavior.AllowGet);
        }
    }
}