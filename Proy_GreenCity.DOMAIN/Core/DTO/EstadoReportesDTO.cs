using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Core.DTO
{
    public class EstadoReportesDTO
    {

        public int Id { get; set; }

        public int? ReporteId { get; set; }

        public string? Estado { get; set; }
    }

    public class EstadoReportesListDTO
    {
        public int Id { get; set; }
        public string? Estado { get; set; }
    }

    public class EstadoReportesshowDTO
    {
        public int? ReporteId { get; set; }

        public string? Estado { get; set; }
    }
    public class EstadoDTO
    {
        public string? Estado { get; set; }
    }
    public class ReporteEstadoReportesDTO
    {
        public int Id { get; set; }
        public string? Estado { get; set; }
        public IEnumerable<ReportesListDTO> EstadoReportes { get; set; }
    }
    /*public class CategoryProductsDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ProductListDTO> Products { get; set; }

    }*/
}

