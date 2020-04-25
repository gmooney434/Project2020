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

        public ViewResult Index()
        {
            var model = _stayRepository.GetAllStays();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Stay stay)
        {
            if (ModelState.IsValid)
            {
                Stay newStay = _stayRepository.Add(stay);
                return RedirectToAction("~/Stay/details", new { Stayid = newStay.StayId });
            }
            else
            {
                return View();
            }
        }
        public string List()
        {
            return "List() of StayController";
        }
        public ViewResult Details(int Stayid)
        {
            StayDetailsViewModel homeDetailsViewModel = new StayDetailsViewModel
            {
                Stay = _stayRepository.GetStay(Stayid),
                PageTitle = "Stay Details"
            };
            ;
            return View(homeDetailsViewModel);
        }
    }
}
