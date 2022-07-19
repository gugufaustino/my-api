using Business.Interface;
using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {
        }

        public async override Task<List<Cliente>> ListarTodos()
        {
            return await Db.Clientes.AsNoTracking()
                            .ToListAsync();
        }

        public async override Task<Cliente> ObterPorId(int id)
        {
            return await Db.Clientes
                            .FirstAsync(i => i.Id == id);
        }
    }
}
