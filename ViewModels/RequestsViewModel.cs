using DoctorAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.ViewModels
{
    public class RequestsViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}