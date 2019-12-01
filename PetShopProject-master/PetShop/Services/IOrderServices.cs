using System.Collections.Generic;
using System.Threading.Tasks;
using PetShop.Models;

namespace PetShop.Services
{
    public interface IOrderServices
    {
         Task<IEnumerable<Order>> Get();
         Task<Order> GetById(int id);
         Task Create(Order order);
         Task Update(Order order);
         Task Delete(int id);          
    }
}