using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proy_GreenCity.DOMAIN.Core.DTO;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using Proy_GreenCity.DOMAIN.Core.Services;

namespace Proy_GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReportesService _reportesService;
        public ReporteController(IReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        [HttpPost("InsertReport")]
        public async Task<IActionResult> InsertReport([FromBody] ReportesRequestDTO reportesRequest)
        {
            if (reportesRequest == null)
            {
                return BadRequest("El cuerpo de la solicitud está vacío o no tiene el formato esperado.");
            }

            // Log para depuración
            Console.WriteLine($"Título: {reportesRequest.Titulo}");
            Console.WriteLine($"Descripción: {reportesRequest.Descripcion}");
            Console.WriteLine($"Categoría: {reportesRequest.Categoria}");
            Console.WriteLine($"Ubicación: {reportesRequest.Ubicacion}");
            Console.WriteLine($"UsuarioId: {reportesRequest.UsuarioId}");


            var reportes = new Reportes()
            {
                Titulo = reportesRequest.Titulo,
                Descripcion = reportesRequest.Descripcion,
                Categoria = reportesRequest.Categoria,
                Ubicacion = reportesRequest.Ubicacion,
                UsuarioId = reportesRequest.UsuarioId,
            };

            var result = await _reportesService.Insert(reportes);
            if (!result) return BadRequest(result);
            return Ok(result);
        }
    }
}
