using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReJoin.Data;
using ReJoin.Models;

namespace ReJoin.Controllers
{
    public class ContactController : Controller
    {
        private readonly Context _context;

        public ContactController()
        {
            _context = new Context();
        }
        // GET: Contact
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult sendMessage()
        {
            ContactInfo contactInfo = new ContactInfo()
            {
                Name = Request.Form.Get("name"),
                Email = Request.Form.Get("email"),
                Message = Request.Form.Get("msg")
            };

            _context.contactInfos.Add(contactInfo);
            _context.SaveChanges();

            return Content("done");
        }
    }
}