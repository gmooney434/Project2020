﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Project2020.Models;
using Project2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Project2020.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IGuestRepository guestRepository, IHostingEnvironment hostingEnvironment)
        {
            _guestRepository = guestRepository;
            this.hostingEnvironment = hostingEnvironment;
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

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Guest guest = _guestRepository.GetGuest(id);
            GuestEditViewModel guestEditViewModel = new GuestEditViewModel
            {
                Id = guest.Id,
                Forename = guest.Forename,
                Surname = guest.Surname,
                Date_Of_Birth = guest.Date_Of_Birth,
                ExistingPhotoPath = guest.PhotoPath
            };
            return View(guestEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(GuestEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guest guest = _guestRepository.GetGuest(model.Id);
                guest.Forename = model.Forename;
                guest.Surname = model.Surname;
                guest.Date_Of_Birth = model.Date_Of_Birth;
                if (model.Photos != null)
                {
                    //if(model.ExistingPhotoPath != null)
                  //  {
                    //    String filePath = Path.Combine(hostingEnvironment.WebRootPath,
                      //      "images", model.ExistingPhotoPath);
                       // System.IO.File.Delete(filePath);

                   // }
                    guest.PhotoPath = ProcessUploadedFile(model);
                }             

                _guestRepository.Update(guest);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(GuestCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    String filepath = Path.Combine(uploadsFolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filepath, FileMode.Create));
                }
            }

            return uniqueFileName;
        }
    
        [HttpPost]
        public IActionResult Create(GuestCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Guest newGuest = new Guest
                {
                    Forename = model.Forename,
                    Surname = model.Surname,
                    Date_Of_Birth = model.Date_Of_Birth,
                    PhotoPath = uniqueFileName
                };

                _guestRepository.Add(newGuest);
                return RedirectToAction("details", new { id = newGuest.Id });
            }
            return View();
        }
    }
}
