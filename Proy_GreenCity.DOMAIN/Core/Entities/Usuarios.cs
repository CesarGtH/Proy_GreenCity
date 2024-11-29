using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proy_GreenCity.DOMAIN.Core.Entities;

public partial class Usuarios
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Contrasena { get; set; }

    public int? RolId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }
}
