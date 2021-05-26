using HocMVC.Areas.Admin.Models;
using HocMVC.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login( LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName,Encryptor.MD5Hash(model.password));
                if (result==1)
                {
                    var user = dao.getbyid(model.UserName);
                    var userSession = new UserLogin();
                    userSession.userName = user.UserName;
                    userSession.userID = user.ID;
                    Session.Add(SessionKT.USER_SESSION, userSession);
                    return RedirectToAction("Index", "AdmHome");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
                

            }
            return View("Index");
            
        }

    }
}