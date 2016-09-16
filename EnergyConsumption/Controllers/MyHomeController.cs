using EnergyConsumption.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EnergyConsumption.Controllers
{
    [Authorize]
    public class MyHomeController : Controller
    {
        private UserManager<ApplicationUser> manager;
        private ApplicationDbContext db;

        public MyHomeController()
        {
            db = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }


        public ActionResult HomeList()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var home = db.Homes.Where(t => t.ApplicationUserID == currentUser.Id).ToList();
            return PartialView(home);
        }


        // GET: Device
        public ActionResult Index()
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());
            var home = db.Homes.Where(t => t.ApplicationUserID == currentUser.Id).ToList();

            return View(home);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Home home)
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                home.ApplicationUserID = User.Identity.GetUserId();
                db.Entry(home).State = EntityState.Added;
                db.Homes.Add(home);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(home);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Home home)
        {
            if (ModelState.IsValid)
            {
                home.ApplicationUserID = User.Identity.GetUserId();
                db.Entry(home).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(home);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Home home = db.Homes.Find(id);
            db.Homes.Remove(home);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Include(t=> t.Devices).FirstOrDefault(t=>t.Id == id);
       
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);



        }


    }
}