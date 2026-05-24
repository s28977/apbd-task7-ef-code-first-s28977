
namespace apbd_task7_ef_code_first.Models;

public class PcComponent
{
    public int PcId { get; set; }
    public Pc Pc { get; set; } = null!;
    public string ComponentCode { get; set; } = string.Empty;
    public Component Component { get; set; } = null!;
    public int Amount { get; set; }
    
}