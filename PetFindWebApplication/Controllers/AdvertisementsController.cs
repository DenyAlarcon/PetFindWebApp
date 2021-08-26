using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetFindWebApplication.DAL;
using PetFindWebApplication.Data;
using PetFindWebApplication.Factories;

namespace PetFindWebApplication.Controllers
{
    [Authorize]
    public class AdvertisementsController : BaseController
    {
        //private readonly AdvertisementGateway _advertisementGateway;
        private readonly AbstractAdvertisementDataGateway _advertisementGateway;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdvertisementsController(PetFindWebApplicationContext context, IWebHostEnvironment webHostEnvironment)
        {
            //_advertisementGateway = new AdvertisementGateway(context);
            AbstractAdvertisementFactory factory = new AdvertisementFactory();
            _advertisementGateway = factory.CreateAdvertisementGateway(context, webHostEnvironment);
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Advertisements
        [AllowAnonymous]
        public async Task<IActionResult> Index(string username)
        {
            if (string.IsNullOrEmpty(username)) return View(await _advertisementGateway.SelectAll());
            var userId = (int)ViewData["currentUserId"];
            return userId != 0 ? View(await _advertisementGateway.SelectUsersAdvertisements(userId)) : View(await _advertisementGateway.SelectAll());
        }

        // GET: Advertisements/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _advertisementGateway.SelectById(id);

            return View(advertisement);
        }

        // GET: Advertisements/CreateFoundAdvertisement
        public IActionResult CreateFoundAdvertisement()
        {
            ViewBag.animalTypesList = _advertisementGateway.SelectAnimalTypes();
            ViewBag.citiesList = _advertisementGateway.SelectCities();
            return View();
        }

        // POST: Advertisements/CreateFoundAdvertisement
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFoundAdvertisement(
            int cityId,
            string advertisementName,
            DateTime dateFoundLost,
            string animalBreed,
            string animalColor,
            string animalSex,
            string placeFoundLost,
            string comment,
            string personToCall,
            string personTelNumber,
            string personEmail,
            int animalTypeId
            //List<IFormFile> animalPhoto
            )
        {
            //foreach (var img in animalPhoto)
            //{
            //    if (img.Length > 0)
            //    {
            //        using (var stream = new MemoryStream())
            //        {
            //            await img.CopyToAsync(stream);
            //            ViewBag.ImageDataUrl = img;
            //        }
            //    }
            //}

            int advertisementTypeId = 1;
            int userId = (int)ViewData["currentUserId"];
            string animalName = "";

            if (!ModelState.IsValid) return View();
            var match = Regex.Match(personTelNumber, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return View();
            }
            await _advertisementGateway.Insert(
                cityId,
                advertisementName,
                dateFoundLost,
                animalBreed,
                animalName,
                animalColor,
                animalSex,
                placeFoundLost,
                comment,
                personToCall,
                personTelNumber,
                personEmail,
                userId,
                animalTypeId,
                advertisementTypeId
                //animalPhoto
                );
            return RedirectToAction(nameof(Index));
        }

        // GET: Advertisements/CreateLostAdvertisement
        public IActionResult CreateLostAdvertisement()
        {
            ViewBag.animalTypesList = _advertisementGateway.SelectAnimalTypes();
            ViewBag.citiesList = _advertisementGateway.SelectCities();
            return View();
        }

        // POST: Advertisements/CreateLostAdvertisement
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLostAdvertisement(
            int cityId,
            string advertisementName,
            DateTime dateFoundLost,
            string animalBreed,
            string animalName,
            string animalColor,
            string animalSex,
            string placeFoundLost,
            string comment,
            string personToCall,
            string personTelNumber,
            string personEmail,
            int animalTypeId
            //List<IFormFile> animalPhoto
            )
        {
            int advertisementTypeId = 2;
            int userId = (int)ViewData["currentUserId"];

            if (!ModelState.IsValid) return View();
            var match = Regex.Match(personTelNumber, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return View();
            }
            
            await _advertisementGateway.Insert(
                cityId,
                advertisementName,
                dateFoundLost,
                animalBreed,
                advertisementName,
                animalColor,
                animalSex,
                placeFoundLost,
                comment,
                personToCall,
                personTelNumber,
                personEmail,
                userId,
                animalTypeId,
                advertisementTypeId
                //animalPhoto
                );
            return RedirectToAction(nameof(Index));
        }

        // GET: Advertisements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _advertisementGateway.SelectById(id);

            if (advertisement == null || (int)ViewData["currentUserId"] != advertisement.UserId)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            int cityId,
            string advertisementName,
            DateTime dateFoundLost,
            string animalBreed,
            string animalName,
            string animalColor,
            string animalSex,
            string placeFoundLost,
            string comment,
            string personToCall,
            string personTelNumber,
            string personEmail,
            int animalTypeId,
            int userId,
            int advertisementTypeId,
            string animalPhotoName,
            IFormFile animalPhotoFile
            )
        {
            if (! await _advertisementGateway.AdvertisementExists(id) || (int)ViewData["currentUserId"] != userId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View();   

            await _advertisementGateway.Update(
                id,
                cityId,
                advertisementName,
                dateFoundLost,
                animalBreed,
                animalName,
                animalColor,
                animalSex,
                placeFoundLost,
                comment,
                personToCall,
                personTelNumber,
                personEmail,
                userId,
                animalTypeId,
                advertisementTypeId,
                animalPhotoName,
                animalPhotoFile);
            return RedirectToAction("Details", new { id });
        }

        // GET: Advertisements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _advertisementGateway.SelectById(id);

            if (advertisement == null || (int)ViewData["currentUserId"] != advertisement.UserId)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisement = await _advertisementGateway.Delete(id);
            ViewData["DeletedAdvertisement"] = advertisement.AdvertisementName;
            return RedirectToAction(nameof(Index));
        }
    }
}
