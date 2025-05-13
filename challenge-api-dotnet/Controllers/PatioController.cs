using challenge_api_dotnet.Data;
using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_api_dotnet.Controllers;

[ApiController]
[Route("api/patio")]
public class PatioController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PatioController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<PatioDTO>>> GetAll()
    {
        var patios = await _context.Patios.ToListAsync();
        return patios.Select(PatioMapper.ToDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatioDTO>> GetById(int id)
    {
        var patio = await _context.Patios.FindAsync(id);
        if (patio == null)
        {
            return NotFound();
        }
        return PatioMapper.ToDto(patio);
    }
    
    [HttpGet("com-motos")]
    public async Task<ActionResult<List<PatioDTO>>> GetPatiosComMotos()
    {
        var patios = await _context.Patios
            .Where(p => p.Usuarios.Any() || p.Posicoes.Any() || p.MarcadoresFixos.Any())
            .ToListAsync();

        return patios.Select(PatioMapper.ToDto).ToList();
    }

    [HttpGet("{id}/motos")]
    public async Task<ActionResult<List<MotoDTO>>> GetMotosPorPatio(int id)
    {
        var motos = await _context.Posicoes
            .Where(p => p.PatioIdPatio == id && p.MotoIdMoto != null)
            .Include(p => p.MotoIdMotoNavigation)
            .Select(p => p.MotoIdMotoNavigation)
            .Distinct()
            .ToListAsync();
        return motos.Select(MotoMapper.ToDto).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<PatioDTO>> Create(PatioDTO dto)
    {
        var patio = PatioMapper.ToEntity(dto);
        _context.Patios.Add(patio);
        await _context.SaveChangesAsync();
        
        var response = PatioMapper.ToDto(patio);
        return CreatedAtAction(nameof(GetById), new { id = patio.IdPatio }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PatioDTO>> Update(int id, PatioDTO dto)
    {
        if (id != dto.IdPatio)
        {
            return BadRequest();
        }
        var patio = await _context.Patios.FindAsync(id);
        if (patio == null)
        {
            return NotFound();
        }

        patio.Nome = dto.Nome;
        patio.Localizacao = dto.Localizacao;
        patio.Descricao = dto.Descricao;

        await _context.SaveChangesAsync();
        return Ok(PatioMapper.ToDto(patio));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PatioDTO>> Delete(int id)
    {
        var patio = await _context.Patios.FindAsync(id);
        if (patio == null)
        {
            return NotFound();
        }
        _context.Patios.Remove(patio);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    
}