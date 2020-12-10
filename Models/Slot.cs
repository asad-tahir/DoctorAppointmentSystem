using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.Models
{
    public class Slot
    {
        public int Id { get; set; }
        [Required]
        public DateTime AvailableFrom { get; set; }
        [Required]
        [GreaterThan("AvailableFrom")]
        public DateTime AvailableTill { get; set; }
        public bool Available { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}