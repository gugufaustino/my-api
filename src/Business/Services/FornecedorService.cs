using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Business.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {

        private readonly IFornecedorRepository _repository;
        public FornecedorService(IBroadcaster broadcaster,
            IFornecedorRepository FornecedorRepository)
            : base(broadcaster)
        {
            _repository = FornecedorRepository;

        }

        public async Task Adicionar(Fornecedor fornecedor)
        {

            fornecedor.Cnpj = fornecedor.Cnpj.RemoverMascara();
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
            var entity = await _repository.ObterPorId(Id);
            entity.RazaoSocial = fornecedor.RazaoSocial;
            entity.Cnpj = fornecedor.Cnpj.RemoverMascara();
            entity.Atividade = fornecedor.Atividade;
             

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
