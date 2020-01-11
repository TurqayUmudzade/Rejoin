using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReJoin.Models;
using ReJoin.ViewModels;
using ReJoin.Data;
using ReJoin.Filters;

namespace ReJoin.Controllers
{
    [Auth]
    public class JobInfoController : Controller
    {
        private readonly Context _context;

        public JobInfoController()
        {
            _context = new Context();
        }

        // GET: JobInfo
        public ActionResult Index(int id)
        {
            JobAd job = _context.JobsAd.Find(id);
            User user = ViewBag.User as User;
            User myUser = _context.users.Find(user.UserID);

            JobInfoViewModel jobInfoViewModel = new JobInfoViewModel
            {
                User = myUser,
                JobAd = job
            };


            return View(jobInfoViewModel);
        }
    }
}