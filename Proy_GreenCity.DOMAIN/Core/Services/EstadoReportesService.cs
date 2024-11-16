using Proy_GreenCity.DOMAIN.Core.DTO;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Core.Services
{
    public class EstadoReportesService : IEstadoReportesService
    {
        private readonly IEstadoReportesRepository _estadoReportesRepository;
        public EstadoReportesService(IEstadoReportesRepository estadoReportesRepository)
        {
            _estadoReportesRepository = estadoReportesRepository;
        }

        public async Task<IEnumerable<EstadoReportesListDTO>> GetEstadoReportes()
        {
            var EstadoReportes = await _estadoReportesRepository.GetEstadoReportes();
            var EstadoReportesDTO = new List<EstadoReportesListDTO>();
            foreach (var EstadoReporte in EstadoReportes)
            {
                var EstadoReporteDTO = new EstadoReportesListDTO();
                EstadoReporteDTO.Id = EstadoReporte.Id;
                EstadoReporteDTO.Estado = EstadoReporte.Estado;
                EstadoReportesDTO.Add(EstadoReporteDTO);
            }
            return EstadoReportesDTO;
        }

        public async Task<EstadoReportesListDTO> GetEstadoReportesById(int id)
        {
            var EstadoReportes = await _estadoReportesRepository.GetEstadoReportesById(id);
            var EstadoReportesDTO = new EstadoReportesListDTO();

            EstadoReportesDTO.Id = EstadoReportes.Id;
            EstadoReportesDTO.Estado = EstadoReportes.Estado;

            return EstadoReportesDTO;
        }

        public async Task<int> Insert(EstadoDTO EstadoReportesDTO)
        {
            var EstadoReportes = new EstadoReportes();
            EstadoReportes.Estado = EstadoReportesDTO.Estado;
            return await _estadoReportesRepository.Insert(EstadoReportes);
        }

        public async Task<bool> Update(EstadoReportesListDTO EstadoReportesDTO)
        {
            var EstadoReportes = new EstadoReportes();
            EstadoReportes.Estado = EstadoReportesDTO.Estado;
            EstadoReportes.Id = EstadoReportesDTO.Id;

            return await _estadoReportesRepository.Update(EstadoReportes);

        }
        public async Task<bool> Delete(int id)
        {
            return await _estadoReportesRepository.Delete(id);
        }
        public async Task<ReporteEstadoReportesDTO> GetReporteEstadoReportesById(int id)
        {
            var estadoreportes = await _estadoReportesRepository.GetReporteEstadoReportesById(id);
            var ReportesERDTO = new ReporteEstadoReportesDTO();
            ReportesERDTO.Id = estadoreportes.Id;
            ReportesERDTO.Estado = estadoreportes.Estado;

            var reportes = new List<ReportesListDTO>();
            foreach(var rer in estadoreportes.Reportes)
            {
                var reporte = new ReportesListDTO();
                reporte.Id = rer.Id;
                reporte.UsuarioId = rer.UsuarioId;
                reporte.Titulo = rer.Titulo;
                reporte.Descripcion = rer.Descripcion;
                reportes.Add(reporte); 
            }
            ReportesERDTO.EstadoReportes = reportes;
            return ReportesERDTO; 
        }

        /*public async Task<CategoryProductsDTO> GetCategoryProductsById(int id)
        {
            var category = await _categoryRepository.GetCategoryProductsById(id);

            var categoryProductsDTO = new CategoryProductsDTO();
            categoryProductsDTO.Id = category.Id;
            categoryProductsDTO.Description = category.Description;

            var products = new List<ProductListDTO>();
            foreach (var cp in category.Product)
            {
                var product = new ProductListDTO();
                product.Id = cp.Id;
                product.Description = cp.Description;
                products.Add(product);
            }
            categoryProductsDTO.Products = products;
            return categoryProductsDTO;
        }*/





    }
}
