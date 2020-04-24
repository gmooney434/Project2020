using Microsoft.AspNetCore.Mvc;
using Project2020.Models;
using Project2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Controllers
{
    public class HomeController : Controller
    { 
        private readonly IGuestRepository _guestRepository;

        public HomeController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public ViewResult Index()
        {
            var model = _guestRepository.GetAllGuests();
            return View(model);
        }
        
        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                Guest = _guestRepository.GetGuest(id),
                PageTitle = "Guest Details"
            };
;
            return View(homeDetailsViewModel);
        }
    }
}
