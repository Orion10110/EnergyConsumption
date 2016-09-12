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
    public class MyHomeController : Controller
    {
        private UserManager<ApplicationUser> manager;
        private ApplicationDbContext db;

        public MyHomeController()
        {
            db = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }


      

       
        // GET: Device
        public ActionResult Index()
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());
            var todo = db.Homes.Where(t => t.ApplicationUser_Id == currentUser.Id).ToList();
            return View(todo);
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
                home.ApplicationUser_Id = User.Identity.GetUserId();
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
                home.ApplicationUser_Id = User.Identity.GetUserId();
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

        // POST: ToDoes/Delete/5
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
            Home home= db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }


    }
}