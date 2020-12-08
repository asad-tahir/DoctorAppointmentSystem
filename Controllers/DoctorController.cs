using DoctorAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentSystem.Controllers
{
    [Authorize(Roles = UserType.Doctor)]
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateSlot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSlot(Slot slot)
        {
            return View();
        }
    }
}