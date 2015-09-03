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
                             Country = e.Country,
                             ZipCode = e.ZipCode,
                             Description = e.Description,
                             OrganizationName = e.Organization.FullName
                         };
            return View(events.ToList());
            
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


        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            //ViewBag.Message = "This log in didn't break anything.";

            //ViewBag.isLoggedIn = false;

            //var q = from c in db.Users
            //        where login.Email == c.Email
            //        select c;
            //q = q.Where(u => u.Email.Equals(login.Email));

            //int count = q.Count(u => u.Email == u.Email);

            //if (count == 1 && q.First().Password == login.Password)
            //{
            //    User user = (from c in q
            //                 select c).First();

            //    ViewBag.isLoggedIn = true;
            //    ViewBag.Email = user.Email;
            //    ViewBag.FullName = user.FullName;
            //}
            return View();
        }
        //public ActionResult userprofile(string userid)

        //public ActionResult userprofile(string? id)

        //{
            //if (userid.Equals(null))
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //var myuser = (from e in db.Users
            //              where e.Id.Equals(userid)
            //              select new UserProfileDTO()
            //              {
            //                  Name = e.FullName,

            //              }).Single();


            //var model = new UserProfileDTO
            //{
            //    Name="Zaman"
            //};
            //if (ModelState.IsValid)
            //{
            //    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //    var currentUser = manager.FindById(userid);
            //    ViewData.Add("Location", currentUser.Location);
            //    ViewData.Add("Description", currentUser.Description);
            //}

            //if (myuser == null)
            //{
            //    return HttpNotFound();
            //}

        //    return View();
        //}

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