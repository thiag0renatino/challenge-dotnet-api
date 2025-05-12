using challenge_api_dotnet.Dtos;
using challenge_api_dotnet.Models;

namespace challenge_api_dotnet.Mappers;

public class MotoMapper
{
    public static MotoDTO ToDto(Moto moto) => new MotoDTO
    {
        IdMoto = moto.IdMoto,
        Placa = moto.Placa,
        Modelo = moto.Modelo,
        Status = moto.Status,
        DataCadastro = moto.DataCadastro
    };

    public static Moto ToEntity(MotoDTO dto) => new Moto
    {
        IdMoto = dto.IdMoto,
        Placa = dto.Placa,
        Modelo = dto.Modelo,
        Status = dto.Status,
        DataCadastro = dto.DataCadastro
    };
}