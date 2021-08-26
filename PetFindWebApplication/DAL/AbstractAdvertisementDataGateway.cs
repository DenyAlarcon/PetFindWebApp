using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetFindWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFindWebApplication.DAL
{
    public abstract class AbstractAdvertisementDataGateway
    {
        public abstract Task<IEnumerable<Advertisement>> SelectAll();
        public abstract Task<IEnumerable<Advertisement>> SelectUsersAdvertisements(int? id);
        public abstract Task<Advertisement> SelectById(int? id);
        public abstract Task Insert(
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
            );
        public abstract Task Update(
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
            IFormFile animalPhoto
            );
        public abstract Task<Advertisement> Delete(int? id);
        public abstract Task Save();
        public abstract SelectList SelectAnimalTypes();
        public abstract SelectList SelectCities();
        public abstract Task<bool> AdvertisementExists(int id);
    }
}
