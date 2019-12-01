using System.Threading.Tasks;
using PetShop.Models;

namespace PetShop.Services
{
    public interface IAuthServices
    {
         Task<User> Register(User user, string password);
         Task<User> Login (string username, string password);
         Task<bool> UserExists(string username);
    }
}