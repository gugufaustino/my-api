using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IFornecedorService : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Adicionar(List<Fornecedor> lstFornecedores);
        Task Editar(int Id, Fornecedor fornecedor);        
        Task Excluir(int id);        
    }
}
