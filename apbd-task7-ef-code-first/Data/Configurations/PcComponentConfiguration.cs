using apbd_task7_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_task7_ef_code_first.Data.Configurations;

public class PcComponentConfiguration : IEntityTypeConfiguration<PcComponent>
{
    public void Configure(EntityTypeBuilder<PcComponent> builder)
    {
        builder.ToTable("PCComponents");
        builder.HasKey(p => new { p.PcId, p.ComponentCode });
        builder.Property(p => p.PcId)
            .HasColumnName("PCId");
    }
}