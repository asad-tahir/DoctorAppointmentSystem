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
    [Authorize(Roles = UserType.Admin)]
    public class AdminController : Controller
    {
        ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin
        public ActionResult Index()
        {
            var docRoleId = _context.Roles.FirstOrDefault(r => r.Name == UserType.Doctor).Id;
            var patientRoleId = _context.Roles.FirstOrDefault(r => r.Name == UserType.Patient).Id;
            var users = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == docRoleId || r.RoleId == patientRoleId)).ToList();
            
            List<UsersViewModel> UsersWithRole = (from u in users
                         join ur in _context.Roles
                         on u.Roles.ToList()[0].RoleId equals ur.Id
                         select new UsersViewModel
                         { 
                            Id = u.Id,
                            Name = u.Name,
                            RoleName = ur.Name,
                            IsDeactivated = u.IsDeactivated
                         }).ToList();
            return View(UsersWithRole);
        }
        public void ActivateAccount(string id) {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.LockoutEndDateUtc = null;
                user.IsDeactivated = false;
                _context.SaveChanges();
            }
        }
        public void DeactivateAccount(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.LockoutEndDateUtc = DateTime.MaxValue;
                user.IsDeactivated = true;
                _context.SaveChanges();
            }
        }
        
        public void DeleteAccount(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                var slots = _context.Slots.Where(s => s.ApplicationUserId == id).ToList();
                var appointments = _context.Appointments.Where(a => a.ApplicationUserId == id).ToList();
                var prescriptions = _context.Prescriptions.Where(p => p.DoctorId == id || p.PatientId == id).ToList();
                foreach(var prescription in prescriptions) 
                { 
                    _context.Prescriptions.Remove(prescription);
                }
                foreach (var slot in slots)
                {
                    _context.Slots.Remove(slot);
                }
                foreach (var appointment in appointments)
                {
                    _context.Appointments.Remove(appointment);
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}