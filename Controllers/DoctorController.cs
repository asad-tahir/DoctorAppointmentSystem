using DoctorAppointmentSystem.Models;
using DoctorAppointmentSystem.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var doctorId = User.Identity.GetUserId();
            var requests = _context.Appointments.Include(a => a.ApplicationUser).Include(a => a.Slot).Include(a => a.Slot.ApplicationUser).Where(a => a.Slot.ApplicationUserId == doctorId).ToList();
            var viewModel = new RequestsViewModel() {
                Appointments = requests
            };
            return View(viewModel);
        }
        public ActionResult ListSlots()
        {
            var currentDoctorId = User.Identity.GetUserId();
            var slots = _context.Slots.Where(s => s.ApplicationUserId == currentDoctorId).ToList();
            return View(slots);
        }
        public ActionResult CreateSlot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSlot(Slot slot)
        {
            slot.Available = true;
            if(ModelState.IsValid)
            {
                _context.Slots.Add(slot);
                _context.SaveChanges();
            }
            return View(slot);
        }
    }
}