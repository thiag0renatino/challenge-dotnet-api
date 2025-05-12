using System;
using System.Collections.Generic;

namespace challenge_api_dotnet.Models;

public partial class Moto
{
    public int IdMoto { get; set; }
    
    public string? Placa { get; set; }

    public string? Modelo { get; set; }

    public string? Status { get; set; }

    public DateTime? DataCadastro { get; set; } =  DateTime.Now;

    public virtual ICollection<MarcadorArucoMovel> MarcadoresArucoMoveis { get; set; } = new List<MarcadorArucoMovel>();

    public virtual ICollection<Posicao> Posicoes { get; set; } = new List<Posicao>();
}
