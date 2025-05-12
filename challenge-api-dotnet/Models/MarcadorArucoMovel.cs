using System;
using System.Collections.Generic;

namespace challenge_api_dotnet.Models;

public partial class MarcadorArucoMovel
{
    public int IdMarcadorMovel { get; set; }

    public string? CodigoAruco { get; set; }

    public DateTime? DataInstalacao { get; set; }

    public int? MotoIdMoto { get; set; }
    public virtual Moto? MotoIdMotoNavigation { get; set; }
}
