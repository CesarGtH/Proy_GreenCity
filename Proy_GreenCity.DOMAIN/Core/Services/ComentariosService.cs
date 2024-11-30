using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Core.Services
{
    public class ComentariosService : IComentariosService
    {
        private readonly IComentariosRepository _comentariosRepository;
        public ComentariosService(IComentariosRepository comentariosRepository)
        {
            _comentariosRepository = comentariosRepository;
        }
        public async Task<bool> Insert(Comentarios comentarios)
        {
            return await _comentariosRepository.Insert(comentarios);
        }
    }
}
