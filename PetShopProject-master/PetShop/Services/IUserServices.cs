using System.Collections.Generic;
using System.Threading.Tasks;
using PetShop.Models;

namespace PetShop.Services
{
    public interface IUserServices
    {
         Task<IEnumerable<User>> Get();
         Task<User> GetById(int id);
         Task Create(User user);
         Task Update(User user);
         Task Delete(int id);
    }
}