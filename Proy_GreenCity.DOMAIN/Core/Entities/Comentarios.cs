using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proy_GreenCity.DOMAIN.Core.Entities;

public partial class Comentarios
{
    [Key]
    public int Id { get; set; }

    public int? ReporteId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Contenido { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
