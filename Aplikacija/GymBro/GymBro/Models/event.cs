using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti datum i vreme!")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy. HH:mm}")]
        [Display(Name = "Datum i vreme")]
        public DateTime DateAndTime { get; set; }

        //[Required(ErrorMessage = "Neophodno je uneti maksimalni broj učesnika!")]
        [MaxParticipantsValidation]
        [Display(Name = "Maksiamalan broj učesnika")]
        public int MaxNumber { get; set; }

        [Display(Name = "Trenutni broj učesnika")]
        public int CurrentNumber { get; set; }

        //[Required]
        //[Display(Name = "Lokacija")]
        public SportsFacility Location { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti lokaciju!")]
        [Display(Name = "Lokacija")]
        public int LocationId { get; set; }

        public Sport Sport { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti sportsku aktivnost!")]
        [Display(Name = "Aktivnost")]
        public int SportId { get; set; }
     

        public ICollection<ApplicationUser> Participants { get; set; }

        public ApplicationUser EventCreator { get; set; }

        //[Required]
        [Display(Name = "Kreator događaja")]
        public string EventCreatorId { get; set; }

    }
}