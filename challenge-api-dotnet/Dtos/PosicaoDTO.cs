namespace challenge_api_dotnet.Dtos;

public class PosicaoDTO
{
    public int IdPosicao { get; set; }
    
    public decimal? XPos { get; set; }
    public decimal? YPos { get; set; }
    public DateTime? DataHora { get; set; }

    public int? MotoId { get; set; }
    public int? PatioId { get; set; }
}