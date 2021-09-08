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
    public class PagamentoService : BaseService, IPagamentoService
    {

        private readonly IPagamentoRepository _repository;
        public PagamentoService(IBroadcaster broadcaster,
            IPagamentoRepository PagamentoRepository)
            : base(broadcaster)
        {
            _repository = PagamentoRepository;

        }

        public async Task Adicionar(Pagamento Pagamento)
        {
            await _repository.Adicionar(Pagamento);
        }

        public async Task Editar(int Id, Pagamento pagamento)
        {
            var entity = await _repository.ObterPorId(Id);
            entity.DtVencimento = pagamento.DtVencimento.Date;
            entity.Valor = pagamento.Valor;

            await _repository.Editar(entity);
        }


        public async Task ExcluirPorConta(int id)
        {
            await _repository.ExcluirPorConta(id);
        }

        public async Task Excluir(int id)
        {
            var entity = await _repository.ObterPorId(id);
            if (entity.DtVencimento.Day == 1) { Notify("Teste validação"); return; }
           
            await _repository.Remover(entity);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task EditarPago(int id, bool indPago)
        {
            var entity = await _repository.ObterPorId(id);
            if (entity.DtVencimento.Day == 1) { Notify("Teste validação"); return; }

            entity.IndPago = indPago;
            await _repository.Editar(entity);
        }
    }
}
