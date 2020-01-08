using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReJoin.Models;

namespace ReJoin.Controllers
{
    public class CreateResumeController : Controller
    {
        // GET: CreateResume
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Resume resume)
        {
            return Content(resume.Fullname);
           // return View();
        }
    }
}