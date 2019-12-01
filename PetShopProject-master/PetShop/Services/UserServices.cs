using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Services
{
    public class UserServices : IUserServices
    {
        private readonly DataContext _context;

        public UserServices(DataContext context)
        {
            _context = context;
        }
        public async Task Create(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();   
        }

        public async Task Delete(int id)
        {
            User user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.User.Include(p => p.Pets).AsNoTracking().ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.User.Include( pet => pet.Pets).AsNoTracking().FirstOrDefaultAsync( u => u.Id == id);                                          
        }

        public async Task Update(User user)
        {
            _context.Entry<User>(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}