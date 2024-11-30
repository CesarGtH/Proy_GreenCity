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
    public class ComentarioController : ControllerBase
    {

            private readonly IComentariosService _comentariosService;
            public ComentarioController(IComentariosService comentariosService)
            {
                _comentariosService = comentariosService;
            }

     [HttpPost("InsertComentario")]
            public async Task<IActionResult> InsertComentario([FromBody] ComentariosRequestDTO comentariosRequest)
            {
                if (comentariosRequest == null)
                {
                    return BadRequest("El cuerpo de la solicitud está vacío o no tiene el formato esperado.");
                }

                // Log para depuración
                Console.WriteLine($"Contenido: {comentariosRequest.Contenido}");
                Console.WriteLine($"ReporteId: {comentariosRequest.ReporteId}");
                Console.WriteLine($"UsuarioId: {comentariosRequest.UsuarioId}");


                var comentarios = new Comentarios()
                {
                    Contenido = comentariosRequest.Contenido,
                    ReporteId = comentariosRequest.ReporteId,
                    UsuarioId = comentariosRequest.UsuarioId,
                };

                var result = await _comentariosService.Insert(comentarios);
                if (!result) return BadRequest(result);
                return Ok(result);
            }
        }
    }



