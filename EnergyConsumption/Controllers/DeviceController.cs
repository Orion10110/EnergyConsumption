using EnergyConsumption.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EnergyConsumption.Controllers
{
    public class DeviceController : Controller
    {
        private ApplicationDbContext db;

        public DeviceController()
        {
            db = new ApplicationDbContext();
             }


        // GET: Device
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Include(t => t.Devices).FirstOrDefault(t => t.Id == id);
           
            List<Device> devices = new List<Device>(home.Devices);
            if (devices == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeW = home.Devices.Sum(x => x.W * x.Hour * x.Day * x.Number).ToString();
            ViewBag.HomeID = id;
            return View(devices);



        }

        public ActionResult Create(int? id )
        {
            ViewBag.HomeID = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Device device)
        {

           

            if (ModelState.IsValid)
            {

                db.Divaces.Add(device);
                db.SaveChanges();
            }

            return RedirectToAction("Details","MyHome", new {id= device.HomeID.ToString() });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Divaces.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Device device)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(device).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "MyHome", new { id = device.HomeID.ToString() });
            }
            return View(device);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Divaces.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Device device = db.Divaces.Find(id);
            string HomeId = device.HomeID.ToString(); 
            db.Divaces.Remove(device);
            db.SaveChanges();
            return RedirectToAction("Details", "MyHome", new { id = HomeId });
        }

    }
}