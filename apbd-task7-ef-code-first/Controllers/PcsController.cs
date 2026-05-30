using apbd_task7_ef_code_first.DTOs;
using apbd_task7_ef_code_first.Exceptions;
using apbd_task7_ef_code_first.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_task7_ef_code_first.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController : ControllerBase
{
    private readonly IPcsService _pcsService;

    public PcsController(IPcsService pcsService)
    {
        _pcsService = pcsService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPc([FromRoute] int id)
    {
        try
        {
            var pc = await _pcsService.GetPcAsync(id);
            return Ok(pc);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPcs()
    {
        var pcs = await _pcsService.GetAllPcsAsync();
        return Ok(pcs);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetPcComponents([FromRoute] int id)
    {
        try
        {
            var pcComponents = await _pcsService.GetPcComponentsAsync(id);
            return Ok(pcComponents);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePc([FromBody] CreatePcRequestDto request)
    {
        var response = await _pcsService.CreatePcAsync(request);
        return CreatedAtAction(nameof(GetPc),  new { id = response.Id }, response);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePc([FromRoute] int id, [FromBody] UpdatePcRequestDto request)
    {
        try
        {
            var updatedPc = await _pcsService.UpdatePcAsync(id, request);
            return Ok(updatedPc);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePc([FromRoute] int id)
    {
        try
        {
            await _pcsService.DeletePcAsync(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}