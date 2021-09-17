using Business.Models;
using System.Threading.Tasks;

namespace Business.Interface.Repository
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        Task ExcluirPorConta(int id);
    }
}
