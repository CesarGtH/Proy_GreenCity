using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Core.DTO
{
    public class UsuariosDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Email { get; set; }

        public string? Contrasena { get; set; }

        public int? RolId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }

    public class UsuariosRequestAuthDTO
    {
        public string? Nombre { get; set; }

        public string? Email { get; set; }

        public string? Contrasena { get; set; }
    }
    public class UsuariosResponseAuthDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Email { get; set; }
        public string? Token { get; set; }
        public bool IsEmailSent { get; set; }
    }
    public class UsuariosByIdResponseDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Email { get; set; }

        public string? Contrasena { get; set; }
    }
    public class UsuariosAuthDTO
    {
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
    }
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }
    }
}
