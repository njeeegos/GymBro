using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class FacilityRating
    {
        [Key]
        public int Id { get; set; }

        [Range(0,9)]
        [Display(Name="Ocena")]
        public int Value { get; set; }
        public SportsFacility SportsFacility { get; set; }
        public int SportsFacilityId { get; set; }
        public string RaterId { get; set; }

    }
}