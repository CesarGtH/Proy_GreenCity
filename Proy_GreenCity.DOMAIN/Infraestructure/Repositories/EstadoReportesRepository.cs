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
    public class EstadoReportesRepository : IEstadoReportesRepository
    {
        private readonly GreenCityContext _dbContext;

        public EstadoReportesRepository(GreenCityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EstadoReportes>> GetEstadoReportes()
        {
            var estadoreportes = await _dbContext.EstadoReportes.ToListAsync();
            return estadoreportes;
        }

        public async Task<EstadoReportes> GetEstadoReportesById(int id)
        {
            var estadoreportes = await _dbContext
                .EstadoReportes
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return estadoreportes;
        }

        public async Task<int> Insert(EstadoReportes estadoreportes)
        {
            await _dbContext.EstadoReportes.AddAsync(estadoreportes);
            await _dbContext.SaveChangesAsync();
            return estadoreportes.Id;
        }

        public async Task<bool> Update(EstadoReportes estadoreportes)
        {
            _dbContext.EstadoReportes.Update(estadoreportes);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var estadoreportes = _dbContext.EstadoReportes.Find(id);
            if (estadoreportes == null) return false;

            _dbContext.EstadoReportes.Remove(estadoreportes);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
