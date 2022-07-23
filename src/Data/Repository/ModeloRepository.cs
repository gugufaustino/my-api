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
using Business.Interface;

namespace Data.Repository
{
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {    
        public ModeloRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {
        }

        private Expression<Func<Modelo, bool>> UserScope => i => i.IdAgencia == User.IdAgencia;

        public async Task<List<Modelo>> Pesquisar(CatalogoModeloFilter filter)
        {

            IQueryable<Modelo> query = Db.Modelos.Where(UserScope)
                                                .Include(i => i.TipoSituacao)
                                                .Include(i => i.Endereco)
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
                            .Include(i => i.Endereco)
                            .Include(i => i.TipoSituacao)
                            .Include(i => i.ModeloTipoCasting).ThenInclude(s => s.TipoCasting)
                            .Where(UserScope)
                            .FirstAsync(i => i.Id == id);
        }

        public override async Task<bool> Existe(Expression<Func<Modelo, bool>> predicate)
        {
            return await DbSet.Where(UserScope).AnyAsync(predicate);
        }

        public async Task<int> RemoverModeloTipoCasting(IEnumerable<ModeloTipoCasting> modeloTipoCastings)
        {
            Db.ModeloTipoCasting.RemoveRange(modeloTipoCastings);
            return await SaveChanges();
        }

        public async Task RemoverPorModeloTipoCasting(int idModelo)
        {
            var modelTipoCastings = Db.ModeloTipoCasting.Where(i => i.IdModelo == idModelo);
            Db.ModeloTipoCasting.RemoveRange(modelTipoCastings);
            await SaveChanges();
        }

        public async Task<int> AdicionarModeloTipoCasting(IEnumerable<ModeloTipoCasting> novosModeloTipoCastings)
        {
            Db.ModeloTipoCasting.AddRange(novosModeloTipoCastings);
            return await SaveChanges();
        }
    }
}
