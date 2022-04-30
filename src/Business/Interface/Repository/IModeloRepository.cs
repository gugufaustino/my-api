using Business.Models;
using Business.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface.Repository
{
    public interface IModeloRepository : IRepository<Modelo>
    {
        Task<List<Modelo>> Pesquisar(CatalogoModeloFilter filtro);
        Task<int> RemoverModeloTipoCasting(IEnumerable<ModeloTipoCasting> modeloTipoCastings);
        Task AdicionarModeloTipoCasting(IEnumerable<ModeloTipoCasting> novosModeloTipoCastings);
    }
}