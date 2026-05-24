
namespace apbd_task7_ef_code_first.Models;

public class ComponentType
{
    public int Id { get; set; }
    public required string Abbreviation { get; set; }
    public required string Name { get; set; }
    public List<Component> Components { get; set; } = new();
}