using challenge_api_dotnet.Data;
using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_api_dotnet.Controllers;

[ApiController]
[Route("api/posicao")]
public class PosicaoController :  ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PosicaoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<PosicaoDTO>>> GetAll()
    {
        var posicoes = await _context.Posicoes.ToListAsync();
        return posicoes.Select(PosicaoMapper.ToDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PosicaoDTO>> GetById(int id)
    {
        var posicao = await _context.Posicoes.FindAsync(id);
        if (posicao == null)
        {
            return NotFound();
        }
        return PosicaoMapper.ToDto(posicao);
    }
    
    [HttpGet("moto/{motoId}")]
    public async Task<ActionResult<List<PosicaoDTO>>> GetByMotoId(int motoId)
    {
        var posicoes = await _context.Posicoes
            .Where(p => p.MotoIdMoto == motoId)
            .ToListAsync();

        return posicoes.Select(PosicaoMapper.ToDto).ToList();
    }
    
    [HttpGet("historico/{motoId}")]
    public async Task<ActionResult<List<PosicaoDTO>>> GetHistoricoDaMoto(int motoId)
    {
        var posicoes = await _context.Posicoes
            .Where(p => p.MotoIdMoto == motoId)
            .OrderByDescending(p => p.DataHora)
            .ToListAsync();

        return posicoes.Select(PosicaoMapper.ToDto).ToList();
    }
    
    [HttpGet("motos-indisponiveis")]
    public async Task<ActionResult<List<PosicaoDTO>>> GetPosicoesDeMotosIndisponiveis()
    {
        var posicoes = await _context.Posicoes
            .Include(p => p.MotoIdMotoNavigation)
            .Where(p => p.MotoIdMotoNavigation != null && p.MotoIdMotoNavigation.Status.ToLower() == "indisponível")
            .ToListAsync();

        return posicoes.Select(PosicaoMapper.ToDto).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<PosicaoDTO>> Create(PosicaoDTO dto)
    {
        var posicao = PosicaoMapper.ToEntity(dto);
        _context.Posicoes.Add(posicao);
        await _context.SaveChangesAsync();
        
        var response = PosicaoMapper.ToDto(posicao);
        return CreatedAtAction(nameof(GetById), new { id = posicao.IdPosicao }, response);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<PosicaoDTO>> Update(int id, PosicaoDTO dto)
    {
        if (id != dto.IdPosicao)
        {
            return BadRequest();
        }

        var posicao = await _context.Posicoes.FindAsync(id);
        if (posicao == null)
        {
            return NotFound();
        }

        posicao.XPos = dto.XPos;
        posicao.YPos = dto.YPos;
        posicao.DataHora = dto.DataHora;
        posicao.MotoIdMoto = dto.MotoId;
        posicao.PatioIdPatio = dto.PatioId;

        await _context.SaveChangesAsync();
        return Ok(PosicaoMapper.ToDto(posicao));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<PosicaoDTO>> Delete(int id)
    {
        var posicao = await _context.Posicoes.FindAsync(id);
        if (posicao == null)
        {
            return NotFound();
        }

        _context.Posicoes.Remove(posicao);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}