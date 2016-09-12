using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnergyConsumption.Controllers
{
    public class DeviceController : Controller
    {
        // GET: Device
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int? id )
        {
            ViewBag.Home = id;
            return View();
        }




    }
}