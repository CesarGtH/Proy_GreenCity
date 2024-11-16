using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proy_GreenCity.DOMAIN.Core.DTO;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;

namespace Proy_GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoReportesController : ControllerBase
    {
        //private readonly IEstadoReportesRepository _estadoreportesRepository;
        private readonly IEstadoReportesService _estadoReportesService;
        //public EstadoReportesController(IEstadoReportesRepository estadoreportesRepository)
        public EstadoReportesController(IEstadoReportesService estadoReportesService)
        {
            _estadoReportesService = estadoReportesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstadoReportes()
        {
            var estadoreportes = await _estadoReportesService.GetEstadoReportes();
            return Ok(estadoreportes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoReportesById(int id,[FromQuery] bool includeReportes)
        {
            if (includeReportes)
                return Ok(await _estadoReportesService.GetReporteEstadoReportesById(id));

            return Ok(await _estadoReportesService.GetEstadoReportesById(id));
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstadoDTO EstadoReportesDTO)
        {
            int id = await _estadoReportesService.Insert(EstadoReportesDTO);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EstadoReportesListDTO
            EstadoReportesDTO)
        {
            if (id != EstadoReportesDTO.Id) return BadRequest();
            var result = await _estadoReportesService.Update(EstadoReportesDTO);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _estadoReportesService.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}

