using Proy_GreenCity.DOMAIN.Core.DTO;
using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> Insert(Usuarios usuarios);
        Task<UsuariosResponseAuthDTO> SignIn(string email, string pwd);
    }
}