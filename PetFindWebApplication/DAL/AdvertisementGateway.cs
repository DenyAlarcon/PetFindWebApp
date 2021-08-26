using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetFindWebApplication.Data;
using PetFindWebApplication.Models;

namespace PetFindWebApplication.DAL
{
    //public class AdvertisementGateway : IDataGateway<Advertisement>
    public class AdvertisementGateway : AbstractAdvertisementDataGateway
    {
        private readonly PetFindWebApplicationContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdvertisementGateway(PetFindWebApplicationContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public override async Task<IEnumerable<Advertisement>> SelectAll()
        {
            var petFindWebApplicationContext = _context.Advertisement
                .Include(a => a.AdvertisementType)
                .Include(a => a.AnimalType)
                .Include(a => a.User)
                .Include(a => a.City);
            return await petFindWebApplicationContext.ToListAsync();
        }

        public override async Task<IEnumerable<Advertisement>> SelectUsersAdvertisements(int? id)
        {
            var petFindWebApplicationContext = _context.Advertisement
                .Include(a => a.AdvertisementType)
                .Include(a => a.AnimalType)
                .Include(a => a.User)
                .Include(a => a.City);
            return await petFindWebApplicationContext.Where(a => a.UserId == id).ToListAsync();
        }

        public override async Task<Advertisement> SelectById(int? id)
        {
            return await _context.Advertisement
                .Include(a => a.AdvertisementType)
                .Include(a => a.AnimalType)
                .Include(a => a.User)
                .Include(a => a.City)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        public override async Task Insert(
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
            int userId,
            int animalTypeId,
            int advertisementTypeId
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
            //            _context.Add(new Advertisement
            //            {
            //                AdvertisementName = advertisementName,
            //                DateFoundLost = dateFoundLost,
            //                AnimalBreed = animalBreed,
            //                AnimalName = animalName,
            //                AnimalColor = animalColor,
            //                PlaceFoundLost = placeFoundLost,
            //                AnimalSex = animalSex,
            //                Comment = comment,
            //                PersonToCall = personToCall,
            //                PersonTelNumber = personTelNumber,
            //                PersonEmail = personEmail,
            //                AnimalTypeId = animalTypeId,
            //                AdvertisementTypeId = advertisementTypeId,
            //                UserId = userId,
            //                CityId = cityId,
            //                AnimalPhoto = stream.ToArray()
            //            });
            //            await Save();
            //        }
            //    }
            //}
            _context.Add(new Advertisement
            {
                AdvertisementName = advertisementName,
                DateFoundLost = dateFoundLost,
                AnimalBreed = animalBreed,
                AnimalName = animalName,
                AnimalColor = animalColor,
                PlaceFoundLost = placeFoundLost,
                AnimalSex = animalSex,
                Comment = comment,
                PersonToCall = personToCall,
                PersonTelNumber = personTelNumber,
                PersonEmail = personEmail,
                AnimalTypeId = animalTypeId,
                AdvertisementTypeId = advertisementTypeId,
                UserId = userId,
                CityId = cityId
            });
            await Save();

        }

        public override async Task Update(
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
            int userId,
            int animalTypeId,
            int advertisementTypeId,
            string animalPhotoName,
            IFormFile animalPhotoFile
            )
        {
            if (animalPhotoFile != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(animalPhotoFile.FileName);
                string extension = Path.GetExtension(animalPhotoFile.FileName);
                animalPhotoName = fileName + extension;
                string animalPhotoPath = Path.Combine(wwwRootPath + "/Image/", animalPhotoFile.FileName);
                using (var fileStream = new FileStream(animalPhotoPath, FileMode.Create))
                {
                    await animalPhotoFile.CopyToAsync(fileStream);
                    var updatedAdvertisement = new Advertisement
                    {
                        Id = id,
                        AdvertisementName = advertisementName,
                        DateFoundLost = dateFoundLost,
                        AnimalBreed = animalBreed,
                        AnimalName = animalName,
                        AnimalColor = animalColor,
                        PlaceFoundLost = placeFoundLost,
                        AnimalSex = animalSex,
                        Comment = comment,
                        PersonToCall = personToCall,
                        PersonTelNumber = personTelNumber,
                        PersonEmail = personEmail,
                        AnimalTypeId = animalTypeId,
                        AdvertisementTypeId = advertisementTypeId,
                        UserId = userId,
                        CityId = cityId,
                        AnimalPhotoName = animalPhotoName,
                        AnimalPhotoFile = animalPhotoFile
                    };
                    _context.Update(updatedAdvertisement);
                    await Save();
                }
            }
            else
            {
                var updatedAdvertisement = new Advertisement
                {
                    Id = id,
                    AdvertisementName = advertisementName,
                    DateFoundLost = dateFoundLost,
                    AnimalBreed = animalBreed,
                    AnimalName = animalName,
                    AnimalColor = animalColor,
                    PlaceFoundLost = placeFoundLost,
                    AnimalSex = animalSex,
                    Comment = comment,
                    PersonToCall = personToCall,
                    PersonTelNumber = personTelNumber,
                    PersonEmail = personEmail,
                    AnimalTypeId = animalTypeId,
                    AdvertisementTypeId = advertisementTypeId,
                    UserId = userId,
                    CityId = cityId,
                    AnimalPhotoName = animalPhotoName
                };
                _context.Update(updatedAdvertisement);
                await Save();
            }
            

            
  

            //foreach (var img in animalPhoto)
            //{
            //    if (img.Length > 0)
            //    {
            //        using (var stream = new MemoryStream())
            //        {
            //            await img.CopyToAsync(stream);
            //            var updatedAdvertisement = new Advertisement
            //            {
            //                Id = id,
            //                AdvertisementName = advertisementName,
            //                DateFoundLost = dateFoundLost,
            //                AnimalBreed = animalBreed,
            //                AnimalName = animalName,
            //                AnimalColor = animalColor,
            //                PlaceFoundLost = placeFoundLost,
            //                AnimalSex = animalSex,
            //                Comment = comment,
            //                PersonToCall = personToCall,
            //                PersonTelNumber = personTelNumber,
            //                PersonEmail = personEmail,
            //                AnimalTypeId = animalTypeId,
            //                AdvertisementTypeId = advertisementTypeId,
            //                UserId = userId,
            //                CityId = cityId,
            //                AnimalPhoto = stream.ToArray()
            //            };
            //            _context.Update(updatedAdvertisement);
            //            await Save();
            //        }
            //    }
            //}

        }

        public override async Task<Advertisement> Delete(int? id)
        {
            var advertisement = await SelectById(id);
            _context.Advertisement.Remove(advertisement);
            await Save();
            return advertisement;
        }

        public override async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public override SelectList SelectAnimalTypes()
        {
            return new SelectList(_context.AnimalType, "Id", "Type", 1);
        }

        public override SelectList SelectCities()
        {
            return new SelectList(_context.City, "Id", "CityName", 1);
        }

        public override async Task<bool> AdvertisementExists(int id)
        {
            return await _context.Advertisement.AnyAsync(e => e.Id == id);
        }
    }
}
