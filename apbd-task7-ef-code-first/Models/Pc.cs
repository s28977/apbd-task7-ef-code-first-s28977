
namespace apbd_task7_ef_code_first.Models;

public class Pc
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public List<PcComponent> PcComponents { get; set; } = new();
}