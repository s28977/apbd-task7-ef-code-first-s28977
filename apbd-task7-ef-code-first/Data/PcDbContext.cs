using apbd_task7_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_task7_ef_code_first.Data;

public class PcDbContext : DbContext
{
    public DbSet<Pc> Pcs => Set<Pc>();
    public DbSet<Component> Components => Set<Component>();
    public DbSet<ComponentType> ComponentTypes => Set<ComponentType>();
    public DbSet<PcComponent> PcComponents => Set<PcComponent>();
    public DbSet<ComponentManufacturer> ComponentManufacturers => Set<ComponentManufacturer>();
    
    public PcDbContext(DbContextOptions<PcDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PcDbContext).Assembly);
    }
}