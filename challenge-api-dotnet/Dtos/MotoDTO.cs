namespace challenge_api_dotnet.Dtos;

public class MotoDTO
{
    public int IdMoto { get; set; }
    public string? Placa { get; set; }
    public string? Modelo { get; set; }
    public string? Status { get; set; }
    public DateTime? DataCadastro { get; set; }

}