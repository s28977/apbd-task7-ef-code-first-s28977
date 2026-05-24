
namespace apbd_task7_ef_code_first.Models;

public class Component
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturerId { get; set; }
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    public int ComponentTypeId { get; set; }
    public ComponentType ComponentType { get; set; } = null!;
    public List<PcComponent> PcComponents { get; set; } = new();
}