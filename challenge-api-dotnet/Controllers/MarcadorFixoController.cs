using challenge_api_dotnet.Data;
using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_api_dotnet.Controllers;

[ApiController]
[Route("api/marcador-fixo")]
public class MarcadorFixoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MarcadorFixoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<MarcadorFixoDTO>>> GetAll()
    {
        var marcadores = await _context.MarcadoresFixos.ToListAsync();
        return marcadores.Select(MarcadorFixoMapper.ToDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MarcadorFixoDTO>> GetById(int id)
    {
        var marcador = await _context.MarcadoresFixos.FindAsync(id);
        if (marcador == null)
        {
            return NotFound();
        }
        return MarcadorFixoMapper.ToDto(marcador);
    }

    [HttpGet("patio/{patioId}")]
    public async Task<ActionResult<List<MarcadorFixoDTO>>> GetByPatioId(int patioId)
    {
        var marcadores = await _context.MarcadoresFixos
            .Where(m => m.PatioIdPatio == patioId)
            .ToListAsync();
        return marcadores.Select(MarcadorFixoMapper.ToDto).ToList();
    }
    
    [HttpGet("busca")]
    public async Task<ActionResult<MarcadorFixoDTO>> GetByCodigoAruco([FromQuery] string codigoAruco)
    {
        var marcador = await _context.MarcadoresFixos
            .FirstOrDefaultAsync(m => m.CodigoAruco.ToLower() == codigoAruco.ToLower());
        if (marcador == null)
        {
            return NotFound();
        }
        
        return MarcadorFixoMapper.ToDto(marcador);
    }

    [HttpPost]
    public async Task<ActionResult<MarcadorFixoDTO>> Create(MarcadorFixoDTO dto)
    {
        var marcador = MarcadorFixoMapper.ToEntity(dto);
        _context.MarcadoresFixos.Add(marcador);
        await _context.SaveChangesAsync();
        
        var response =  MarcadorFixoMapper.ToDto(marcador);
        return CreatedAtAction(nameof(GetById), new { id = marcador.IdMarcadorArucoFixo }, response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MarcadorFixoDTO>> Delete(int id)
    {
        var marcador = await _context.MarcadoresFixos.FindAsync(id);
        if (marcador == null)
        {
            return NotFound();
        }
        _context.MarcadoresFixos.Remove(marcador);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}