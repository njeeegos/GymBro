using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GymBro.Models;

namespace GymBro.Models
{
    public class EventFormViewModel
    {
        public Event Event { get; set; }

        public List<Sport> Sports { get; set; }

        public List<SportsFacility> SportsFacilities { get; set; }
        public EventFormViewModel()
        {
            Sports = new List<Sport>();
            SportsFacilities = new List<SportsFacility>();
        }
    }
}