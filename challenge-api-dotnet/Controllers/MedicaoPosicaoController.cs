using challenge_api_dotnet.Data;
using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_api_dotnet.Controllers;

[ApiController]
[Route("api/medicao-posicao")]
public class MedicaoPosicaoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MedicaoPosicaoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<MedicaoPosicaoDTO>>> GetAll()
    {
        var medicoes = await _context.MedicoesPosicoes.ToListAsync();
        return medicoes.Select(MedicaoPosicaoMapper.ToDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MedicaoPosicaoDTO>> GetById(int id)
    {
        var medicao = await _context.MedicoesPosicoes.FindAsync(id);
        if (medicao == null)
        {
            return NotFound();
        }
        
        return MedicaoPosicaoMapper.ToDto(medicao);
    }
    
    [HttpGet("posicao/{id}")]
    public async Task<ActionResult<List<MedicaoPosicaoDTO>>> GetByPosicaoId(int id)
    {
        var medicoes = await _context.MedicoesPosicoes
            .Where(m => m.PosicaoIdPosicao == id)
            .ToListAsync();

        return medicoes.Select(MedicaoPosicaoMapper.ToDto).ToList();
    }

    [HttpGet("marcador-fixo/{id}")]
    public async Task<ActionResult<List<MedicaoPosicaoDTO>>> GetByMarcadorId(int id)
    {
        var medicoes = await _context.MedicoesPosicoes
            .Where(m => m.MarcadorFixoIdMarcadorArucoFixo == id)
            .ToListAsync();
        
        return medicoes.Select(MedicaoPosicaoMapper.ToDto).ToList();
    }
    
    [HttpGet("contagem/posicao/{id}")]
    public async Task<ActionResult<int>> CountByPosicaoId(int id)
    {
        var count = await _context.MedicoesPosicoes
            .CountAsync(m => m.PosicaoIdPosicao == id);

        return Ok(count);
    }
    
    [HttpPost]
    public async Task<ActionResult<MedicaoPosicaoDTO>> Create(MedicaoPosicaoDTO dto)
    {
        var medicao = MedicaoPosicaoMapper.ToEntity(dto);
        _context.MedicoesPosicoes.Add(medicao);
        await _context.SaveChangesAsync();

        var response = MedicaoPosicaoMapper.ToDto(medicao);
        return CreatedAtAction(nameof(GetById), new { id = medicao.IdMedicao }, response);
    }
}