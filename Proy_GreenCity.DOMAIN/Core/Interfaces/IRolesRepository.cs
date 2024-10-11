using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface IRolesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Roles>> GetRoles();
        Task<Roles> GetRolesById(int id);
        Task<int> Insert(Roles roles);
        Task<bool> Update(Roles roles);
    }
}