﻿using ApiApplication.Extensions;
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
    [Route("api/pagamento")]
    public class PagamentoController : BaseApiController
    {

        const string Permissao = "PAGAMENTO";

        private readonly ILogger<ContaController> _logger;
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
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<ContaAPagarViewModel>> Listar()
        {
            var lista = await _repository.ListarTodos();
            lista = lista.OrderBy(i => i.DtVencimento).ToList();
            return _mapper.Map<IEnumerable<ContaAPagarViewModel>>(lista);
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ContaAPagarViewModel>> ObterPorId(int id)
        {
            var pagamento = await _repository.ObterPorId(id);

            return _mapper.Map<ContaAPagarViewModel>(pagamento);
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ContaAPagarViewModel>> Editar(int id, ContaAPagarViewModel contaAPagar)
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