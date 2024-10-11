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
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly GreenCityContext _dbContext;

        public UsuariosRepository(GreenCityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            var usuarios = await _dbContext.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<Usuarios> GetUsuariosById(int id)
        {
            var usuarios = await _dbContext
                .Usuarios
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return usuarios;
        }

        public async Task<int> Insert(Usuarios usuarios)
        {
            await _dbContext.Usuarios.AddAsync(usuarios);
            await _dbContext.SaveChangesAsync();
            return usuarios.Id;
        }

        public async Task<bool> Update(Usuarios usuarios)
        {
            _dbContext.Usuarios.Update(usuarios);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var usuarios = _dbContext.Usuarios.Find(id);
            if (usuarios == null) return false;

            _dbContext.Usuarios.Remove(usuarios);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
