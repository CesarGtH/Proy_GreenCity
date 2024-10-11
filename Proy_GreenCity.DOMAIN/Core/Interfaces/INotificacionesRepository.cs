using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface INotificacionesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Notificaciones>> GetNotificaciones();
        Task<Notificaciones> GetNotificacionesById(int id);
        Task<int> Insert(Notificaciones notificaciones);
        Task<bool> Update(Notificaciones notificaciones);
    }
}