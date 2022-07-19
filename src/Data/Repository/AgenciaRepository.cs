using Business.Interface;
using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AgenciaRepository : Repository<Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {
        }
  
        public async override Task<List<Agencia>> ListarTodos()
        {
            return await Db.Agencias.AsNoTracking()                            
                            .ToListAsync();
        }

        public async override Task<Agencia> ObterPorId(int id)
        {
            return await Db.Agencias                            
                            .FirstAsync(i => i.Id == id);
        } 
       
    }
}
