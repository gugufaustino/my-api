using Business.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Interface.Repository
{
    public interface IAgenciaEmpresaRepository : IDisposable      
    {
        Task Adicionar(AgenciaEmpresa entity);

        Task<bool> Existe(Expression<Func<AgenciaEmpresa, bool>> predicate);
    }
}