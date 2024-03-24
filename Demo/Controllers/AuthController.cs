using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using Demo.Models;
using System.Net;
using Microsoft.Owin.Security;

namespace Demo.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            using(DB db = new DB())
            {
                db.Users.Add(user);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }
        
        // Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            using (DB db = new DB())
            {
                var user = db.Users.Where(a => a.Email == login.Email && a.Password == login.Password).FirstOrDefault();

                if (user!= null)
                {
                    var Ticket = new FormsAuthenticationTicket(login.Email, true, 3000);
                    string Encrypt = FormsAuthentication.Encrypt(Ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                    cookie.Expires = DateTime.Now.AddHours(3000);
                    cookie.HttpOnly = true; 
                    Response.Cookies.Add(cookie);
                    if(user.RoleId ==1)
                    {
                        return RedirectToAction("UserArea", "Home");
                    }else
                    {
                        return RedirectToAction("AdminArea", "Home");
                    }
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
        }
    }
}