using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Models;

namespace challenge_api_dotnet.Mappers;

public class PatioMapper
{
    public static PatioDTO ToDto(Patio patio) => new PatioDTO
    {
        IdPatio = patio.IdPatio,
        Nome = patio.Nome,
        Localizacao = patio.Localizacao,
        Descricao = patio.Descricao
    };

    public static Patio ToEntity(PatioDTO dto) => new Patio
    {
        IdPatio = dto.IdPatio,
        Nome = dto.Nome,
        Localizacao = dto.Localizacao,
        Descricao = dto.Descricao
    };
}