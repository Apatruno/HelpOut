using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelpOut.Models;

using System.Net;

using Microsoft.AspNet.Identity;
using HelpOut.ModelViews;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HelpOut.Controllers
{
    public class HomeController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var events = from e in db.Events
                         select new EventDTO()
                         {
                             EventID = e.EventID,
                             Name = e.Name,
                             DateTime = e.DateTime,
                             Address = e.Address,
                             City = e.City,
                             State = e.State,
                             ZipCode = e.ZipCode,
                             Description = e.Description,
                             OrganizationName = e.Organization.FullName
                         };

            return View(events.OrderByDescending(e => e.DateTime).ToList());
            
            //ApplicationUser user = new ApplicationUser();
            //string currentUserID = User.Identity.GetUserId();

            //if (Request.IsAuthenticated)
            //{
            //    user = (from u in db.Users
            //            where u.Id == currentUserID
            //            select u).First();
            //}
            
            //return View(user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}