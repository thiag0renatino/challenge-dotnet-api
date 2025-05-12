using System;
using System.Collections.Generic;

namespace challenge_api_dotnet.Models;

public partial class MedicaoPosicao
{
    public int IdMedicao { get; set; }

    public decimal? DistanciaM { get; set; }

    public int? PosicaoIdPosicao { get; set; }
    public virtual Posicao? PosicaoIdPosicaoNavigation { get; set; }

    public int? MarcadorFixoIdMarcadorArucoFixo { get; set; }
    public virtual MarcadorFixo? MarcadorFixoIdMarcadorArucoFixoNavigation { get; set; }
    
}
