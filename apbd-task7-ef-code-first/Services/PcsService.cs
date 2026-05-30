using apbd_task7_ef_code_first.Data;
using apbd_task7_ef_code_first.DTOs;
using apbd_task7_ef_code_first.Exceptions;
using apbd_task7_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_task7_ef_code_first.Services;

public class PcsService : IPcsService
{
    private readonly PcDbContext _context;
    
    public PcsService(PcDbContext context)
    {
        _context = context;
    }

    public async Task<PcDto> GetPcAsync(int pcId)
    {
        var pc =  await _context.Pcs.AsNoTracking()
            .Where(p => p.Id == pcId)
            .Select(p => new PcDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .FirstOrDefaultAsync();
        return pc ?? throw new NotFoundException($"Pc with id = {pcId} not found");
    }

    public async Task<List<PcDto>> GetAllPcsAsync()
    {
        return await _context.Pcs
            .AsNoTracking()
            .Select(p => new PcDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock =  p.Stock
            })
            .ToListAsync();
    }

    public async Task<List<PcComponentDto>> GetPcComponentsAsync(int pcId)
    {
        var pcExists = await _context.Pcs.AnyAsync(p => p.Id == pcId);
        if (!pcExists)
        {
            throw new NotFoundException($"Pc with id = {pcId} not found");
        }
        return await  _context.PcComponents.AsNoTracking()
            .Where(p => p.PcId == pcId)
            .Select(p => new PcComponentDto
            {
                ComponentCode = p.ComponentCode,
                Name = p.Component.Name,
                Description = p.Component.Description,
                TypeAbbreviation = p.Component.ComponentType.Abbreviation,
                ManufacturerAbbreviation = p.Component.ComponentManufacturer.Abbreviation
            }).ToListAsync();
    }

    public async Task<CreatePcResponseDto> CreatePcAsync(CreatePcRequestDto pcDto)
    {
        var pc = new Pc
        {
            Name = pcDto.Name,
            Weight = pcDto.Weight,
            Warranty = pcDto.Warranty,
            CreatedAt = pcDto.CreatedAt,
            Stock = pcDto.Stock
        };
        _context.Pcs.Add(pc);
        await _context.SaveChangesAsync();
        return new CreatePcResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<UpdatePcResponseDto> UpdatePcAsync(int id, UpdatePcRequestDto update)
    {
        var pc = await _context.Pcs.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (pc is null)
        {
            throw new NotFoundException($"Pc with id = {id} not found");
        }
        pc.Name = update.Name;
        pc.Weight = update.Weight;
        pc.Warranty = update.Warranty;
        pc.CreatedAt = update.CreatedAt;
        pc.Stock = update.Stock;
        await _context.SaveChangesAsync();
        return new UpdatePcResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task DeletePcAsync(int id)
    {
        var pc = await _context.Pcs.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (pc is null)
        {
            throw new NotFoundException($"Pc with id = {id} not found");
        }
        _context.Pcs.Remove(pc);
        await _context.SaveChangesAsync();
    }
}