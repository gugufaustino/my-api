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
    public class #NomeModel#Repository : Repository<#NomeModel#>, I#NomeModel#Repository
    {
        public #NomeModel#Repository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
  
        public async override Task<List<#NomeModel#>> ListarTodos()
        {
            return await Db.#NomeModel#s.AsNoTracking()                            
                            .ToListAsync();
        }

        public async override Task<#NomeModel#> ObterPorId(int id)
        {
            return await Db.#NomeModel#s                            
                            .FirstAsync(i => i.Id == id);
        }
    }
}
