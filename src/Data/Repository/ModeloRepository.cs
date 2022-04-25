using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Business.Models.Filters;
using System.Linq.Expressions;
using Business.Util;
using System;

namespace Data.Repository
{
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        public ModeloRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public async Task<List<Modelo>> Pesquisar(CatalogoModeloFilter filter)
        {
            IQueryable<Modelo> query = Db.Modelos
                                            .Include(i => i.ModeloTipoCasting).ThenInclude(s => s.TipoCasting)
                                            .AsNoTracking();

            if (!filter.Nome.IsNullOrEmpty()) query = query.Where(w => w.Nome.StartsWith(filter.Nome));
            if (filter.IdadeDe.HasValue) query = query.Where(w => w.DtNascimento <= DateTime.Now.AddYears(-filter.IdadeDe.Value).Date);
            if (filter.IdadeAte.HasValue) query = query.Where(w => w.DtNascimento >= DateTime.Now.AddYears(-filter.IdadeAte.Value - 1).Date);
            if (filter.AlturaDe.HasValue) query = query.Where(w => w.Altura >= filter.AlturaDe);
            if (filter.AlturaAte.HasValue) query = query.Where(w => w.Altura <= filter.AlturaAte);
            if (filter.PesoDe.HasValue) query = query.Where(w => w.Peso >= filter.PesoDe);
            if (filter.PesoAte.HasValue) query = query.Where(w => w.Peso <= filter.PesoAte);

            if (filter.TipoCasting != null && filter.TipoCasting.Any())
                query = query.Where(w => w.ModeloTipoCasting.Any(m => filter.TipoCasting.Contains((TipoCastingEnum)m.IdTipoCasting)));


            return await query.ToListAsync();
        }

        public async override Task<Modelo> ObterPorId(int id)
        {
            return await Db.Modelos
                            .Include(i=> i.Endereco)
                            .Include(i => i.ModeloTipoCasting).ThenInclude(s => s.TipoCasting)
                            .FirstAsync(i => i.Id == id);
        }
    }
}
