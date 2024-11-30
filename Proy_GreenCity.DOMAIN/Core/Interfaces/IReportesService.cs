using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface IReportesService
    {
        Task<bool> Insert(Reportes reportes);
    }
}