using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymBro.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using PagedList.Mvc;
using PagedList;

namespace GymBro.Controllers
{
    [Authorize]
    public class SportsFacilitiesController : Controller
    {
        private ApplicationDbContext _context;

        public SportsFacilitiesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: SportsFacilities
        [AllowAnonymous]
        public ActionResult Index(string sortBy, int? i)
        {
            ViewBag.NazivSort = String.IsNullOrEmpty(sortBy) ? "Naziv desc" : "";
            ViewBag.AdresaSort = sortBy == "Adresa" ? "Adresa desc" : "Adresa";
            ViewBag.OcenaSort = sortBy == "Ocena" ? "Ocena desc" : "Ocena";

            var facilities = _context.SportsFacilities.ToList();

            switch (sortBy)
            {
                case "Naziv desc":
                    facilities = facilities.OrderByDescending(x => x.Name).ToList();
                    break;
                case "Naziv":
                    facilities = facilities.OrderBy(x => x.Name).ToList();
                    break;
                case "Adresa desc":
                    facilities = facilities.OrderByDescending(x => x.Address).ToList();
                    break;
                case "Adresa":
                    facilities = facilities.OrderBy(x => x.Address).ToList();
                    break;
                case "Ocena desc":
                    facilities = facilities.OrderByDescending(x => x.AverageGrade).ToList();
                    break;
                case "Ocena":
                    facilities = facilities.OrderBy(x => x.AverageGrade).ToList();
                    break;
                default:
                    facilities = facilities.OrderBy(x => x.Name).ToList();
                    break;
            }


             return View(facilities.ToList().ToPagedList(i ?? 1, 5));
        }

       

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var facility = _context.SportsFacilities.Find(id);
            if (facility == null)
                return HttpNotFound();

            var sports = _context.SportSportsFacilities.Where(x => x.SportsFacility_Id == facility.Id).ToList();
            foreach(var s in sports)
            {
                var sp = _context.Sports.Find(s.Sport_Id);
                facility.TypesOfSports.Add(sp);
            }

            facility.Grades = _context.FacilityRatings.Where(x => x.SportsFacilityId == facility.Id).ToList();

            double sum = 0;
            foreach(var rating in facility.Grades)
            {
                sum += rating.Value;
            }

            if(facility.Grades.Count != 0)
                facility.AverageGrade = sum / (double)facility.Grades.Count;

            //_context.SaveChanges();

            var images = _context.FacilityImages.Where(m => m.SportsFacilityId == facility.Id).ToList();

            var rater= User.Identity.GetUserId();
            var r = false;
            if (_context.FacilityRatings.SingleOrDefault(ssf => ssf.SportsFacilityId == id && ssf.RaterId == rater) != null)
            {
                 r = true;
            }

            var viewModel = new FacilityWithImagesViewModel
            {
                SportsFacility = facility,
                FacilityImages = images,
                IsRated = r
            };


            return View(viewModel);
            
        }

