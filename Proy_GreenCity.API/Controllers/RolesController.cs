using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;

namespace Proy_GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _rolesRepository.GetRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolesById(int id)
        {
            var roles = await _rolesRepository.GetRolesById(id);
            if (roles == null) return NotFound();
            return Ok(roles);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Roles roles)
        {
            int id = await _rolesRepository.Insert(roles);
            return Ok(id);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Roles roles)
        {
            if (id != roles.Id) return BadRequest();
            var result = await _rolesRepository.Update(roles);
            if (!result) return BadRequest();
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _rolesRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}
