
namespace apbd_task7_ef_code_first.Models;

public class ComponentManufacturer
{
    public int Id { get; set; }
    public required string Abbreviation { get; set; }
    public required string FullName {get; set;}
    public DateOnly FoundationDate { get; set; }
    public List<Component> Components { get; set; } = new();
}