        [HttpGet]
        public ActionResult Create() 
        {
            FacilityFormViewModel model = new FacilityFormViewModel()
            {
                Facility = new SportsFacility()
            };
            var sports = _context.Sports.ToList();
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (var sport in sports)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = sport.Id,
                    Display=sport.Name,
                    IsChecked = false
                });
            }
            model.Sports = checkBoxListItems;

            return View("FacilityForm", model);
        }

        public ActionResult Edit(int id)
        {
            var facility = _context.SportsFacilities.Find(id);
            if (facility == null)
                return HttpNotFound();

            var sports = _context.Sports.ToList();
            var selectedSports = _context.SportSportsFacilities.Where(x => x.SportsFacility_Id == id).ToList();
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (var sport in sports)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = sport.Id,
                    Display = sport.Name,
                    IsChecked = selectedSports.Where(x => x.Sport_Id == sport.Id).Any()
                });
            }

            var viewModel = new FacilityFormViewModel()
            {
                Facility = facility,
                Sports = checkBoxListItems
            };

            return View("FacilityForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FacilityFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var sports = _context.Sports.ToList();
                var checkBoxListItems = new List<CheckBoxListItem>();
                foreach (var sport in sports)
                {
                    checkBoxListItems.Add(new CheckBoxListItem()
                    {
                        ID = sport.Id,
                        Display = sport.Name,
                        IsChecked = false
                    });
                }
                var viewModel = new FacilityFormViewModel
                {
                    Facility = model.Facility,
                    Sports = checkBoxListItems
                };
                return View("FacilityForm", viewModel);
            }

            if (model.Facility.Id == 0)
            {
                var selectedSports = model.Sports.Where(x => x.IsChecked).Select(x => x.ID).ToList();
                var facility = new SportsFacility()
                {
                    Name = model.Facility.Name,
                    Town = model.Facility.Town,
                    Address = model.Facility.Address
                };

                _context.SportsFacilities.Add(facility);

                _context.SaveChanges();

                foreach (var sportID in selectedSports)
                {
                    var name = new SportSportsFacility
                    {
                        Sport_Id = sportID,
                        SportsFacility_Id = facility.Id
                    };
                    _context.SportSportsFacilities.Add(name);
                }

            }
            else
            {
                var facilityInDb = _context.SportsFacilities.Single(sf => sf.Id == model.Facility.Id);
                facilityInDb.Name = model.Facility.Name;
                facilityInDb.Town = model.Facility.Town;
                facilityInDb.Address = model.Facility.Address;
                facilityInDb.AverageGrade = model.Facility.AverageGrade;

                var selectedSports = model.Sports.Where(x => x.IsChecked).Select(x => x.ID).ToList();
                foreach(var sportID in selectedSports)
                {
                    var sport = _context.SportSportsFacilities.SingleOrDefault(ssf => ssf.Sport_Id == sportID && ssf.SportsFacility_Id == model.Facility.Id);
                    if (sport == null)
                    {
                        _context.SportSportsFacilities.Add(new SportSportsFacility()
                        {
                            SportsFacility_Id = model.Facility.Id,
                            Sport_Id = sportID
                        });
                    }
                }

                var unselectedSports = model.Sports.Where(x => !x.IsChecked).Select(x => x.ID).ToList();
                foreach(var sportID in unselectedSports)
                {
                    var sport = _context.SportSportsFacilities.SingleOrDefault(ssf => ssf.Sport_Id == sportID && ssf.SportsFacility_Id == model.Facility.Id);
                    if (sport != null)
                        _context.SportSportsFacilities.Remove(sport);
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            var facility = _context.SportsFacilities.Find(id);
            if (facility != null)
                _context.SportsFacilities.Remove(facility);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SetRating(int facilityId, int rank)
        {
            var rater= User.Identity.GetUserId();
            var rate = _context.FacilityRatings.SingleOrDefault(ssf => ssf.SportsFacilityId == facilityId && ssf.RaterId == rater);
            if (rate != null)
            {
                _context.FacilityRatings.Remove(rate);
                _context.SaveChanges();
            }
            FacilityRating rating = new FacilityRating();
            rating.Value = rank;
            rating.SportsFacilityId = facilityId;
            rating.SportsFacility= _context.SportsFacilities.Find(facilityId);
            rating.RaterId = rater;

            _context.FacilityRatings.Add(rating);
            _context.SaveChanges();

            //  Dodaj slike i sportove u model ovde
            //Vazi Bole, evo dodacu
            FacilityWithImagesViewModel model = new FacilityWithImagesViewModel
            {
                SportsFacility = rating.SportsFacility,
                IsRated = true,
                FacilityImages = _context.FacilityImages.Where(m => m.SportsFacilityId == facilityId).ToList()
            };

            var sports = _context.SportSportsFacilities.Where(x => x.SportsFacility_Id == facilityId).ToList();
            foreach (var s in sports)
            {
                var sp = _context.Sports.Find(s.Sport_Id);
                model.SportsFacility.TypesOfSports.Add(sp);
            }

            model.SportsFacility.Grades = _context.FacilityRatings.Where(x => x.SportsFacilityId == model.SportsFacility.Id).ToList();

            double sum = 0;
            foreach (var r in model.SportsFacility.Grades)
            {
                sum += r.Value;
            }

            if (model.SportsFacility.Grades.Count != 0)
            {
                model.SportsFacility.AverageGrade = sum / (double)model.SportsFacility.Grades.Count;
                _context.SaveChanges();
            }

            return View("Details", model);
        }

        public ActionResult DeleteRating(int facilityId)
        {
            var rater = User.Identity.GetUserId();
            var rate = _context.FacilityRatings.SingleOrDefault(ssf => ssf.SportsFacilityId == facilityId && ssf.RaterId == rater);
            if (rate != null)
            {
                _context.FacilityRatings.Remove(rate);
                _context.SaveChanges();
            }

            //  Dodaj slike i sportove u model ovde
            // Dodo sam i ovde

            FacilityWithImagesViewModel model = new FacilityWithImagesViewModel
            {
                SportsFacility = _context.SportsFacilities.Find(facilityId),
                IsRated = false, 
                FacilityImages= _context.FacilityImages.Where(m => m.SportsFacilityId == facilityId).ToList()
            };
            var sports = _context.SportSportsFacilities.Where(x => x.SportsFacility_Id == facilityId).ToList();
            foreach (var s in sports)
            {
                var sp = _context.Sports.Find(s.Sport_Id);
                model.SportsFacility.TypesOfSports.Add(sp);
            }
            
            model.SportsFacility.Grades = _context.FacilityRatings.Where(x => x.SportsFacilityId == model.SportsFacility.Id).ToList();

            double sum = 0;
            foreach (var r in model.SportsFacility.Grades)
            {
                sum += r.Value;
            }

            if (model.SportsFacility.Grades.Count != 0)
                model.SportsFacility.AverageGrade = sum / (double)model.SportsFacility.Grades.Count;
            else
                model.SportsFacility.AverageGrade = 0;
            
            _context.SaveChanges();

            return View("Details", model);
        }
    }
}