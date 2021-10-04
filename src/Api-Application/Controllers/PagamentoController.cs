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
    [Route("api/pagamento")]
    public class PagamentoController : BaseApiController
    {

        const string Permissao = "PAGAMENTO";

        private readonly IMapper _mapper;
        
        private readonly IPagamentoService _service;
        private readonly IPagamentoRepository _repository;

        public PagamentoController(ILogger<ContaController> logger,
                               IPagamentoService service,
                               IMapper mapper,
                               IBroadcaster broadcaster,
                               IPagamentoRepository repository)
           : base(broadcaster)
        {
            _service = service;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<PagamentoViewModel>> Listar()
        {
            var lista = await _repository.ListarTodos();
            lista = lista.OrderBy(i => i.DtVencimento).ToList();
            return _mapper.Map<IEnumerable<PagamentoViewModel>>(lista);
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<PagamentoViewModel>> ObterPorId(int id)
        {
            var pagamento = await _repository.ObterPorId(id);

            return _mapper.Map<PagamentoViewModel>(pagamento);
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<PagamentoViewModel>> Editar(int id, PagamentoViewModel contaAPagar)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Pagamento>(contaAPagar);
            await _service.Editar(id, entity);

            return CustomResponse();
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult> Deletar(int id)
        {
            await _service.Excluir(id);

            return CustomResponse();
        }


        [HttpPut("pago/{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult> EditarPago(int id, [FromBody] bool indPago)
        {
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.EditarPago(id, indPago); 

            return CustomResponse();
        }
    }
}
