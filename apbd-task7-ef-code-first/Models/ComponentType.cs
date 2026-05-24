
namespace apbd_task7_ef_code_first.Models;

public class ComponentType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<Component> Components { get; set; } = new();
}