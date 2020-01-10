using ReJoin.Data;
using ReJoin.Models;
using System;
using System.Web;
using System.Web.Mvc;
using ReJoin.Filters;
using System.IO;

namespace ReJoin.Controllers
{
    [Auth]
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
        [HttpPost]
        public ActionResult submitJob(HttpPostedFileBase logoUpload)
        {



            User user = ViewBag.User as User;
            User logedInUser = _context.users.Find(user.UserID);


            JobAd job = new JobAd
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
                RecruiterAdress = Request.Form.Get("recAdress"),
                PostUserID = logedInUser.UserID,
                User = logedInUser,
                CreatedAt = DateTime.Now


            };



            if (logoUpload != null)
            {

                var fileName = Path.GetFileName(logoUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/Public/uploads"), fileName);
                logoUpload.SaveAs(path);
                job.picture = fileName;
            }



            _context.JobsAd.Add(job);
            _context.SaveChanges();

            return RedirectToAction("index", "JobList");

        }
    }
}