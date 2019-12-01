using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Models;

namespace PetShop.Data.Mapper
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey( u => u.Id);
            builder.Property( u => u.Name).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property( u => u.Email).IsRequired().HasColumnType("varchar(60)").HasMaxLength(60);           
            builder.HasMany( u => u.Pets).WithOne( p  => p.User).HasForeignKey( p => p.UserId);
        }
    }
}