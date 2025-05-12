namespace challenge_api_dotnet.Dtos;

public class MarcadorFixoDTO
{
    public int IdMarcadorArucoFixo { get; set; }
    public string CodigoAruco { get; set; }
    public decimal? XPos { get; set; }
    public decimal? YPos { get; set; }
    public int? PatioId { get; set; }

}