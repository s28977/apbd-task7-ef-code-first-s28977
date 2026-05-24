using apbd_task7_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_task7_ef_code_first.Data.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(c => c.Code);
        builder.Property(c => c.Code)
            .HasColumnType("char(10)");
        
        builder.Property(c => c.Name)
            .HasMaxLength(300);
        
        builder.HasData(
            new Component
            {
                Code = "CPU-RYZ-01",
                Name = "Ryzen 7 5800X",
                Description = "8-core 16-thread desktop processor",
                ComponentTypeId = 1,
                ComponentManufacturerId = 1
            },
            new Component
            {
                Code = "GPU-RTX-01",
                Name = "GeForce RTX 4070",
                Description = "Mid-range graphics card with 12GB GDDR6X",
                ComponentTypeId = 2,
                ComponentManufacturerId = 2
            },
            new Component
            {
                Code = "RAM-DDR-01",
                Name = "Crucial 32GB DDR5",
                Description = "32GB DDR5-5600 desktop memory kit",
                ComponentTypeId = 3,
                ComponentManufacturerId = 3
            }
        );
    }
}