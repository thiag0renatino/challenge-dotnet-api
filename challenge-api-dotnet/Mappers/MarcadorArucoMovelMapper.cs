using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Models;

namespace challenge_api_dotnet.Mappers;

public class MarcadorArucoMovelMapper
{
    public static MarcadorArucoMovelDTO ToDto(MarcadorArucoMovel marcador) => new MarcadorArucoMovelDTO
    {
        IdMarcadorMovel = marcador.IdMarcadorMovel,
        CodigoAruco = marcador.CodigoAruco,
        DataInstalacao = marcador.DataInstalacao,
        MotoId = marcador.MotoIdMoto
    };

    public static MarcadorArucoMovel ToEntity(MarcadorArucoMovelDTO dto) => new MarcadorArucoMovel
    {
        IdMarcadorMovel = dto.IdMarcadorMovel,
        CodigoAruco = dto.CodigoAruco,
        DataInstalacao = dto.DataInstalacao,
        MotoIdMoto = dto.MotoId
    };
}