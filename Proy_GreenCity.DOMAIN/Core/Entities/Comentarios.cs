using System;
using System.Collections.Generic;

namespace Proy_GreenCity.DOMAIN.Core.Entities;

public partial class Comentarios
{
    public int Id { get; set; }

    public int? ReporteId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Contenido { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
