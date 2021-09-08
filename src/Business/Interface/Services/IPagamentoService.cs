using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IPagamentoService : IDisposable
    {
        Task Adicionar(Pagamento pagamento);
        Task Editar(int Id, Pagamento pagamento);
        Task ExcluirPorConta(int id);
        Task Excluir(int id);
        Task EditarPago(int id, bool indPago);
    }
}
