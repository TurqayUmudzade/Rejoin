using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReJoin.Models;
using ReJoin.Data;
using ReJoin.ViewModels;
using System.Web.Helpers;
using ReJoin.Filters;
using System.IO;



namespace ReJoin.Controllers
{
    [Auth]
    public class UserProfileController : Controller
    {
        private readonly Context _context;

        public UserProfileController()
        {
            _context = new Context();
        }
        // GET: UserProfile

        public ActionResult Index()
        {
            User user = ViewBag.User as User;
            ProfileViewModel profileViewModel = new ProfileViewModel() {
                thisUser = user
            };
            
            
           // return View(profileViewModel);
            return View(profileViewModel);
        }

        public ActionResult Edit(ProfileViewModel EditerUser) {

            User user = ViewBag.User as User;
            User myUser = _context.users.Find(user.UserID);
            
            if (!string.IsNullOrEmpty(EditerUser.thisUser.Fullname)) {
                myUser.Fullname = EditerUser.thisUser.Fullname;
            }

            if (!string.IsNullOrEmpty(EditerUser.thisUser.Email))
            {
                myUser.Email = EditerUser.thisUser.Email;
            }

            
            myUser.PhoneNumber = EditerUser.thisUser.PhoneNumber;
            myUser.Adress = EditerUser.thisUser.Adress;
            myUser.City= EditerUser.thisUser.City;
            myUser.PostolZipCode = EditerUser.thisUser.PostolZipCode;
            myUser.Country = EditerUser.thisUser.Country;
            myUser.AboutMe = EditerUser.thisUser.AboutMe;
           
            

            myUser.FacebookLink = EditerUser.thisUser.FacebookLink;
            myUser.TwitterLink = EditerUser.thisUser.TwitterLink;
            myUser.PinteresLink = EditerUser.thisUser.PinteresLink;
            myUser.GoogleLink = EditerUser.thisUser.GoogleLink;
            
            
            if (EditerUser.thisUser.Upload!=null)
            {
                
                if (!string.IsNullOrEmpty(myUser.picture))
                {
                    
                    string deletePath = Server.MapPath(string.Concat("~/Public/uploads/", myUser.picture));
                    System.IO.File.Delete(deletePath);
                    
                }

                var fileName = Path.GetFileName(EditerUser.thisUser.Upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Public/uploads"), fileName);
                EditerUser.thisUser.Upload.SaveAs(path);
                myUser.picture = fileName;
               
            }


            _context.SaveChanges();

            ProfileViewModel profileViewModel = new ProfileViewModel {
                thisUser = myUser
            };

            return View("~/Views/UserProfile/Index.cshtml",profileViewModel);
        }
    }
}