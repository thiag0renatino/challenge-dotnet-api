using challenge_api_dotnet.Data;
using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Mappers;
using challenge_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_api_dotnet.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public UsuarioController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<UsuarioResponseDTO>>> GetAll()
    {
        var usuarios = await _context.Usuarios.ToListAsync();
        return usuarios.Select(UsuarioMapper.ToResponseDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioResponseDTO>> GetById(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return UsuarioMapper.ToResponseDto(usuario);
    }
    
    [HttpGet("email/{email}")]
    public async Task<ActionResult<UsuarioResponseDTO>> FindByEmail(string email)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == email);

        if (usuario == null)
        {
            return NotFound();
        }
        return UsuarioMapper.ToResponseDto(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioResponseDTO>> Create(UsuarioCreateDTO dto)
    {
        var usuario = UsuarioMapper.ToEntity(dto);
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        
        var response = UsuarioMapper.ToResponseDto(usuario);
        return CreatedAtAction(nameof(GetById), new { id = usuario.IdUsuario }, response);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> update(int id, UsuarioCreateDTO dto)
    {
        if (id != dto.IdUsuario)
        {
            return BadRequest("ID do corpo e URL devem ser iguais");
        }
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        
        usuario.Nome = dto.Nome;
        usuario.Email = dto.Email;
        usuario.Senha = dto.Senha;
        usuario.Status = dto.Status;
        usuario.PatioIdPatio = dto.PatioId;
        
        await _context.SaveChangesAsync();
        return Ok(UsuarioMapper.ToResponseDto(usuario));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}