using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;

namespace Proy_GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentariosRepository _comentariosRepository;
        public ComentariosController(IComentariosRepository comentariosRepository)
        {
            _comentariosRepository = comentariosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComentarios()
        {
            var comentarios = await _comentariosRepository.GetComentarios();
            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComentariosById(int id)
        {
            var comentarios = await _comentariosRepository.GetComentariosById(id);
            if (comentarios == null) return NotFound();
            return Ok(comentarios);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Comentarios comentarios)
        {
            int id = await _comentariosRepository.Insert(comentarios);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Comentarios comentarios)
        {
            if (id != comentarios.Id) return BadRequest();
            var result = await _comentariosRepository.Update(comentarios);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _comentariosRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}
