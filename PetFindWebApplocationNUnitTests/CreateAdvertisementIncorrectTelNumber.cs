using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetFindWebApplication.Controllers;
using PetFindWebApplication.Data;
using System;


namespace PetFindWebApplocationNUnitTests
{
    class CreateAdvertisementIncorrectTelNumber
    {
        //private PetFindWebApplicationContext _context;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        //[SetUp]
        //public void Setup()
        //{
        //    var options = new DbContextOptionsBuilder<PetFindWebApplicationContext>()
        //              .UseInMemoryDatabase(databaseName: "TestDB")
        //              .Options;
        //    _context = new PetFindWebApplicationContext(options);
        //    _webHostEnvironment = new WebHostEnvironment();
        //}

        //[Test]
        //[TestCase(1, "Потерял собаку", "2014-3-13", "Хаски", "Джесси", "Серый", "Девочка", "Около парка Садки", "Комментарий", "Александр", "912388005353535", "sasha@mail.ru", 1)]
        //[TestCase(1, "Потерял собаку", "2014-3-13", "Хаски", "Джесси", "Серый", "Девочка", "Около парка Садки", "Комментарий", "Александр", "+77(800)5353535", "sasha@mail.ru", 1)]
        //[TestCase(1, "Потерял собаку", "2014-3-13", "Хаски", "Джесси", "Серый", "Девочка", "Около парка Садки", "Комментарий", "Александр", "+a(800)5353535", "sasha@mail.ru", 1)]

        //public void CreateAdvertisement(
        //    int cityId,
        //    string advertisementName,
        //    string dateFoundLost,
        //    string animalBreed,
        //    string animalName,
        //    string animalColor,
        //    string animalSex,
        //    string placeFoundLost,
        //    string comment,
        //    string personToCall,
        //    string personTelNumber,
        //    string personEmail,
        //    int animalTypeId)
        //{
        //    var controller = new AdvertisementsController(_context, _webHostEnvironment);
        //    var viewResult = controller.CreateLostAdvertisement() as ViewResult;
        //    viewResult.ViewData["currentUserId"] = 1;
        //    var response = controller.CreateLostAdvertisement(
        //        cityId,
        //        advertisementName,
        //        DateTime.Parse(dateFoundLost),
        //        animalBreed,
        //        animalName,
        //        animalColor,
        //        animalSex,
        //        placeFoundLost,
        //        comment,
        //        personToCall,
        //        personTelNumber,
        //        personEmail,
        //        animalTypeId);
        //    Assert.AreEqual(typeof(ViewResult), response.Result.GetType());
        //}
    }
}
