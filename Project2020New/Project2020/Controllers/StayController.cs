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
        
        public ViewResult Details(int Stayid)
        {
            StayDetailsViewModel stayDetailsViewModel = new StayDetailsViewModel
            {
                Stay = _stayRepository.GetStay(Stayid),
                PageTitle = "Stay Details"
            };            
            return View(stayDetailsViewModel);
        }
    }
}
