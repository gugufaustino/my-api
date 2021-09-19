using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IClienteService : IDisposable
    {
        Task Adicionar(Cliente cliente);
        Task Adicionar(List<Cliente> lstClientes);
        Task Editar(int id, Cliente cliente);        
        Task Excluir(int id);        
    }
}
