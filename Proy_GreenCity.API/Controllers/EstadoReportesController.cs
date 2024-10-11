using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;

namespace Proy_GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoReportesController : ControllerBase
    {
        private readonly IEstadoReportesRepository _estadoreportesRepository;
        public EstadoReportesController(IEstadoReportesRepository estadoreportesRepository)
        {
            _estadoreportesRepository = estadoreportesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstadoReportes()
        {
            var estadoreportes = await _estadoreportesRepository.GetEstadoReportes();
            return Ok(estadoreportes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoReportesById(int id)
        {
            var estadoreportes = await _estadoreportesRepository.GetEstadoReportesById(id);
            if (estadoreportes == null) return NotFound();
            return Ok(estadoreportes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstadoReportes estadoreportes)
        {
            int id = await _estadoreportesRepository.Insert(estadoreportes);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EstadoReportes estadoreportes)
        {
            if (id != estadoreportes.Id) return BadRequest();
            var result = await _estadoreportesRepository.Update(estadoreportes);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _estadoreportesRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}

