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
    }
}