
namespace apbd_task7_ef_code_first.Models;

public class PcComponent
{
    public int PcId { get; set; }
    public required Pc Pc { get; set; }
    public required string ComponentCode { get; set; }
    public required Component Component { get; set; }
    public int Amount { get; set; }
    
}