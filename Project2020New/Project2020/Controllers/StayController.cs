using Microsoft.AspNetCore.Mvc;
using Project2020.Models;
using Project2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2020.Controllers;

namespace Project2020.Controllers
{
    
    public class StayController : Controller
    {
        private readonly IStayRepository _stayRepository;
        private readonly IGuestRepository _guestRepository;

        public StayController(IStayRepository stayRepository, IGuestRepository guestRepository)
        {
            _stayRepository = stayRepository;
            _guestRepository = guestRepository;
        }
        //Should only load stays with the corresponding guestID
        
        public ViewResult Index()
        {         
            var model = _stayRepository.GetAllStays();
            return View(model);
        }

        //needs to load both guestID followed by stayID
        /*
        public ViewResult Details(string id, string stayid)
        {
            Guest guest = _guestRepository.GetGuest(id);
            Stay stay = _stayRepository.GetStay(stayid);

            if (stayid == null)
            {
                Response.StatusCode = 404;
                return View("StayNotFound", stayid);
            }

            StayDetailsViewModel stayDetailsViewModel = new StayDetailsViewModel  
            {
                PageTitle = "Stay Details",
                StayId = stayid,
                Id = id

            };

            return View(stayDetailsViewModel);
        }
        */
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Stay stay = _stayRepository.GetStay(id);
            StayEditViewModel stayEditViewModel = new StayEditViewModel
            {
                StayId = stay.StayId,
                StartDate = stay.StartDate,
                EndDate = stay.EndDate,
                EmergencyContactNumber = stay.EmergencyContactNumber,
                GuestID = stay.GuestID
            };
            return View(stayEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(StayEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Stay stay = _stayRepository.GetStay(model.StayId);

                stay.StayId = model.StayId;
                stay.StartDate = model.StartDate;
                stay.EndDate = model.EndDate;
                stay.EmergencyContactNumber = model.EmergencyContactNumber;
                stay.GuestID = model.GuestID;

                _stayRepository.Update(stay);
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateStayViewModel model)
        {

                Guest guest = _guestRepository.GetGuest(model.GuestID);

                Stay newStay = new Stay
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    EmergencyContactNumber = model.EmergencyContactNumber,
                    
                };

                _stayRepository.Add(newStay);
                return RedirectToAction("Index", new { stayid = newStay.StayId });
            }
            
        
    }
}
