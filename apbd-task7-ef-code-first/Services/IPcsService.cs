using apbd_task7_ef_code_first.DTOs;

namespace apbd_task7_ef_code_first.Services;

public interface IPcsService
{
    public Task<PcDto> GetPcAsync(int pcId);
    public Task<List<PcDto>> GetAllPcsAsync();
    public Task<List<PcComponentDto>> GetPcComponentsAsync(int pcId);
    public Task<CreatePcResponseDto> CreatePcAsync(CreatePcRequestDto pcDto);
    public Task<UpdatePcResponseDto> UpdatePcAsync(int id, UpdatePcRequestDto update);
    public Task DeletePcAsync(int id);
}