using apbd_task7_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_task7_ef_code_first.Data.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.Property(c => c.Abbreviation)
            .HasMaxLength(30);
        
        builder.Property(c => c.Name)
            .HasMaxLength(150);
    }
}