using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Models;

namespace challenge_api_dotnet.Mappers;

public class MedicaoPosicaoMapper
{
    public static MedicaoPosicaoDTO ToDto(MedicaoPosicao m) => new MedicaoPosicaoDTO
    {
        IdMedicao = m.IdMedicao,
        DistanciaM = m.DistanciaM,
        PosicaoId = m.PosicaoIdPosicao,
        MarcadorFixoId = m.MarcadorFixoIdMarcadorArucoFixo
    };

    public static MedicaoPosicao ToEntity(MedicaoPosicaoDTO dto) => new MedicaoPosicao
    {
        IdMedicao = dto.IdMedicao,
        DistanciaM = dto.DistanciaM,
        PosicaoIdPosicao = dto.PosicaoId,
        MarcadorFixoIdMarcadorArucoFixo = dto.MarcadorFixoId
    };
}