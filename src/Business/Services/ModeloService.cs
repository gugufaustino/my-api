using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FluentValidation;
using Business.Services.Validations;

namespace Business.Services
{
    public class ModeloService : BaseService, IModeloService
    {

        private readonly IModeloRepository repository;
        private readonly IUser user;
        private readonly IValidator<Modelo> validator;
        private readonly IEnderecoService enderecoService;

        public ModeloService(IBroadcaster broadcaster, IUser user, IValidator<Modelo> validator,
            IEnderecoService enderecoService,
            IModeloRepository repository)
            : base(broadcaster)
        {
            this.repository = repository;
            this.user = user;
            this.validator = validator;
            this.enderecoService = enderecoService;
        }

        public async Task Adicionar(Modelo modelo)
        {
            if (!ExecuteValidations(validator, modelo)) return;


            modelo.IdAgencia = user.IdAgencia.Value;
            modelo.IdTipoSituacao = TipoSituacaoEnum.Ativado;
            await enderecoService.Adicionar(modelo.Endereco);
            await repository.Adicionar(modelo);
        }

 

        public async Task Editar(int Id, Modelo modelo)
        {
            if (!ExecuteValidations(validator, modelo)) return;

            var entity = await repository.ObterPorId(Id);
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

            await enderecoService.Editar(entity.IdEndereco, modelo.Endereco);
            await EditarModeloTipoCasting(entity, entity.ModeloTipoCasting, modelo.ModeloTipoCasting.Select(i => (TipoCastingEnum)i.IdTipoCasting));
            
            await repository.Editar(entity);
        }

        private async Task EditarModeloTipoCasting(Modelo entity, IEnumerable<ModeloTipoCasting> modeloTipoCastings, IEnumerable<TipoCastingEnum> novosTipoCastingEnums)
        {
            await repository.RemoverModeloTipoCasting(modeloTipoCastings);

            var novosModeloTipoCastings = novosTipoCastingEnums.Select(i => new ModeloTipoCasting {
                 Modelo = entity,
                 IdTipoCasting = (int)i
            });
            
            await repository.AdicionarModeloTipoCasting(novosModeloTipoCastings);

        }


        public async Task Excluir(int id)
        {
            var entity = await repository.ObterPorId(id);
            await repository.RemoverPorModeloTipoCasting(entity.Id);
            await repository.Remover(entity);
            await enderecoService.Excluir(entity.IdEndereco);
        }


        public void Dispose()
        {
            repository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
