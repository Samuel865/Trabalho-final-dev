using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Models;

namespace PetShop.Data.Mapper
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey( o => o.Id);
            builder.Property( o => o.Date).IsRequired().HasColumnType("date");
            builder.Property( o => o.Price).IsRequired();            
        }
    }
}