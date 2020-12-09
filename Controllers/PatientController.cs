using DoctorAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var doctors = from u in _context.Users
                          where u.Roles.Any(r => r.RoleId == role.Id)
                          select u;
            return View(doctors);
        }
        public ActionResult DoctorDetails(string id)
        {
            var doctor = _context.Users.SingleOrDefault(user => user.Id == id);
            var slots = (from s in _context.Slots
                        where s.ApplicationUserId.Equals(id)
                        select s).ToList();
            var viewModel = new DoctorDetailsViewModel {
                Slots = slots,
                DoctorName = doctor.Name
            };
            //var innerJoin = slots.Join(// outer sequence 
            //          _context.Users,  // inner sequence 
            //          slot => slot.ApplicationUserId,    // outerKeySelector
            //          user => user.Id,  // innerKeySelector
            //          (slot, user) => new  // result selector
            //          {
            //              DoctorName = user.Name,
            //              AvailableFrom = slot.AvailableFrom,
            //              AvailableTill = slot.AvailableTill
            //          });
            return View(viewModel);
        }
    }
}