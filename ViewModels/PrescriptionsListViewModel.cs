using DoctorAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.ViewModels
{
    public class PrescriptionsListViewModel
    {
        public IEnumerable<Prescription> Prescriptions { get; set; }
    }
}