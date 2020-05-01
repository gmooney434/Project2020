using Microsoft.AspNetCore.Mvc;
using Project2020.Models;
using Project2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Controllers
{
    public class StayController : Controller
    {
        private readonly IStayRepository _stayRepository;

        public StayController(IStayRepository stayRepository)
        {
            _stayRepository = stayRepository;
        }
        //Should only load stays with the corresponding guestID
        public ViewResult Index()
        {
          
            var model = _stayRepository.GetAllStays();
            return View(model);
        }

        //needs to load both guestID followed by stayID
        public ViewResult Details(int? StayId)
        {
            Stay stay = _stayRepository.GetStay(StayId.Value);

            if (stay == null)
            {
                Response.StatusCode = 404;
                return View("StayNotFound", StayId.Value);
            }

            StayDetailsViewModel stayDetailsViewModel = new StayDetailsViewModel
            {
                Stay = stay,
                PageTitle = "Stay Details"
            };

            return View(stayDetailsViewModel);
        }

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
    }
}
