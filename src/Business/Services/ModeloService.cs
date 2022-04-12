using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ModeloService : BaseService, IModeloService
    {

        private readonly IModeloRepository _repository;
        private readonly IEnderecoService _enderecoService;
        public ModeloService(IBroadcaster broadcaster,
            IEnderecoService enderecoService,
            IModeloRepository ModeloRepository)
            : base(broadcaster)
        {
            _repository = ModeloRepository;
            _enderecoService = enderecoService;

        }

        public async Task Adicionar(Modelo modelo)
        {
            modelo.DthAtualizacao = modelo.DthInclusao = DateTime.Now;
            modelo.IdTipoSituacao = TipoSituacaoEnum.EmElaboracao;
            await _enderecoService.Adicionar(modelo.Endereco);
            await _repository.Adicionar(modelo);
        }

        public async Task Adicionar(List<Modelo> lstGerarModelos)
        {
            foreach (var modelo in lstGerarModelos)
            {
                await _repository.Adicionar(modelo);
            }
        }

        public async Task Editar(int Id, Modelo modelo)
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
            GC.SuppressFinalize(this);
        }
    }
}
