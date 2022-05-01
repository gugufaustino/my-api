using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            modelo.IdTipoSituacao = TipoSituacaoEnum.Ativado;
            await _enderecoService.Adicionar(modelo.Endereco);
            await _repository.Adicionar(modelo);
        }

        public async Task Adicionar(List<Modelo> lstGerarModelos)
        {
            foreach (var modelo in lstGerarModelos)
            {
                await Adicionar(modelo);
            }
        }

        public async Task Editar(int Id, Modelo modelo)
        {
            var entity = await _repository.ObterPorId(Id);
            entity.Nome = modelo.Nome;
            entity.DtNascimento = modelo.DtNascimento;
            entity.Rg = modelo.Rg;
            entity.CPF = modelo.CPF;
            entity.Diponibilidade = modelo.Diponibilidade;
            entity.Email = modelo.Email;
            entity.Telefone = modelo.Telefone;
            entity.Instagram = modelo.Instagram;
            entity.Facebook = modelo.Facebook;
            entity.Linkedin = modelo.Linkedin;
            entity.Altura = modelo.Altura;
            entity.Peso = modelo.Peso;
            entity.Manequim = modelo.Manequim;
            entity.Sapato = modelo.Sapato;
            entity.CorOlhos = modelo.CorOlhos;
            entity.CorCabelo = modelo.CorCabelo;
            entity.TipoCabelo = modelo.TipoCabelo;
            entity.TipoCabeloComprimento = modelo.TipoCabeloComprimento;
            entity.ImagemPerfilNome = modelo.ImagemPerfilNome;

            await _enderecoService.Editar(entity.IdEndereco, modelo.Endereco);
            await EditarModeloTipoCasting(entity, entity.ModeloTipoCasting, modelo.ModeloTipoCasting.Select(i => (TipoCastingEnum)i.IdTipoCasting));
            
            await _repository.Editar(entity);
        }

        private async Task EditarModeloTipoCasting(Modelo entity, IEnumerable<ModeloTipoCasting> modeloTipoCastings, IEnumerable<TipoCastingEnum> novosTipoCastingEnums)
        {
            await _repository.RemoverModeloTipoCasting(modeloTipoCastings);

            var novosModeloTipoCastings = novosTipoCastingEnums.Select(i => new ModeloTipoCasting {
                 Modelo = entity,
                 IdTipoCasting = (int)i
            });
            
            await _repository.AdicionarModeloTipoCasting(novosModeloTipoCastings);

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
