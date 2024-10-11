using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;

namespace Proy_GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;
        public UsuariosController (IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuariosRepository.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuariosById(int id)
        {
            var usuarios = await _usuariosRepository.GetUsuariosById(id);
            if(usuarios == null) return NotFound();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuarios usuarios)
        {
            int id = await _usuariosRepository.Insert(usuarios);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Usuarios usuarios)
        {
            if(id != usuarios.Id) return BadRequest();
            var result = await _usuariosRepository.Update(usuarios);
            if(!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _usuariosRepository.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
        }

    
    }
}
