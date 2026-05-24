using apbd_task7_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_task7_ef_code_first.Data.Configurations;

public class PcConfiguration : IEntityTypeConfiguration<Pc>
{
    public void Configure(EntityTypeBuilder<Pc> builder)
    {
        builder.ToTable("PCs");
        builder.Property(p => p.Name)
            .HasMaxLength(50);

        builder.Property(p => p.Weight)
            .HasColumnType("float(5)");

        builder.Property(p => p.CreatedAt)
            .HasColumnType("datetime");
        
        builder.HasData(
            new Pc
            {
                Id = 1,
                Name = "Office Workstation",
                Weight = 8.5f,
                Warranty = 24,
                CreatedAt = new DateTime(2024, 1, 15),
                Stock = 10
            },
            new Pc
            {
                Id = 2,
                Name = "Gaming Rig",
                Weight = 12.3f,
                Warranty = 36,
                CreatedAt = new DateTime(2024, 3, 20),
                Stock = 5
            },
            new Pc
            {
                Id = 3,
                Name = "Compact Mini PC",
                Weight = 2.1f,
                Warranty = 12,
                CreatedAt = new DateTime(2024, 5, 10),
                Stock = 20
            }
        );
    }
}