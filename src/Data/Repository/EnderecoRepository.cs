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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
  
        public async override Task<List<Endereco>> ListarTodos()
        {
            return await Db.Enderecos.AsNoTracking()                            
                            .ToListAsync();
        }

        public async override Task<Endereco> ObterPorId(int id)
        {
            return await Db.Enderecos
                            .FirstAsync(i => i.Id == id);
        }
    }
}
