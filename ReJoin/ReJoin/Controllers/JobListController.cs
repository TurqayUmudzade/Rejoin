using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReJoin.Data;
using ReJoin.ViewModels;
using ReJoin.Models;

namespace ReJoin.Controllers
{
    public class JobListController : Controller
    {
        private readonly Context _context;

        public JobListController()
        {
            _context = new Context();
        }

        // GET: JobList
        public ActionResult Index()
        {
            JobListViewModel jobListViewModel = new JobListViewModel
            {
                jobAds = _context.JobsAd.ToList()
            };

            return View(jobListViewModel);
        }

       
        //SEARCH BUTTON FUNCTION
        public ActionResult Search(string searchstring)
        {
            JobListViewModel jobListViewModel = new JobListViewModel
            {
               jobAds = _context.JobsAd.Where(job => job.JobTitle.Contains(searchstring) || job.JobRole.Contains(searchstring) || job.JobType.Contains(searchstring) || job.CompanyName.Contains(searchstring)).ToList()
            };

           
            return View("~/Views/JobList/Index.cshtml", jobListViewModel);
        }

        //SEARCH BUTTON FUNCTION
        public ActionResult Filter(string checkbox1,string checkbox2, string checkbox3, string checkbox4, string checkbox5, string checkbox6, string checkbox7, string checkbox8, string checkbox9, string priceRange, string checkbox21, string checkbox22, string checkbox23, string checkbox24,string checkbox31, string checkbox32, string checkbox33)
        {
            int salarymin = 0;
            int salarymax = 10000000;
            string[] salary = priceRange.Split('-');

            if (!string.IsNullOrEmpty(salary[0]))
            {
                salarymin = Int32.Parse(salary[0].Trim('$'));
                
                 salarymax = Int32.Parse(salary[1].Remove(0,2));
            }
            
          ;
            //compare the job type with checkboxes
            JobListViewModel jobListViewModel = new JobListViewModel
            {
                jobAds = _context.JobsAd
                .Where(job => (job.JobRole == checkbox1 || job.JobRole == checkbox2 || job.JobRole == checkbox3 || job.JobRole == checkbox4 ||
                job.JobRole == checkbox5 || job.JobRole == checkbox6 || job.JobRole == checkbox7 || job.JobRole == checkbox8  
                || job.JobType == checkbox21 || job.JobType == checkbox22 || job.JobType == checkbox23 || job.JobType == checkbox24 || true)&& job.SalaryMin >= salarymin && job.SalaryMax <= salarymax)
                //.Where(job=>job.SalaryMin >= salarymin || job.SalaryMax <= salarymax)
                .ToList()
            };


            return View("~/Views/JobList/Index.cshtml", jobListViewModel);
        }
    }
}