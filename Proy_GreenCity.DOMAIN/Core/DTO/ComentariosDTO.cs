using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Core.DTO
{
    public class ComentariosDTO
    {
        public int Id { get; set; }

        public int? ReporteId { get; set; }

        public int? UsuarioId { get; set; }

        public string? Contenido { get; set; }
    }
    public class ComentariosRequestDTO
    {

        [Required]
        public string? Contenido { get; set; }
        [Required]
        public int? ReporteId { get; set; }
        [Required]
        public int? UsuarioId { get; set; }

    }
}
