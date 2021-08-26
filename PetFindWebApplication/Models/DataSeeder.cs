using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetFindWebApplication.Data;
using System;
using System.Linq;

namespace PetFindWebApplication.Models
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new PetFindWebApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PetFindWebApplicationContext>>());
            //Lookup for anu users
            if (!context.User.Any())
            {
                context.User.AddRange(
                    new User
                    {
                        Username = "username1",
                        FirstName = "user1",
                        Email = "user1@mail.ru",
                        Password = "pass1",
                        TelNumber = "88005353535"
                    },

                    new User
                    {
                        Username = "username2",
                        FirstName = "user2",
                        Email = "user2@mail.ru",
                        Password = "pass2",
                        TelNumber = "88005353535"
                    },

                    new User
                    {
                        Username = "username3",
                        FirstName = "user3",
                        Email = "user3@mail.ru",
                        Password = "pass3",
                        TelNumber = "88005353535"
                    },

                    new User
                    {
                        Username = "username4",
                        FirstName = "user4",
                        Email = "user4@mail.ru",
                        Password = "pass4",
                        TelNumber = "88005353535"
                    }
                );
                context.SaveChanges();
            }

            // Look for any advertisements types
            if (!context.AdvertisementType.Any())
            {
                context.AdvertisementType.AddRange(
                   new AdvertisementType
                   {
                       Type = "Пропажа"
                   },

                   new AdvertisementType
                   {
                       Type = "Находка"
                   }
               );
                context.SaveChanges();
            }

            // Look for any advertisements types
            if (!context.AnimalType.Any())
            {
                context.AnimalType.AddRange(
                    new AnimalType
                    {
                        Type = "Собака"
                    },

                    new AnimalType
                    {
                        Type = "Кошка"
                    },

                    new AnimalType
                    {
                        Type = "Попугай"
                    },

                    new AnimalType
                    {
                        Type = "Черепаха"
                    },

                    new AnimalType
                    {
                        Type = "Свинка"
                    }
                );
                context.SaveChanges();
            }

            // Look for any cities
            if (!context.City.Any())
            {
                context.City.AddRange(
                   new City
                   {
                       CityName = "Москва"
                   },

                   new City
                   {
                       CityName = "Санкт-Петербург"
                   }
               );
                context.SaveChanges();
            }

            // Look for any advertisements
            if (!context.Advertisement.Any())
            {
                context.Advertisement.AddRange(
                    new Advertisement
                    {
                        AdvertisementName = "Потерял Хаски (Москва)",
                        DateFoundLost = DateTime.Parse("2014-3-13"),
                        AnimalBreed = "Хаски",
                        AnimalName = "Джесси",
                        AnimalColor = "Серый",
                        PlaceFoundLost = "Place1",
                        AnimalSex = "Девочка",
                        Comment = "Comment1",
                        PersonToCall = "Александр",
                        PersonTelNumber = "88805353535",
                        PersonEmail = "someemail1@mail.ru",
                        AnimalTypeId = 4,
                        AdvertisementTypeId = 2,
                        UserId = 1,
                        CityId = 1,
                    },

                    new Advertisement
                    {
                        AdvertisementName = "Потерял немецкую овчарку (Москва)",
                        DateFoundLost = DateTime.Parse("2014-3-13"),
                        AnimalBreed = "Немецкая овчарка",
                        AnimalName = "Рекс",
                        AnimalColor = "Темно коричневый",
                        PlaceFoundLost = "Place2",
                        AnimalSex = "Мальчик",
                        Comment = "Comment2",
                        PersonToCall = "Петр",
                        PersonTelNumber = "88805353535",
                        PersonEmail = "someemail2@mail.ru",
                        AnimalTypeId = 4,
                        AdvertisementTypeId = 2,
                        UserId = 1,
                        CityId = 2,
                    },

                    new Advertisement
                    {
                        AdvertisementName = "Потеряла сфинкса (Санкт-Петербург)",
                        DateFoundLost = DateTime.Parse("2014-3-13"),
                        AnimalBreed = "Сфинкс",
                        AnimalName = "Фараон",
                        AnimalColor = "Телесный оттенок",
                        PlaceFoundLost = "Place3",
                        AnimalSex = "Мальчик",
                        Comment = "Comment3",
                        PersonToCall = "Анастасия",
                        PersonTelNumber = "88805353535",
                        PersonEmail = "someemail3@mail.ru",
                        AnimalTypeId = 4,
                        AdvertisementTypeId = 2,
                        UserId = 1,
                        CityId = 2,
                    },

                    new Advertisement
                    {
                        AdvertisementName = "Потеряла мопса (Москва)",
                        DateFoundLost = DateTime.Parse("2014-3-13"),
                        AnimalBreed = "Мопс",
                        AnimalName = "Глори",
                        AnimalColor = "Серый",
                        PlaceFoundLost = "Place4",
                        AnimalSex = "Девочка",
                        Comment = "Comment4",
                        PersonToCall = "Надежда",
                        PersonTelNumber = "88805353535",
                        PersonEmail = "someemail4@mail.ru",
                        AnimalTypeId = 4,
                        AdvertisementTypeId = 2,
                        UserId = 1,
                        CityId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
