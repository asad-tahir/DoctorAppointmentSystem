using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public bool IsDeactivated { get; set; }
    }
}