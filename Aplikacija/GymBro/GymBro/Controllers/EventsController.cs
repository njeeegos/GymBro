using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using GymBro.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using PagedList.Mvc;
using PagedList;

namespace GymBro.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {

        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index(string sortBy, int? i)
        {

            ViewBag.DatumSort = String.IsNullOrEmpty(sortBy) ? "Datum desc" : "";

            var events = _context.Events.ToList();

            switch (sortBy)
            {
                case "Datum desc":
                    events = events.OrderByDescending(x => x.DateAndTime).ToList();
                    break;
                case "Datum":
                    events = events.OrderBy(x => x.DateAndTime).ToList();
                    break;
                default:
                    events = events.OrderBy(x => x.DateAndTime).ToList();
                    break;
            }

         
            var lista = new List<EventDetailsViewModel>();
            foreach(var item in events)
            {
                var viewModel = new EventDetailsViewModel
                {
                    Event = item,
                    EventCreator = _context.Users.SingleOrDefault(u => u.Id == item.EventCreatorId),
                    Activity = _context.Sports.SingleOrDefault(s => s.Id == item.SportId),
                    Location = _context.SportsFacilities.SingleOrDefault(sf => sf.Id == item.LocationId)
                };

                lista.Add(viewModel);
            }
            
            return View(lista.ToList().ToPagedList(i ?? 1, 3));
        }


        public ActionResult MyEvents(int? i)
        {
            var userid = User.Identity.GetUserId();
            var events = _context.Events.Where(e => e.EventCreatorId == userid).ToList();



            var lista = new List<EventDetailsViewModel>();
            foreach (var item in events)
            {
                var viewModel = new EventDetailsViewModel
                {
                    Event = item,
                    EventCreator = _context.Users.SingleOrDefault(u => u.Id == item.EventCreatorId),
                    Activity = _context.Sports.SingleOrDefault(s => s.Id == item.SportId),
                    Location = _context.SportsFacilities.SingleOrDefault(sf => sf.Id == item.LocationId)
                };

                lista.Add(viewModel);
            }
            return View("MyEvents", lista.ToList().ToPagedList(i ?? 1, 3));
        }
        public ActionResult Details(int id)
        {
            var eventt = _context.Events.Find(id);
            if (eventt == null)
                return HttpNotFound();

            var creator = _context.Users.SingleOrDefault(u => u.Id == eventt.EventCreatorId);
            if (creator == null)
                return HttpNotFound();

            var facility = _context.SportsFacilities.SingleOrDefault(sf => sf.Id == eventt.LocationId);
            if(facility == null)
            {

            }

            var sport = _context.Sports.SingleOrDefault(s => s.Id == eventt.SportId);

            var isCreator = User.Identity.GetUserId() == creator.Id ? true : false;

            var eventParticipants = _context.EventParticipants.Where(evp => evp.EventId == eventt.Id).ToList();
            var participants = new List<ApplicationUser>();

            foreach(var item in eventParticipants)
            {
                var participant = _context.Users.SingleOrDefault(u => u.Id == item.UserId);
                if (participant != null)
                    participants.Add(participant);
            }

            var viewModel = new EventDetailsViewModel
            {
                Event = eventt,
                EventCreator = creator,
                Location = facility,
                Activity = sport,
                Participants = participants,
                IsCreator = isCreator
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var sports = _context.Sports.ToList();
            var facilities = _context.SportsFacilities.ToList();
            var viewModel = new EventFormViewModel
            {
                Event = new Event
                {
                    EventCreatorId = User.Identity.GetUserId()
                },
                Sports = sports,
                SportsFacilities = facilities
            };

            return View("EventForm", viewModel);
        }


        public ActionResult Edit(int id)
        {
            var sports = _context.Sports.ToList();
            var facilities = _context.SportsFacilities.ToList();
            var eventt = _context.Events.Find(id);
            if (eventt == null)
                return HttpNotFound();

            var viewModel = new EventFormViewModel
            {
                Event = eventt,
                Sports = sports,
                SportsFacilities = facilities
            };
            return View("EventForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EventFormViewModel model)
        {
            if(!ModelState.IsValid)
            {
                // Nevalidan unos - ucitavamo prethodno unete podatke i vracamo u formu
                var sports = _context.Sports.ToList();
                var facilities = _context.SportsFacilities.ToList();
                var viewModel = new EventFormViewModel
                {
                    Event = new Event
                    {
                        EventCreatorId = User.Identity.GetUserId(),
                        CurrentNumber = 0
                    },
                    Sports = sports,
                    SportsFacilities = facilities
                };

                return View("EventForm", viewModel);
            }
            if(model.Event.Id == 0)
            {
                //  Dodavanje novog dogadjaja
                var eventt = new Event
                {
                    DateAndTime = model.Event.DateAndTime,
                    MaxNumber = model.Event.MaxNumber,
                    CurrentNumber = 0,
                    SportId = model.Event.SportId,
                    LocationId = model.Event.LocationId,
                    EventCreatorId = User.Identity.GetUserId(),
                };

                _context.Events.Add(eventt);
            }
            else
            {
                //  Editovanje dogadjaja
                var eventInDb = _context.Events.Single(e => e.Id == model.Event.Id);
                eventInDb.DateAndTime = model.Event.DateAndTime;
                eventInDb.MaxNumber = model.Event.MaxNumber;
                eventInDb.CurrentNumber = model.Event.CurrentNumber;
                eventInDb.SportId = model.Event.SportId;
                eventInDb.LocationId = model.Event.LocationId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Events");
        }

        
        public ActionResult SignUp(int id)
        {
            var eventInDb = _context.Events.Single(e => e.Id == id);
            if (eventInDb == null)
                return HttpNotFound();

            //var user = _context.Users.SingleOrDefault(u => u.Id == User.Identity.GetUserId());
            //eventt.Participants.Add(user);

            var participants = _context.EventParticipants.Where(evp => evp.EventId == eventInDb.Id).ToList();
            var userId = User.Identity.GetUserId();
            if (participants.Contains(_context.EventParticipants.SingleOrDefault(evp => evp.EventId == eventInDb.Id && evp.UserId == userId)))
            {
                //Poruka da smo vec prijavljeni
                return RedirectToAction("Index");
            }

            if(participants.Count >= eventInDb.MaxNumber)
            {
                //Popunjena mesta
            }

            var signup = new EventParticipant
            {
                EventId = id,
                UserId = User.Identity.GetUserId()
            };

            _context.EventParticipants.Add(signup);

            eventInDb.CurrentNumber = participants.Count + 1;

            _context.SaveChanges();

            return RedirectToAction("Details", "Events", new { id = eventInDb.Id });
        }


        public ActionResult CancelEvent(int id)
        {
            var eventt = _context.Events.Find(id);

            var participants = _context.EventParticipants.Where(evp => evp.EventId == eventt.Id).ToList();

            foreach(var item in participants)
            {
                _context.EventParticipants.Remove(item);
                _context.SaveChanges();
            }
            if (eventt != null)
                _context.Events.Remove(eventt);

            _context.SaveChanges();

            return RedirectToAction("Index", "Events");
        }


        /*[HttpPost]
            public ActionResult Delete(int id)
            {
                var events = _context.Events.Find(id);
                if (events != null)
                    _context.Events.Remove(events);

                _context.SaveChanges();

                return View(events);
            }*/

       
    }
}