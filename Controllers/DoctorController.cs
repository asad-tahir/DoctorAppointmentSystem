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
        ApplicationDbContext _context;
        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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
            if(ModelState.IsValid)
            {
                _context.Slots.Add(slot);
                _context.SaveChanges();
            }
            return View();
        }
    }
}