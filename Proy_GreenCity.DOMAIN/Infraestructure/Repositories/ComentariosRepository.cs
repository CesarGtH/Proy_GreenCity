using Microsoft.EntityFrameworkCore;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using Proy_GreenCity.DOMAIN.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Infraestructure.Repositories
{
    public class ComentariosRepository : IComentariosRepository
    {
        private readonly GreenCityContext _dbContext;

        public ComentariosRepository(GreenCityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Comentarios>> GetComentarios()
        {
            var comentarios = await _dbContext.Comentarios.ToListAsync();
            return comentarios;
        }

        public async Task<Comentarios> GetComentariosById(int id)
        {
            var comentarios = await _dbContext
                .Comentarios
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return comentarios;
        }

        public async Task<int> Insert(Comentarios comentarios)
        {
            await _dbContext.Comentarios.AddAsync(comentarios);
            await _dbContext.SaveChangesAsync();
            return comentarios.Id;
        }

        public async Task<bool> Update(Comentarios comentarios)
        {
            _dbContext.Comentarios.Update(comentarios);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var comentarios = _dbContext.Comentarios.Find(id);
            if (comentarios == null) return false;

            _dbContext.Comentarios.Remove(comentarios);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
