using DoctorAppointmentSystem.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DoctorAppointmentSystem.ViewModels;

namespace DoctorAppointmentSystem.Controllers
{
    [Authorize(Roles = UserType.Patient)]
    public class PatientController : Controller
    {
        ApplicationDbContext _context;
        public PatientController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Patient
        public ActionResult Index()
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == UserType.Doctor);
            var doctors = (from u in _context.Users
                          where u.Roles.Any(r => r.RoleId == role.Id)
                          select u).ToList();
            return View(doctors);
        }
        public ActionResult SlotsByDoctor(string id)
        {
            var doctor = _context.Users.SingleOrDefault(user => user.Id == id);
            var slots = (from s in _context.Slots
                        where s.ApplicationUserId.Equals(id)
                        select s).ToList();
            var viewModel = new DoctorDetailsViewModel() {
                Slots = slots,
                DoctorName = doctor.Name
            };
            return View(viewModel);
        }
        
        public ActionResult RequestAppointment(int id)
        {
            var patientId = User.Identity.GetUserId();
            var appointment = new Appointment() {
                Status = AppointmentStatus.Pending,
                ApplicationUserId = patientId,
                SlotId = id
            };
            var slot = _context.Slots.SingleOrDefault(s => s.Id == id);
            var req = _context.Appointments.FirstOrDefault(a => (a.SlotId == id && a.ApplicationUserId == patientId));
            if(req != null)
            {
                return Content("Already Submitted!");
            }
            if (slot.Available)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return Content("Request Submitted");
            }
            return Content("Request Failed!");
        }

        public ActionResult ApprovedAppointments()
        {
            var patientId = User.Identity.GetUserId();
            var requests = _context.Appointments
                .Include(a => a.ApplicationUser).Include(a => a.Slot)
                .Include(a => a.Slot.ApplicationUser)
                .Where(a => a.ApplicationUserId == patientId && a.Status == AppointmentStatus.Approved)
                .ToList();
            var viewModel = new RequestsViewModel()
            {
                Appointments = requests
            };
            return View(viewModel);
        }
    }
}