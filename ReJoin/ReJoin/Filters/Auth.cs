using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReJoin.Data;
using ReJoin.Models;



namespace ReJoin.Filters
{
    public class Auth : ActionFilterAttribute
    {
        private readonly Context _context;

        public Auth()
        {
            _context = new Context();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie tokenCookie = HttpContext.Current.Request.Cookies.Get("token");
            if (tokenCookie == null)
            {
                filterContext.Result = new RedirectResult("~/login");
                return;
            }

            User user = _context.users.FirstOrDefault(u => u.Token == tokenCookie.Value);

            if (user == null)
            {
                filterContext.Result = new RedirectResult("~/login");
                return;
            }

            filterContext.Controller.ViewBag.User = user;

            base.OnActionExecuting(filterContext);
        }
    }
}