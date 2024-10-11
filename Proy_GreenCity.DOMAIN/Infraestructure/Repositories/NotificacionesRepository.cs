using Microsoft.EntityFrameworkCore;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using Proy_GreenCity.DOMAIN.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Infraestructure.Repositories
{
    public class NotificacionesRepository : INotificacionesRepository
    {
        private readonly GreenCityContext _dbContext;

        public NotificacionesRepository(GreenCityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Notificaciones>> GetNotificaciones()
        {
            var notificaciones = await _dbContext.Notificaciones.ToListAsync();
            return notificaciones;
        }

        public async Task<Notificaciones> GetNotificacionesById(int id)
        {
            var notificaciones = await _dbContext
                .Notificaciones
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return notificaciones;
        }

        public async Task<int> Insert(Notificaciones notificaciones)
        {
            await _dbContext.Notificaciones.AddAsync(notificaciones);
            await _dbContext.SaveChangesAsync();
            return notificaciones.Id;
        }

        public async Task<bool> Update(Notificaciones notificaciones)
        {
            _dbContext.Notificaciones.Update(notificaciones);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var notificaciones = _dbContext.Notificaciones.Find(id);
            if (notificaciones == null) return false;

            _dbContext.Notificaciones.Remove(notificaciones);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
