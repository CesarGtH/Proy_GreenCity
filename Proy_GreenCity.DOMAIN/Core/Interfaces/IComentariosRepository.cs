using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Core.Interfaces
{
    public interface IComentariosRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Comentarios>> GetComentarios();
        Task<Comentarios> GetComentariosById(int id);
        Task<bool> Insert(Comentarios comentarios);
        Task<bool> Update(Comentarios comentarios);
    }
}