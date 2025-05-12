using System;
using System.Collections.Generic;

namespace challenge_api_dotnet.Models;

public partial class Patio
{
    public int IdPatio { get; set; }

    public string? Nome { get; set; }

    public string? Localizacao { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<MarcadorFixo> MarcadoresFixos { get; set; } = new List<MarcadorFixo>();

    public virtual ICollection<Posicao> Posicoes { get; set; } = new List<Posicao>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
