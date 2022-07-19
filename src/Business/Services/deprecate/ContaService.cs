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

        public async Task AdicionarPagamentoUnico(Pagamento pagamento)
        {
            if (pagamento.Conta.TipoRecorrencia != TipoRecorrenciaEnum.Unico)
            { Notify("Operação inválida"); return; }


            if (pagamento.DtVencimento == DateTime.MinValue)
            { Notify("Data vencimento inválida. Se o Tipo Recorência for Único, então você deve informar uma Data de Vencimento"); return; }

            await _repository.Adicionar(pagamento.Conta);
            await _pagamentoService.Adicionar(pagamento);

        }


        public async Task AdicionarPagamentoMensal(Pagamento pagamento, int diaVencimento)
        {

            List<Pagamento> lstGerarPagamentos = new();

            int parcelasNoAno = 12 - DateTime.Now.Month;
            for (int i = 0; i < parcelasNoAno; i++)
            {
                var dtHj = DateTime.Now.Date;
                var dtVencMes = new DateTime(dtHj.Year,
                                            dtHj.AddMonths(i).Month,
                                            diaVencimento);

                var pagamentoMes = new Pagamento
                {
                    DtVencimento = dtVencMes,
                    Valor = pagamento.Valor,
                    IndPago = false,
                    Conta = pagamento.Conta,
                };
                lstGerarPagamentos.Add(pagamentoMes);
            }

            await _repository.Adicionar(pagamento.Conta);
            await _pagamentoService.Adicionar(lstGerarPagamentos);

            NotifyAsSuccess($"Operação realizada. Foram incluídas {parcelasNoAno} parcelas.");
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
