using challenge_api_dotnet.Data;
using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Mappers;
using challenge_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_api_dotnet.Controllers;

[ApiController]
[Route("api/marcador-movel")]
public class MarcadorArucoMovelController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MarcadorArucoMovelController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<MarcadorArucoMovelDTO>>> GetAll()
    {
        var marcadores = await _context.MarcadoresArucoMoveis.ToListAsync();
        return marcadores.Select(MarcadorArucoMovelMapper.ToDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MarcadorArucoMovelDTO>> GetById(int id)
    {
        var marcador = await _context.MarcadoresArucoMoveis.FindAsync(id);
        if (marcador == null)
        {
            return NotFound();
        }

        return MarcadorArucoMovelMapper.ToDto(marcador);
    }
    
    [HttpGet("moto/{idMoto}")]
    public async Task<ActionResult<MarcadorArucoMovelDTO>> GetByMotoId(int idMoto)
    {
        var marcador = await _context.MarcadoresArucoMoveis
            .FirstOrDefaultAsync(m => m.MotoIdMoto == idMoto);

        if (marcador == null)
        {
            return NotFound();
        }

        return MarcadorArucoMovelMapper.ToDto(marcador);
    }
    
    [HttpGet("busca")]
    public async Task<ActionResult<MarcadorArucoMovelDTO>> GetByCodigoAruco([FromQuery] string codigoAruco)
    {
        var marcador = await _context.MarcadoresArucoMoveis
            .FirstOrDefaultAsync(m => m.CodigoAruco.ToLower() == codigoAruco.ToLower());

        if (marcador == null)
        {
            return NotFound();
        }

        return MarcadorArucoMovelMapper.ToDto(marcador);
    }

    [HttpPost]
    public async Task<ActionResult<MarcadorArucoMovelDTO>> Create(MarcadorArucoMovelDTO dto)
    {
        var marcador = MarcadorArucoMovelMapper.ToEntity(dto);
        _context.MarcadoresArucoMoveis.Add(marcador);
        await _context.SaveChangesAsync();
        
        var response = MarcadorArucoMovelMapper.ToDto(marcador);
        return CreatedAtAction(nameof(GetById), new { id = marcador.IdMarcadorMovel }, response);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<MarcadorArucoMovelDTO>> Update(int id, MarcadorArucoMovelDTO dto)
    {
        if (id != dto.IdMarcadorMovel)
        {
            return BadRequest();
        }

        var marcador = await _context.MarcadoresArucoMoveis.FindAsync(id);
        if (marcador == null)
        {
            return NotFound();
        }

        marcador.CodigoAruco = dto.CodigoAruco;
        marcador.DataInstalacao = dto.DataInstalacao;
        marcador.MotoIdMoto = dto.MotoId;

        await _context.SaveChangesAsync();
        return Ok(MarcadorArucoMovelMapper.ToDto(marcador));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MarcadorArucoMovelDTO>> Delete(int id)
    {
        var marcador = await _context.MarcadoresArucoMoveis.FindAsync(id);
        if (marcador == null)
        {
            return NotFound();
        }

        _context.MarcadoresArucoMoveis.Remove(marcador);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}