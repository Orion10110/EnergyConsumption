using EnergyConsumption.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnergyConsumption.Controllers
{
    public class HomeController : Controller
    {


         private UserManager<ApplicationUser> manager;
        private ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: ToDoes
        public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var todo = db.Homes.Where(t => t.UserId == currentUser.Id).ToList();
            return View(todo);
        }
      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            if(User.Identity.IsAuthenticated)
            {
                
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}