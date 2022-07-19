using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {

        private readonly IClienteRepository _repository;
        public ClienteService(IBroadcaster broadcaster,
            IClienteRepository ClienteRepository)
            : base(broadcaster)
        {
            _repository = ClienteRepository;

        }

        public async Task Adicionar(Cliente cliente)
        {
            await _repository.Adicionar(cliente);
        }

        public async Task Adicionar(List<Cliente> lstGerarClientes)
        {
            foreach (var cliente in lstGerarClientes)
            {
                await _repository.Adicionar(cliente);
            }
        }

        public async Task Editar(int Id, Cliente cliente)
        {
            var entity = await _repository.ObterPorId(Id);
            entity.Nome= cliente.Nome;
             

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
