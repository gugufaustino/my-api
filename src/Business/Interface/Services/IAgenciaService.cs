using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IAgenciaService : IDisposable
    {
        Task<int> AdicionarAgenciaEmpresa(Agencia agencia);
        Task Adicionar(Agencia lstAgencias);
        Task Editar(int id, Agencia agencia);        
        Task Excluir(int id);        
    }
}
