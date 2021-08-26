using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetFindWebApplication.Controllers;
using PetFindWebApplication.Data;

namespace PetFindWebApplocationNUnitTests
{
    public class RegisterIncorrectEmail
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
        [TestCase("username13", "user13", "user13@", "pass13", "88005353535")]
        [TestCase("username13", "user13", "user13@mail", "pass13", "88005353535")]
        [TestCase("username13", "user13", "@mail.ru", "pass13", "88005353535")]
        [TestCase("username13", "user13", "user13@mail.r", "pass13", "88005353535")]
        [TestCase("username13", "user13", "user13mail.ru", "pass13", "88005353535")]
        public void Register(string username, string firstName, string email, string password, string telNumber)
        {
            var controller = new AccountsController(_context);
            var response = controller.Register(username, firstName, email, password, telNumber);
            Assert.AreEqual(typeof(ViewResult), response.Result.GetType());
        }
    }
}
