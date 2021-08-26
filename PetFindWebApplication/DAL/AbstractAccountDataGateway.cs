using PetFindWebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetFindWebApplication.DAL
{
    //public interface IDataGateway<T> where T : class
    public abstract class AbstractAccountDataGateway
    {
        //public abstract Task<IEnumerable<T>> SelectAll();
        //public abstract Task<T> SelectById(int? id);
        //public abstract Task<T> Delete(int? id);
        public abstract Task<IEnumerable<User>> SelectAll();
        public abstract Task<User> SelectById(int? id);
        public abstract Task<User> SelectByUsernameAndPassword(string username, string password);
        public abstract Task Insert(string username, string firstName, string email, string password, string telNumber);
        public abstract Task Update(int id, string username, string firstName, string email, string password, string telNumber);
        public abstract Task<User> Delete(int? id);
        public abstract Task Save();
        public abstract Task<bool> UsernameExists(string username);
    }
}
