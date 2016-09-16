using EnergyConsumption.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public ActionResult Index()
        {
            return View();
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



    }
}