using ReJoin.Data;
using ReJoin.Models;
using System;
using System.Web.Mvc;

namespace ReJoin.Controllers
{
    public class AdPostController : Controller
    {

        private readonly Context _context;

        public AdPostController()
        {
            _context = new Context();
        }
        // GET: AdPost
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult submitJob()
        {
            Job job = new Job
            {
                JobTitle = Request.Form.Get("jobTitle"),
                JobType = Request.Form.Get("jobType"),
                JobRole = Request.Form.Get("role"),

                SalaryMin = Int32.Parse(Request.Form.Get("minSalary")),
                SalaryMax = Int32.Parse(Request.Form.Get("mSalary")),

                Exprience = Int32.Parse(Request.Form.Get("exprience")),
                Eligibility = Request.Form.Get("Eligibility"),
                City = Request.Form.Get("city"),
                Country = Request.Form.Get("Localities"),
                Description = Request.Form.Get("jobDescription"),

                CompanyName = Request.Form.Get("companyName"),
                RecruiterEmail = Request.Form.Get("recEmail"),
                RecruiterPhoneNumber = Request.Form.Get("phoneNumber"),
                RecruiterAdress = Request.Form.Get("recAdress")
            };



            _context.Jobs.Add(job);
            _context.SaveChanges();

            return RedirectToAction("index", "Home");
          
        }
    }
}