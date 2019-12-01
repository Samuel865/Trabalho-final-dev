using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Services
{
    public class PetServices : IPetServices
    {
        private readonly DataContext _context;
        public PetServices(DataContext context)
        {
            _context = context;
        }
        public async Task Create(Pet pet)
        {
            _context.Pet.Add(pet);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pet = await _context.Pet.FirstOrDefaultAsync(p => p.Id == id);
            _context.Pet.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pet>> Get()
        {
            return await _context.Pet.Include(order => order.Orderes).Include(u => u.User).AsNoTracking().ToListAsync();
        }

        public async Task<Pet> GetById(int id)
        {
            return await _context.Pet.Include(order => order.Orderes).AsNoTracking().Include(u => u.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Pet pet)
        {
            _context.Entry<Pet>(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        } 
    }
}