using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Models;

namespace PetShop.Data.Mapper
{
    public class PetMapping : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey( p => p.Id);
            builder.Property( p => p.Name).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property( p => p.Size).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property( p => p.Specie).IsRequired().HasColumnType("varchar(40)").HasMaxLength(40);
            builder.Property( p => p.Age).IsRequired();
            builder.HasMany( p => p.Orderes).WithOne( o => o.Pet).HasForeignKey( o => o.PetId);            
        }
    }
}