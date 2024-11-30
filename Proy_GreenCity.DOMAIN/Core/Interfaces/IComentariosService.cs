using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface IComentariosService
    {
        Task<bool> Insert(Comentarios comentarios);
    }
}