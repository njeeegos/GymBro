using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class UserRatingViewModel
    {
        public ApplicationUser appUser { get; set; }

        public bool IsRated { get; set; }
    }
}