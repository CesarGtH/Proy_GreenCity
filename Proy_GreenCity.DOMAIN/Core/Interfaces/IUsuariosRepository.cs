using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Usuarios>> GetUsuarios();
        Task<Usuarios> GetUsuariosById(int id);
        Task<int> Insert(Usuarios usuarios);
        Task<bool> Update(Usuarios usuarios);
    }
}