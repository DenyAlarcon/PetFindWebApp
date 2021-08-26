using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PetFindWebApplication.Data;
using System.Security.Claims;
using PetFindWebApplication.DAL;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using PetFindWebApplication.Factories;

namespace PetFindWebApplication.Controllers
{
    public class AccountsController : BaseController
    {
        //private readonly AccountGateway _accountGateway;
        private readonly AbstractAccountDataGateway _accountGateway;


        public AccountsController(PetFindWebApplicationContext context)
        {
            //_accountGateway = new AccountGateway(context);
            AbstractAccountFactory factory = new AccountFactory();
            _accountGateway = factory.CreateAccountGateway(context);
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View(await _accountGateway.SelectAll());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _accountGateway.SelectById(id);

            if (id == null || user == null)
            {
                return NotFound();
            }

            if (id != user.Id)
            {
                return BadRequest();
            }
            return View(user);
        }

        // GET: Accounts/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Accounts/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username, string firstName, string email, string password, string telNumber)
        {
            if (!ModelState.IsValid) return View();
            var match = Regex.Match(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return View();
            }
            if (await _accountGateway.UsernameExists(username))
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                return View();
            }
            await _accountGateway.Insert(username, firstName, email, password, telNumber);
            var user = await _accountGateway.SelectByUsernameAndPassword(username, password);
            //await Authenticate(username, user.Id); // аутентификация
            return RedirectToAction("Index", "Home");
        }

        // GET: Accounts/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Accounts/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                ModelState.AddModelError("Username", "Некорректный логин");
            }
            else if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Некорректный пароль");
            }
            else
            {
                var userDb = await _accountGateway.SelectByUsernameAndPassword(username, password);
                if (userDb != null)
                {
                    await Authenticate(userDb.Username, userDb.Id); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Пользователя с таким логином и(или) паролем не существует");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Accounts");
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || (int)ViewData["currentUserId"] != id)
            {
                return NotFound();
            }

            var user = await _accountGateway.SelectById(id);

            if (user == null )
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string username, string firstName, string email, string password, string telNumber)
        {
            if (!ModelState.IsValid) return View();

            await _accountGateway.Update(id, username, firstName, email, password, telNumber);
            return RedirectToAction("Details", new { id });
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || (int)ViewData["currentUserId"] != id)
            {
                return NotFound();
            }

            var user = await _accountGateway.SelectById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var user = await _accountGateway.Delete(id);
            ViewData["DeletedUser"] = user.Username;
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string username, int userId)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };
            // создаем объект ClaimsIdentity
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
