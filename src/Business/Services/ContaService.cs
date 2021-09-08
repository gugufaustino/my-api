using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ContaService : BaseService, IContaService
    {

        private readonly IContaRepository _repository;
        private readonly IPagamentoService _pagamentoService;
        public ContaService(IBroadcaster broadcaster,
            IContaRepository contaRepository,
            IPagamentoService pagamentoService)
            : base(broadcaster)
        {
            _repository = contaRepository;
            _pagamentoService = pagamentoService;
        }
  
        public async Task AdicionarPagamento(Pagamento pagamento)
        {
            await _repository.Adicionar(pagamento.Conta);

            await _pagamentoService.Adicionar(pagamento);

        }

        public async Task Excluir(int id)
        {
            await _pagamentoService.ExcluirPorConta(id);
            await _repository.Remover(id);
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
