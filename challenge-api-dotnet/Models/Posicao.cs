using System;
using System.Collections.Generic;

namespace challenge_api_dotnet.Models;

public partial class Posicao
{
    public int IdPosicao { get; set; }

    public decimal? XPos { get; set; }

    public decimal? YPos { get; set; }

    public DateTime? DataHora { get; set; }

    public int? MotoIdMoto { get; set; }
    public virtual Moto? MotoIdMotoNavigation { get; set; }
    
    public int? PatioIdPatio { get; set; }
    public virtual Patio? PatioIdPatioNavigation { get; set; }

    public virtual ICollection<MedicaoPosicao> MedicoesPosicoes { get; set; } = new List<MedicaoPosicao>();
    
    
}
