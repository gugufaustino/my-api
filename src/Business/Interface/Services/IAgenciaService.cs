using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IAgenciaService : IDisposable
    {
        Task Adicionar(Agencia agencia);
        Task Adicionar(List<Agencia> lstAgencias);
        Task Editar(int id, Agencia agencia);        
        Task Excluir(int id);        
    }
}
