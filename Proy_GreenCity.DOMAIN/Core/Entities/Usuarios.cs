using System;
using System.Collections.Generic;

namespace Proy_GreenCity.DOMAIN.Core.Entities;

public partial class Usuarios
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Contrasena { get; set; }

    public int? RolId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }
}
