namespace challenge_api_dotnet.Dtos;

public class UsuarioResponseDTO
{
    public int IdUsuario { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Status { get; set; }
    public int? PatioId { get; set; }
}