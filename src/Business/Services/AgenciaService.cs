using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AgenciaService : BaseService, IAgenciaService
    {

        private readonly IAgenciaRepository _repository;
        private readonly IAgenciaEmpresaRepository _repositoryEmpresa;
        public AgenciaService(IBroadcaster broadcaster,
            IAgenciaRepository AgenciaRepository)
            : base(broadcaster)
        {
            _repository = AgenciaRepository;

        }

        public async Task Adicionar(Agencia agencia)
        {
            await _repository.Adicionar(agencia);
            if(agencia.AgenciaEmpresa != null)
                await _repositoryEmpresa.Adicionar(agencia.AgenciaEmpresa);
        }

        public async Task Adicionar(List<Agencia> lstGerarAgencias)
        {
            foreach (var agencia in lstGerarAgencias)
            {
                await _repository.Adicionar(agencia);
            }
        }

        public async Task Editar(int Id, Agencia agencia)
        {
            var entity = await _repository.ObterPorId(Id);
            
             

            await _repository.Editar(entity);
        }
 

        public async Task Excluir(int id)
        {
            var entity = await _repository.ObterPorId(id);
           
            await _repository.Remover(entity);
        }
 

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
