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
    public class ReportesController : ControllerBase
    {
        private readonly IReportesRepository _reportesRepository;
        public ReportesController(IReportesRepository reportesRepository)
        {
            _reportesRepository = reportesRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetReportes()
        {
            var reportes = await _reportesRepository.GetReportes();
            return Ok(reportes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportesById(int id)
        {
            var reportes = await _reportesRepository.GetReportesById(id);
            if (reportes == null) return NotFound();
            return Ok(reportes);
        }

        /*[HttpPost]
        public async Task<IActionResult> Create([FromBody] Reportes reportes)
        {
            int id = await _reportesRepository.Insert(reportes);
            return Ok(id);
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Reportes reportes)
        {
            if (id != reportes.Id) return BadRequest();
            var result = await _reportesRepository.Update(reportes);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _reportesRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}
