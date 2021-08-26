using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetFindWebApplication.Data;
using PetFindWebApplication.Models;

namespace PetFindWebApplication.DAL
{
    //public class AccountGateway : IDataGateway<User>
    public class AccountGateway : AbstractAccountDataGateway
    {
        private readonly PetFindWebApplicationContext _context;

        public AccountGateway(PetFindWebApplicationContext context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<User>> SelectAll()
        {
            return await _context.User.ToListAsync();
        }

        public override async Task<User> SelectById(int? id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<User> SelectByUsernameAndPassword(string username, string password)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public override async Task Insert(string username, string firstName, string email, string password, string telNumber)
        {
            _context.Add(new User
            {
                Username = username,
                FirstName = firstName,
                Email = email,
                Password = password,
                TelNumber = telNumber
            });
            await Save();
        }

        public override async Task Update(int id, string username, string firstName, string email, string password, string telNumber)
        {
            var updatedUser = new User {
                Id = id,
                Username = username,
                FirstName = firstName,
                Email = email,
                Password = password,
                TelNumber = telNumber
            };
            _context.Entry(updatedUser).State = EntityState.Detached;
            _context.Update(updatedUser);
            await Save();
        }

        public override async Task<User> Delete(int? id)
        {
            var user = await SelectById(id);
            _context.User.Remove(user);
            await Save();
            return user;
        }

        public override async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public override async Task<bool> UsernameExists(string username)
        {
            return await _context.User.AnyAsync(u => u.Username == username);
        }
    }
}
