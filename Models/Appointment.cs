using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public Slot Slot { get; set; }
        public int SlotId { get; set; }
    }
}