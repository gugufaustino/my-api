using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
          
        public async override Task<List<Fornecedor>> ListarTodos()
        {
            return await Db.Fornecedores.AsNoTracking()                            
                            .ToListAsync();
        }

        public async override Task<Fornecedor> ObterPorId(int id)
        {
            return await Db.Fornecedores
                            .FirstAsync(i => i.Id == id);
        }
    }
}
