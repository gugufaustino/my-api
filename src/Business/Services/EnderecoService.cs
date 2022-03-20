using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {

        private readonly IEnderecoRepository _repository;
        public EnderecoService(IBroadcaster broadcaster,
            IEnderecoRepository EnderecoRepository)
            : base(broadcaster)
        {
            _repository = EnderecoRepository;

        }

        public async Task Adicionar(Endereco endereco)
        {
            await _repository.Adicionar(endereco);
        }

        public async Task Adicionar(List<Endereco> lstGerarEnderecos)
        {
            foreach (var endereco in lstGerarEnderecos)
            {
                await _repository.Adicionar(endereco);
            }
        }

        public async Task Editar(int Id, Endereco endereco)
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
