using System.Collections.Generic;
using System.Threading.Tasks;
using PetShop.Models;

namespace PetShop.Services
{
    public interface IPetServices
    {
        Task<IEnumerable<Pet>> Get();
         Task<Pet> GetById(int id);
         Task Create(Pet pet);
         Task Update(Pet pet);
         Task Delete(int id);     
    }
}