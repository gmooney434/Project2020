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

        public ActionResult Index()
        {
            Guest guest = _guestRepository.GetGuest(id.Value);
            var model = _stayRepository.GetAllStays();
            return View(model);
        }


        public ViewResult Details(int? id)
        {
            

            if (stay == null)
            {
                Response.StatusCode = 404;
                return View("GuestNotFound", id.Value);
            }

            StayDetailsViewModel stayDetailsViewModel = new StayDetailsViewModel
            {
                Stay = stay,
                PageTitle = "Stay Details"
            };

            return View(stayDetailsViewModel);
        }
       

    }
}
