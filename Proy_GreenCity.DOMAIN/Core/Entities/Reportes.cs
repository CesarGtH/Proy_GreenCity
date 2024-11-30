using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proy_GreenCity.DOMAIN.Core.Entities;

public partial class Reportes
{
    [Key]
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Estado { get; set; }

}
