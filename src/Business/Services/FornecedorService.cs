using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Business.Services.Validations;
using Business.Util;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {

        private readonly IFornecedorRepository _repository;
        private readonly IEnderecoService _enderecoService;
        
        private readonly IValidator<Fornecedor> _validator;
        public FornecedorService(IBroadcaster broadcaster,
            IFornecedorRepository repository,
            IEnderecoService enderecoService,
            IValidator<Fornecedor> validator)
            : base(broadcaster)
        {
            _repository = repository;
            _enderecoService = enderecoService;
            _validator = validator;

        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            //prepara dados
            fornecedor.Cnpj = fornecedor.Cnpj.RemoverMascara();

            if (!ExecuteValidations(_validator, fornecedor)) return;


            await _enderecoService.Adicionar(fornecedor.Endereco);
            await _repository.Adicionar(fornecedor);
        }

        public async Task Adicionar(List<Fornecedor> lstGerarFornecedors)
        {
            foreach (var fornecedor in lstGerarFornecedors)
            {
                await _repository.Adicionar(fornecedor);
            }
        }

        public async Task Editar(int Id, Fornecedor fornecedor)
        {
            fornecedor.Cnpj = fornecedor.Cnpj.RemoverMascara();
            if (!ExecuteValidations(_validator, fornecedor)) return;


            var entity = await _repository.ObterPorId(Id);
            entity.Cnpj = fornecedor.Cnpj;
            entity.RazaoSocial = fornecedor.RazaoSocial;
            entity.Atividade = fornecedor.Atividade;

            fornecedor.IdEndereco = entity.IdEndereco;
            await _enderecoService.Editar(fornecedor.IdEndereco, fornecedor.Endereco);

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
