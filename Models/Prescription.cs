using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public ApplicationUser Doctor { get; set; }
        public string DoctorId { get; set; }
        public ApplicationUser Patient { get; set; }
        public string PatientId { get; set; }
        public string Description { get; set; }
    }
}