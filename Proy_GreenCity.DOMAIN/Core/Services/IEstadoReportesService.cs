using Proy_GreenCity.DOMAIN.Core.DTO;

namespace Proy_GreenCity.DOMAIN.Core.Services
{
    public interface IEstadoReportesService
    {
        Task<bool> Delete(int id);
        Task<ReporteEstadoReportesDTO> GetReporteEstadoReportesById(int id);
        Task<IEnumerable<EstadoReportesListDTO>> GetEstadoReportes();
        Task<EstadoReportesListDTO> GetEstadoReportesById(int id);
        Task<int> Insert(EstadoDTO EstadoReportesDTO);
        Task<bool> Update(EstadoReportesListDTO EstadoReportesDTO);
    }
}