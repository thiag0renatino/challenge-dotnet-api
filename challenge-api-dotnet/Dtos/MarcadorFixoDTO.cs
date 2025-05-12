namespace challenge_api_dotnet.Dtos;

public class MarcadorFixoDTO
{
    public int IdMarcadorArucoFixo { get; set; }
    public string CodigoAruco { get; set; }
    public float? XPos { get; set; }
    public float? YPos { get; set; }
    public int PatioId { get; set; }

}