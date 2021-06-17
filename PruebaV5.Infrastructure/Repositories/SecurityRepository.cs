using Microsoft.EntityFrameworkCore;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(PruebaV5BDContext context) : base(context)
        {

        }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User && x.Pwd == login.Password);
        }
    }
}
