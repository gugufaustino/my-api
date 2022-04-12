using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        public ModeloRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
  
        public async override Task<List<Modelo>> ListarTodos()
        {
            return await Db.Modelos.AsNoTracking()                            
                            .ToListAsync();
        }

        public async override Task<Modelo> ObterPorId(int id)
        {
            return await Db.Modelos                            
                            .FirstAsync(i => i.Id == id);
        }
    }
}
