using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class UserRating
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string RaterId { get; set; }

    }
}