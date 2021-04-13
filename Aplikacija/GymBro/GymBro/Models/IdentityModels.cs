using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymBro.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Display(Name = "Grad")]
        public string Town { get; set; }

        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date, ErrorMessage= "Polje mora biti datum!")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Pol")]
        public bool Gender { get; set; }

        [Display(Name = "Prosečna ocena")]
        public double AverageRating { get; set; }

        public ICollection<UserRating> Ratings { get; set; }

        public ICollection<Event>  Events { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<FacilityRating> FacilityRatings { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<SportsFacility> SportsFacilities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<SportSportsFacility> SportSportsFacilities { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<FacilityImage> FacilityImages { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}