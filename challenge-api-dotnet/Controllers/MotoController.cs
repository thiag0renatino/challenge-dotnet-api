using challenge_api_dotnet.Data;
using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_api_dotnet.Controllers;

[ApiController]
[Route("api/moto")]
public class MotoController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public MotoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<MotoDTO>>> GetAll()
    {
        var motos = await _context.Motos.ToListAsync();
        return motos.Select(MotoMapper.ToDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MotoDTO>> GetById(int id)
    {
        var moto = await _context.Motos.FindAsync(id);
        if (moto == null)
        {
            return NotFound();
        }
        return MotoMapper.ToDto(moto);
    }

    [HttpGet("placa/{placa}")]
    public async Task<ActionResult<List<MotoDTO>>> GetByPlaca(string placa)
    {
        var motos = await _context.Motos
            .Where(m => m.Placa.StartsWith(placa))
            .ToListAsync();
        
        if (!motos.Any())
        {
            return NotFound();
        }
        return motos.Select(MotoMapper.ToDto).ToList();
    }

    [HttpGet("status/{status}")]
    public async Task<ActionResult<List<MotoDTO>>> GetByStatus(string status)
    {
        var motos = await _context.Motos
            .Where(m => m.Status.ToLower() == status.ToLower())
            .ToListAsync();
        return motos.Select(MotoMapper.ToDto).ToList();
    }

    [HttpGet("{id}/posicoes")]
    public async Task<ActionResult<List<PosicaoDTO>>> GetByPosicoesMoto(int id)
    {
        var posicoes = await  _context.Posicoes
            .Where(p => p.MotoIdMoto == id)
            .ToListAsync();
        return posicoes.Select(PosicaoMapper.ToDto).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<MotoCreateDTO>> Create(MotoCreateDTO dto)
    {
        var moto = MotoMapper.ToEntity(dto);
        moto.DataCadastro = DateTime.Now;
        _context.Add(moto);
        await _context.SaveChangesAsync();

        var response = MotoMapper.ToDto(moto);
        return CreatedAtAction(nameof(GetById), new { id = moto.IdMoto}, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MotoCreateDTO>> Update(int id, MotoCreateDTO dto)
    {
        if (id != dto.IdMoto)
        {
            return BadRequest();
        }
        var moto = await _context.Motos.FindAsync(id);
        if (moto == null)
        {
            return NotFound();
        }
        
        moto.Placa = dto.Placa;
        moto.Modelo = dto.Modelo;
        moto.Status = dto.Status;
        
        await _context.SaveChangesAsync();
        return Ok(MotoMapper.ToDto(moto));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MotoDTO>> Delete(int id)
    {
        var moto = await _context.Motos.FindAsync(id);
        if (moto == null)
        {
            return NotFound();
        }
        _context.Motos.Remove(moto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
}