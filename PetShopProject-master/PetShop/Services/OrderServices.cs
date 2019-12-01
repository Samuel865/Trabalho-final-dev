using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly DataContext _context;
        public OrderServices(DataContext context)
        {
            _context = context;
        }
        public async Task Create(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Order order = await _context.Order.FirstOrDefaultAsync(o => o.Id ==id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Order.Include(o => o.Pet).AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
           return await _context.Order.Include(o => o.Pet).AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task Update(Order order)
        {
            _context.Entry<Order>(order).State= EntityState.Modified;
            await _context.SaveChangesAsync();
        } 
    }
}