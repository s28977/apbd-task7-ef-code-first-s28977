using apbd_task7_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_task7_ef_code_first.Data.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.Property(c => c.Abbreviation)
            .HasMaxLength(30);

        builder.Property(c => c.FullName)
            .HasMaxLength(300);
    }
}