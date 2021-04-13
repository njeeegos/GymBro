using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class SportsFacility
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti ime!")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Display(Name = "Mesto")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti adresu!")]
        [Display(Name = "Adresa")]
        public string Address { get; set; }

        [Display(Name = "Prosečna ocena")]
        [DisplayFormat(DataFormatString = "{0:#.#}")]
        public double AverageGrade { get; set; }
        

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public virtual ICollection<FacilityRating> Grades { get; set; }
        public virtual ICollection<Sport> TypesOfSports { get; set; }

    }
}