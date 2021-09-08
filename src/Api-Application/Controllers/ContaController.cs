using ApiApplication.Extensions;
using ApiApplication.ViewModel;
using AutoMapper;
using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiApplication.Controllers
{
    [Authorize]
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
        }

        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<ContaAPagarViewModel>> Listar()
        {
            var lista = await _repositoryPagamento.ListarTodos();
            lista = lista.OrderBy(i => i.DtVencimento).ToList();
            return _mapper.Map<IEnumerable<ContaAPagarViewModel>>(lista);            
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ContaAPagarViewModel>> ObterPorId(int id)
        {
            var pagamento = await _repositoryPagamento.ObterPorId(id) ;
            
            return _mapper.Map<ContaAPagarViewModel>(pagamento);
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
        public async Task<ActionResult<ContaAPagarViewModel>> Inserir(ContaAPagarViewModel pagamento)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Pagamento>(pagamento);
            await _service.AdicionarPagamento(entity);

            return CustomResponse();
        }

    }
}
