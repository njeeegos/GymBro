using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GymBro.Models;

namespace GymBro.Models
{
    public class FacilityFormViewModel
    {
        //public IEnumerable<Sport> Sports { get; set; }
        public SportsFacility Facility { get; set; }

        public List<CheckBoxListItem> Sports { get; set; }

        public FacilityFormViewModel()
        {
            Sports = new List<CheckBoxListItem>();
        }
    }
} 