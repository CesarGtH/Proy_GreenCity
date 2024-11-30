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
    public class ReportesRepository : IReportesRepository
    {
        private readonly GreenCityContext _dbContext;

        public ReportesRepository(GreenCityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Reportes>> GetReportes()
        {
            var reportes = await _dbContext.Reportes.ToListAsync();
            return reportes;
        }

        public async Task<Reportes> GetReportesById(int id)
        {
            var reportes = await _dbContext
                .Reportes
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return reportes;
        }

        public async Task<bool> Insert(Reportes reportes)
        {
            await _dbContext.Reportes.AddAsync(reportes);
            int rowss = await _dbContext.SaveChangesAsync();
            return rowss > 0;
        }

        public async Task<bool> Update(Reportes reportes)
        {
            _dbContext.Reportes.Update(reportes);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var reportes = _dbContext.Reportes.Find(id);
            if (reportes == null) return false;

            _dbContext.Reportes.Remove(reportes);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
