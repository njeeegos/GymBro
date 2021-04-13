using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class EventDetailsViewModel
    {
        public Event Event { get; set; }
        public ApplicationUser EventCreator { get; set; }
        public SportsFacility Location { get; set; }
        public Sport Activity { get; set; }
        public bool IsCreator { get; set; }

        public List<ApplicationUser> Participants { get; set; }

        public EventDetailsViewModel()
        {
            Participants = new List<ApplicationUser>();
        }
    }
}