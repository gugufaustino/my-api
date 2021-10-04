using ApiApplication.Extensions;
using ApiApplication.ViewModel;
using AutoMapper;
using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiApplication.Controllers
{
    [Route("api/conta")]
    public class ContaController : BaseApiController
    {

        const string Permissao = "CONTA";

        private readonly ILogger<ContaController> _logger;
        private readonly IMapper _mapper;

        private readonly IContaService _service;
        private readonly IPagamentoRepository _repositoryPagamento;

        public ContaController(ILogger<ContaController> logger,
                               IContaService service,
                               IMapper mapper,
                               IBroadcaster broadcaster,
                               IPagamentoRepository repositoryPagamento)
           : base(broadcaster)
        {
            _logger = logger;

            _service = service;
            _mapper = mapper;
            _repositoryPagamento = repositoryPagamento;

            _logger.Log(LogLevel.Information, "ctor conta");
        }

        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<PagamentoViewModel>> Listar()
        {
            var lista = await _repositoryPagamento.ListarTodos();
            lista = lista.OrderBy(i => i.DtVencimento).ToList();
            return _mapper.Map<IEnumerable<PagamentoViewModel>>(lista);
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<PagamentoViewModel>> ObterPorId(int id)
        {
            var pagamento = await _repositoryPagamento.ObterPorId(id);

            return _mapper.Map<PagamentoViewModel>(pagamento);
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Excluir(id);

            return CustomResponse();
        }

        [HttpPost]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<PagamentoViewModel>> Inserir(PagamentoViewModel pagamento)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Pagamento>(pagamento);
            switch (entity.Conta.TipoRecorrencia)
            {
                case Business.Models.TipoRecorrenciaEnum.Unico:
                    await _service.AdicionarPagamentoUnico(entity);
                    break;
                case Business.Models.TipoRecorrenciaEnum.Mensal:
                    await _service.AdicionarPagamentoMensal(entity, pagamento.DiaVencimento.Value);
                    break;
                case Business.Models.TipoRecorrenciaEnum.Anual:
                default:
                    ToTransmit("Não implementado");
                    break;
            }

            return CustomResponse();
        }

    }
}
