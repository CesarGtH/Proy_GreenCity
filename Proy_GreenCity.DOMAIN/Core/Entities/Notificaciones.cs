using System;
using System.Collections.Generic;

namespace Proy_GreenCity.DOMAIN.Core.Entities;

public partial class Notificaciones
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string? Mensaje { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
