using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interface.Repository
{
    public interface IAgenciaEmpresaRepository : IDisposable      
    {
        Task Adicionar(AgenciaEmpresa entity);
    }
}