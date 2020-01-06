using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReJoin.Models;
using ReJoin.Data;
using ReJoin.ViewModels;
using System.Web.Helpers;
using System.Web.Security;


namespace ReJoin.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController()
        {
            _context = new Context();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {


            if (ModelState.IsValid)
            {

                if (_context.users.Any(u => u.Email == register.Email))
                {
                    ModelState.AddModelError("Email", "This email is taken");
                    return new EmptyResult();
                }
                User newUser = new User()
                {
                    Fullname = register.Fullname,
                    Email = register.Email,
                    Password = Crypto.SHA256(register.Password),
                    Token = Guid.NewGuid().ToString()
                };

                _context.users.Add(newUser);
                _context.SaveChanges();

                HttpCookie httpCookie = new HttpCookie("token")
                {
                    Value = newUser.Token,
                    Expires = DateTime.Now.AddYears(1),
                    HttpOnly = true

                };

                Response.Cookies.Add(httpCookie);


                return RedirectToAction("index", "Home");
            }

            LoginViewModel model = new LoginViewModel()
            {
                Register = register
            };

            return View("~/Views/Home/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Login(LogingInViewModel Login)
        {
            if (ModelState.IsValid)
            {
                User user = _context.users.FirstOrDefault(u => u.Email == Login.Email);
                if (user != null)
                {
                    if (user.Password== Crypto.SHA256(Login.Password))
                    {
                        user.Token = Guid.NewGuid().ToString();
                        _context.SaveChanges();
                        HttpCookie tokenCookie = new HttpCookie("token")
                        {
                            Value=user.Token,
                            HttpOnly=true
                            
                        };

                        tokenCookie.Expires = DateTime.Now.AddDays(10);
                        
                        Response.Cookies.Add(tokenCookie);
                        return RedirectToAction("index","UserProfile",user);
                    }
                }
                ModelState.AddModelError("CustomError", "Wrong Email or Password");
            }

            LoginViewModel model1 = new LoginViewModel
            {
                Login = Login
            };

            return View("~/Views/Login/Index.cshtml", model1);
        }

       // [Auth]
        public ActionResult Logout()
        {
            User user = ViewBag.User as User;

            user.Token = null;

            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();



            Response.Cookies.Add(new HttpCookie("token") { Value = "", Expires = DateTime.Now.AddDays(-1) });
            FormsAuthentication.SignOut();

            return RedirectToAction("index");
        }

    }
}