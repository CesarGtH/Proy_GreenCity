using System;
using System.Collections.Generic;

namespace Proy_GreenCity.DOMAIN.Core.Entities;

public partial class EstadoReportes
{
    public int Id { get; set; }

    public int? ReporteId { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaActualizacion { get; set; }
}
