using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Models;

namespace challenge_api_dotnet.Mappers;

public class PosicaoMapper
{
    public static PosicaoDTO ToDto(Posicao posicao) => new PosicaoDTO
    {
        IdPosicao = posicao.IdPosicao,
        XPos = posicao.XPos,
        YPos = posicao.YPos,
        DataHora = posicao.DataHora,
        MotoId = posicao.MotoIdMoto,
        PatioId = posicao.PatioIdPatio
    };

    public static Posicao ToEntity(PosicaoDTO dto) => new Posicao
    {
        IdPosicao = dto.IdPosicao,
        XPos = dto.XPos,
        YPos = dto.YPos,
        DataHora = dto.DataHora,
        MotoIdMoto = dto.MotoId,
        PatioIdPatio = dto.PatioId
    };
}