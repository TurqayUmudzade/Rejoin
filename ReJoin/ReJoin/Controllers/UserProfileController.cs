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
using ReJoin.Models;
using ReJoin.ViewModels;


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
            myUser.picture = EditerUser.thisUser.picture;
           /* myUser = EditerUser.thisUser;
            myUser = EditerUser.thisUser;
            myUser = EditerUser.thisUser;
            myUser = EditerUser.thisUser;*/

            _context.SaveChanges();


            return Content(myUser.PhoneNumber);
        }
    }
}