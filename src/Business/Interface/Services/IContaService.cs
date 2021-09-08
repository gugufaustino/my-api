using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IContaService  : IDisposable
    {
        Task AdicionarPagamento(Pagamento pagamento);

        Task Excluir(int Id);
    }
}
