using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetFindWebApplication.Controllers;
using PetFindWebApplication.Data;

namespace PetFindWebApplocationNUnitTests
{
    public class RegisterCorrectEmail
    {
        private PetFindWebApplicationContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PetFindWebApplicationContext>()
                      .UseInMemoryDatabase(databaseName: "TestDB")
                      .Options;
            _context = new PetFindWebApplicationContext(options);
        }
        
        [Test]
        [TestCase("username11", "user11", "user11@mail.ru", "pass11", "88005353535")]
        [TestCase("username12", "user12", "user12@yandex.ru", "pass12", "88005353535")]
        public void Register(string username, string firstName, string email, string password, string telNumber)
        {
            var controller = new AccountsController(_context);
            var response = controller.Register(username, firstName, email, password, telNumber);
            Assert.AreEqual(typeof(RedirectToActionResult), response.Result.GetType());
        }
    }
}
