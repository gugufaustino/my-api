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
    public class PagamentoRepository : Repository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public async Task ExcluirPorConta(int id)
        {
            var lst = Db.Pagamentos.Where(i => i.Id == id).AsEnumerable();

            Db.Pagamentos.RemoveRange(lst);

           await SaveChanges();
        }

        public async override Task<List<Pagamento>> ListarTodos()
        {
            return await Db.Pagamentos.AsNoTracking()
                            .Include(p => p.Conta)
                            .ToListAsync();
        }

        public async override Task<Pagamento> ObterPorId(int id)
        {
            return await Db.Pagamentos
                            .Include(p => p.Conta)
                            .FirstAsync(i => i.Id == id);
        }
    }
}
