using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IContaService  : IDisposable
    {
        Task AdicionarPagamentoUnico(Pagamento entity);
        Task AdicionarPagamentoMensal(Pagamento entity, int diaVencimento);
        Task Excluir(int Id);
    }
}
