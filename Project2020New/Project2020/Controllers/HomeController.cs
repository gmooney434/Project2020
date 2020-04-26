
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
using Microsoft.Extensions.Logging;

namespace Project2020.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public HomeController(IGuestRepository guestRepository, IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger)
        {


            _guestRepository = guestRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        public ViewResult Index()
        {
            var model = _guestRepository.GetAllGuests();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");


            Guest guest = _guestRepository.GetGuest(id.Value);

            if(guest == null)
            {
                Response.StatusCode = 404;
                return View("GuestNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                Guest = guest,
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
                    if(model.ExistingPhotoPath != null)
                    {
                        String filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);

                    }
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
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }

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
