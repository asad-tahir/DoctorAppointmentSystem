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
            var adminId = User.Identity.GetUserId();
            var docRoleId = _context.Roles.FirstOrDefault(r => r.Name == UserType.Doctor).Id;
            var patientRoleId = _context.Roles.FirstOrDefault(r => r.Name == UserType.Patient).Id;
            var users = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == docRoleId || r.RoleId == patientRoleId)).ToList();
            return View(users);
        }
    }
}