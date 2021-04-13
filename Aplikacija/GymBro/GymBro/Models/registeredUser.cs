using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class RegisteredUser
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Ime")]
        public string FirstName { get; set; }
        [Display(Name = "Prezime")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Šifra")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Grad")]
        public string Town { get; set; }
        [Display(Name ="Prosečna ocena")]
        public double AverageRating { get; set; }
        public virtual List<UserRating> Grades { get; set; }
        public virtual List<Event> RegisteredEvents { get; set; }
    }
}