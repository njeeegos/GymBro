using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class EventParticipant
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
    }
}