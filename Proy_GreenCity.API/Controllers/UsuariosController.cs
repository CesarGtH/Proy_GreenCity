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
    public class UsuariosController : ControllerBase
    {
        //private readonly IUsuariosRepository _usuariosRepository;
        //public UsuariosController (IUsuariosRepository usuariosRepository)
        private readonly IUserService _usuariosService;
        public UsuariosController(IUserService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        /*[HttpGet]

        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuariosService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuariosById(int id)
        {
            var usuarios = await _usuariosRepository.GetUsuariosById(id);
            if(usuarios == null) return NotFound();
            return Ok(usuarios);
        }*/

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UsuariosRequestAuthDTO usuariosRequest)
        {
            var usuarios = new Usuarios()
            {
                Email = usuariosRequest.Email,
                Contrasena = usuariosRequest.Contrasena,
                Nombre = usuariosRequest.Nombre,
                RolId = 1
            };

            var result = await _usuariosService.Insert(usuarios);
            if (!result) return BadRequest(result);
            return Ok(result);
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Usuarios usuarios)
        {
            if(id != usuarios.Id) return BadRequest();
            var result = await _usuariosService.Update(usuarios);
            if(!result) return BadRequest();
            return Ok(result);
        }*/

        /*[HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _usuariosRepository.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
        }*/
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UsuariosAuthDTO authDTO)
        {
            //TODO: Validar email
            var result = await _usuariosService.SignIn(authDTO.Email, authDTO.Contrasena);
            if (result == null) return NotFound();
            return Ok(result);
        }


    }
}
