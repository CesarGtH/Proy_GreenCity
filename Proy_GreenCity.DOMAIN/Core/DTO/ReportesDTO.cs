﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Core.DTO
{
    public class ReportesDTO
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public string? Estado { get; set; }

    }
    public class ReportesListDTO
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }
    }
    public class ReportesRequestDTO
    {
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Categoria { get; set; }
        [Required]
        public string? Ubicacion { get; set; }
        [Required]
        public int UsuarioId { get; set; }
    }
}
