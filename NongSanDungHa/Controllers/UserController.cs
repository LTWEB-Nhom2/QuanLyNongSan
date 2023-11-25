using NongSanDungHa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NongSanDungHa.Controllers
{
    public class UserController : Controller
    {
       

        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(user_account a)
        {
            if (ModelState.IsValid)
            {
                ListUserAccount user = new ListUserAccount();
                int kt = user.CreateUserAccount(a);
                if (kt != -1)
                {
                    ViewBag.message = "Tạo tài khoản thành công";
                }
                else
                    ViewBag.message = "Đã có tài khoản này rồi";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if(ModelState.IsValid)
            {
                ListUserAccount db = new ListUserAccount();
                var userCheck = db.getData().SingleOrDefault(x => x.user_username.Equals(Username) && x.user_password.Equals(Password));
                ListAdminAccount dba = new ListAdminAccount();
                var admincheck = dba.getData().SingleOrDefault(x => x.admin_username.Equals(Username) && x.admin_password.Equals(Password));
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Username))
                {
                    if (userCheck != null)
                    {
                        Session["Username"] = Username;
                        return RedirectToAction("Index", "Home");
                    }
                    else if (admincheck != null)
                    {
                        Session["Username"] = Username;
                        return RedirectToAction("Index", "Admin");
                    }

                    ViewBag.message = "Tài khoản hoặc mật khẩu không đúng";
                }
            }         
            return View();
        }
 
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}