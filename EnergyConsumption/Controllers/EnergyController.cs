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
    public class EnergyController : Controller
    {
        public EnergyController(){
            db = new ApplicationDbContext();
        manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }



    private UserManager<ApplicationUser> manager;
        private ApplicationDbContext db;
        // GET: Energy
        public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var Homes = db.Homes.Where(t => t.ApplicationUserID == currentUser.Id).ToList();
            return View(Homes);
        }
    }
}