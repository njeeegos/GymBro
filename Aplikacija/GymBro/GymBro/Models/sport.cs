using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class Sport
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        public string Name { get; set; }


        public ICollection<SportsFacility> SportsFacilities { get; set; }

    }
}