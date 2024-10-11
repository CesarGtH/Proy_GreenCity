using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;

namespace Proy_GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionesRepository _notificacionesRepository;
        public NotificacionesController(INotificacionesRepository notificacionesRepository)
        {
            _notificacionesRepository = notificacionesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificaciones()
        {
            var notificaciones = await _notificacionesRepository.GetNotificaciones();
            return Ok(notificaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificacionesById(int id)
        {
            var notificaciones = await _notificacionesRepository.GetNotificacionesById(id);
            if (notificaciones == null) return NotFound();
            return Ok(notificaciones);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Notificaciones notificaciones)
        {
            int id = await _notificacionesRepository.Insert(notificaciones);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Notificaciones notificaciones)
        {
            if (id != notificaciones.Id) return BadRequest();
            var result = await _notificacionesRepository.Update(notificaciones);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _notificacionesRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}
