﻿
using NongSanDungHa.Models.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Security.Policy;
using Antlr.Runtime;

namespace NongSanDungHa.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        // GET: Admin/AccountAdmin
        DBConnection db = new DBConnection();

        public ActionResult Index(int ?page)
        {
            ListAdminAccount user = new ListAdminAccount();
            ViewBag.TotalAdmin = user.getData().Count();
            List<admin_account> list = user.getData().ToList();
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            PagedList<admin_account> lst = new PagedList<admin_account>(list, pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult CreateNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateNew( admin_account user)
        {
            ListAdminAccount list = new ListAdminAccount();
            var rs = list.CreateAdminAccount(user);
            ViewBag.KT = 0;
            if (rs == -1)
            {
                ViewBag.KT = -1;
                ViewBag.ErrorMessage = "Tài khoản đã tồn tại";
            }
            else
            {
                ViewBag.KT = 1;
                ViewBag.ErrorMessage = "Tạo thành công tài khoản";
            }
            return View();
        }
        public ActionResult Detail(int id)
        {
            ListAdminAccount list = new ListAdminAccount();
            admin_account user = list.Details(id).FirstOrDefault();
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            ListAdminAccount list = new ListAdminAccount();
             admin_account item = list.Details(id).FirstOrDefault();

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit( admin_account user)
        {
            ListAdminAccount list = new ListAdminAccount();
            list.update(user);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ListAdminAccount list = new ListAdminAccount();
            admin_account admin = list.Details(id).FirstOrDefault();
            return View(admin);
        }
        [HttpPost]
        public ActionResult Delete(admin_account admin)
        {
            ListAdminAccount list = new ListAdminAccount();
            admin_account sesAd = Session["User"] as admin_account;
            if (sesAd.admin_username != admin.admin_username)
            {
                var rs = list.delete(admin.admin_account_id);
                if (rs == 1)
                {
                    return RedirectToAction("Index");
                }
            }    
           
            admin_account ad = list.Details(admin.admin_account_id).FirstOrDefault();
            ViewBag.KT = 0;
            ViewBag.Message = "Xóa Thất bại";
            return View(ad);
        }
        public ActionResult SearchResult(string searchKey)
        {
            ListAdminAccount list = new ListAdminAccount();
            List<admin_account> lstSearch = list.search(searchKey).ToList();
            ViewBag.searchKey = searchKey;
            return View(lstSearch);
        }
        [HttpGet]
        public JsonResult GetData()
        {
            ListAdminAccount user = new ListAdminAccount();
            List<admin_account> list = user.getData().ToList();
            
            return Json(new { data = list, TotalUser = list.Count() }, JsonRequestBehavior.AllowGet);
        }

 
        //Ajax
        [HttpGet]
        public JsonResult JsonDetail(int id)
        {
            ListAdminAccount list = new ListAdminAccount();
            admin_account user = list.Details(id).SingleOrDefault();
            
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult JsonDelete(int id)
        {

            ListAdminAccount list = new ListAdminAccount();

            var rs = list.delete(id);
            if (rs > 0)
            {
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);


        }
    }
}