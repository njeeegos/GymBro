using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class FacilityWithImagesViewModel
    {
        public SportsFacility SportsFacility { get; set; }

        public List<FacilityImage> FacilityImages { get; set; }

        public bool IsRated { get; set; }

        public FacilityWithImagesViewModel()
        {
            FacilityImages = new List<FacilityImage>();
        }
    }
}