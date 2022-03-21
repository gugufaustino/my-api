using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Business.Util;
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
            TratamentosBasicos(endereco);
            await _repository.Adicionar(endereco);
        }

        public async Task Adicionar(List<Endereco> lstGerarEnderecos)
        {
            foreach (var endereco in lstGerarEnderecos)
            {
                TratamentosBasicos(endereco);
                await _repository.Adicionar(endereco);
            }
        }

        public async Task Editar(int Id, Endereco endereco)
        {
            var entity = await _repository.ObterPorId(Id);
            TratamentosBasicos(endereco);

            entity.Cep = endereco.Cep;
            entity.Logradouro = endereco.Logradouro;
            entity.Numero = endereco.Numero;
            entity.Complemento = endereco.Complemento;
            entity.Bairro = endereco.Bairro;
            entity.NomeMunicipio= endereco.NomeMunicipio;
            entity.SiglaUf = endereco.SiglaUf;

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

        private void TratamentosBasicos(Endereco endereco)
        {
            endereco.Cep = endereco.Cep.RemoverMascara();
            endereco.SiglaUf = endereco.SiglaUf.ToUpper();
        }

    }
}
