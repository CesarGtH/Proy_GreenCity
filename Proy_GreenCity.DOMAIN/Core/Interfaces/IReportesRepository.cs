using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface IReportesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Reportes>> GetReportes();
        Task<Reportes> GetReportesById(int id);
        Task<bool> Insert(Reportes reportes);
        Task<bool> Update(Reportes reportes);
    }
}