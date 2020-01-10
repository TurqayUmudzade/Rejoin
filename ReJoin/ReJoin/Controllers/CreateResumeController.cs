using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReJoin.Models;
using ReJoin.Data;
using ReJoin.Filters;

namespace ReJoin.Controllers
{
    [Auth]
    public class CreateResumeController : Controller
    {
        private readonly Context _context;

        public CreateResumeController()
        {
            _context = new Context();
        }

        // GET: CreateResume
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Resume resume)
        {
            Resume newResume = new Resume();

            newResume = resume;
            newResume.ExprienceYear = Int32.Parse(Request.Form.Get("xpYear"));
            newResume.ExprienceYear = Int32.Parse(Request.Form.Get("xpYear"));


            _context.resumes.Add(newResume);
            User user = ViewBag.User as User;
            User myUser = _context.users.Find(user.UserID);
            myUser.Resume = newResume;
            

            // _context.SaveChanges();


            return Content("hi");
            // return View();
        }
    }
}