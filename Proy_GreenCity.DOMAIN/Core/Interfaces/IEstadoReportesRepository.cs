using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface IEstadoReportesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<EstadoReportes>> GetEstadoReportes();
        Task<EstadoReportes> GetEstadoReportesById(int id);
        Task<int> Insert(EstadoReportes estadoreportes);
        Task<bool> Update(EstadoReportes estadoreportes);
        Task<EstadoReportes> GetReporteEstadoReportesById(int id);
    }
}