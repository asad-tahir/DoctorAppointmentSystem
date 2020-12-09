using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.Models
{
    public class DoctorDetailsViewModel
    {
        public string DoctorName { get; set; }
        public List<Slot> Slots { get; set; }
    }
}