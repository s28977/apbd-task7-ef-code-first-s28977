
namespace apbd_task7_ef_code_first.Models;

public class Component
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int ComponentManufacturerId { get; set; }
    public required ComponentManufacturer ComponentManufacturer { get; set; }
    public int ComponentTypeId { get; set; }
    public required ComponentType ComponentType { get; set; }
    public List<PcComponent> PcComponents { get; set; } = new();
}