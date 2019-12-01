using Microsoft.EntityFrameworkCore;
using PetShop.Data.Mapper;
using PetShop.Models;

namespace PetShop.Data
{
    public class DataContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Pet> Pet { get; set; }       

        public DataContext(DbContextOptions options):base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration( new UserMapping());
            builder.ApplyConfiguration( new PetMapping());
            builder.ApplyConfiguration( new OrderMapping());
        }
    }
}