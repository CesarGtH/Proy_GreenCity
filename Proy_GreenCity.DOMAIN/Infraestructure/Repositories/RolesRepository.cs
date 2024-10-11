using Microsoft.EntityFrameworkCore;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using Proy_GreenCity.DOMAIN.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Infraestructure.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly GreenCityContext _dbContext;

        public RolesRepository(GreenCityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Roles>> GetRoles()
        {
            var roles = await _dbContext.Roles.ToListAsync();
            return roles;
        }

        public async Task<Roles> GetRolesById(int id)
        {
            var roles = await _dbContext
                .Roles
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return roles;
        }

        public async Task<int> Insert(Roles roles)
        {
            await _dbContext.Roles.AddAsync(roles);
            await _dbContext.SaveChangesAsync();
            return roles.Id;
        }

        public async Task<bool> Update(Roles roles)
        {
            _dbContext.Roles.Update(roles);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var roles = _dbContext.Roles.Find(id);
            if (roles == null) return false;

            _dbContext.Roles.Remove(roles);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
