using System;
using System.Collections.Generic;

namespace challenge_api_dotnet.Models;

public partial class MarcadorFixo
{
    public int IdMarcadorArucoFixo { get; set; }

    public string? CodigoAruco { get; set; }

    public decimal? XPos { get; set; }

    public decimal? YPos { get; set; }

    public int? PatioIdPatio { get; set; }
    public virtual Patio? PatioIdPatioNavigation { get; set; }

    public virtual ICollection<MedicaoPosicao> MedicoesPosicoes { get; set; } = new List<MedicaoPosicao>();
    
}
