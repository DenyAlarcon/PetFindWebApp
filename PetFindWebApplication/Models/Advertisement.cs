using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetFindWebApplication.Models
{
    public class Advertisement
    {
        [Display(Name = "Объявление")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название объявления")]
        public string AdvertisementName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        public DateTime DateFoundLost { get; set; }

        [Display(Name = "Порода")]
        public string AnimalBreed { get; set; }

        [Display(Name = "Кличка")]
        public string AnimalName { get; set; }

        [Display(Name = "Окрас")]
        public string AnimalColor { get; set; }

        [Display(Name = "Пол")]
        public string AnimalSex { get; set; }

        [Display(Name = "Название файла с фото питомца")]
        public string AnimalPhotoName { get; set; }

        [NotMapped]
        [Display(Name = "Фото питомца")]
        public IFormFile AnimalPhotoFile { get; set; }

        [Display(Name = "Место находки/потери")]
        public string PlaceFoundLost { get; set; }

        [Display(Name = "Комментарий")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Required]
        [Display(Name = "Имя для связи")]
        public string PersonToCall { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PersonTelNumber { get; set; }

        [EmailAddress]
        [Display(Name = "Почта")]
        public string PersonEmail { get; set; }

        [Required]
        [Display(Name = "Животное")]
        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; }

        [Required]
        [Display(Name = "Пользователь создавший объявление")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Display(Name = "Тип объявления")]
        public int AdvertisementTypeId { get; set; }
        public AdvertisementType AdvertisementType { get; set; }

        [Required]
        [Display(Name = "Город")]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
