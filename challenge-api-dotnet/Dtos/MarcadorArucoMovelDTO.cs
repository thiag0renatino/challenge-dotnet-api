namespace challenge_api_dotnet.Dtos;

public class MarcadorArucoMovelDTO
{
    public int IdMarcadorMovel { get; set; }
    public string CodigoAruco { get; set; }
    public DateTime? DataInstalacao { get; set; }
    public int? MotoId { get; set; }
}