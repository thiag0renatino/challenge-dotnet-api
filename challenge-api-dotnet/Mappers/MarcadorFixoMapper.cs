using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Models;

namespace challenge_api_dotnet.Mappers;

public class MarcadorFixoMapper
{
    public static MarcadorFixoDTO ToDto(MarcadorFixo marcador) => new MarcadorFixoDTO
    {
        IdMarcadorArucoFixo = marcador.IdMarcadorArucoFixo,
        CodigoAruco = marcador.CodigoAruco,
        XPos = marcador.XPos,
        YPos = marcador.YPos,
        PatioId = marcador.PatioIdPatio
    };

    public static MarcadorFixo ToEntity(MarcadorFixoDTO dto) => new MarcadorFixo
    {
        IdMarcadorArucoFixo = dto.IdMarcadorArucoFixo,
        CodigoAruco = dto.CodigoAruco,
        XPos = dto.XPos,
        YPos = dto.YPos,
        PatioIdPatio = dto.PatioId
    };
}