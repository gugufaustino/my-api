using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Business.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AgenciaService : BaseService, IAgenciaService
    {

        private readonly IAgenciaRepository _repository;
        private readonly IAgenciaEmpresaRepository _repositoryEmpresa;

        public AgenciaService(IBroadcaster broadcaster,
                                IAgenciaRepository AgenciaRepository,
                                IAgenciaEmpresaRepository repositoryEmpresa)
            : base(broadcaster)
        {
            _repository = AgenciaRepository;
            _repositoryEmpresa = repositoryEmpresa;
        }

        public async Task Adicionar(Agencia agencia)
        {
            agencia.AgenciaEmpresa.Cnpj = agencia.AgenciaEmpresa.Cnpj.RemoverMascara();
            await _repository.Adicionar(agencia);
            
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
